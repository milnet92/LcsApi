using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LcsApi.Authentication;
using System.Threading;
using HtmlAgilityPack;
using LcsApi.Extensions;
using Newtonsoft.Json;
using System.IO;

namespace LcsApi.Clients
{
    public class LcsConnection : ILcsConnection, IDisposable
    {
        public const string LCSPID = "lcspid";
        public const string VERIFICATION_TOKEN_HEADER = "__RequestVerificationToken";

        private readonly CookieContainer _cookieContainer = new CookieContainer();

        public string Cookies { get; private set; }
        private int? lastProjectId;
        private readonly Dictionary<int, LcsApiClientBase> _clients = new Dictionary<int, LcsApiClientBase>();

        public HttpClient HttpClient { get; private set; }
        public IBrowserAuthenticationProvider AuthenticationProvider { get; private set; }
        public LcsConnectionOptions Options { get; set; }

        public LcsConnection(IBrowserAuthenticationProvider authenticationProvider, LcsConnectionOptions options = null)
        {
            AuthenticationProvider = authenticationProvider ?? throw new ArgumentNullException(nameof(authenticationProvider));
            Options = options ?? LcsConnectionOptions.Default;
        }

        public void PerformLogin()
        {
            if (!(HttpClient is null)) return;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            Cookies = AuthenticationProvider.GetCookies();

            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer,
                AllowAutoRedirect = true,
                UseCookies = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            HttpClient = new HttpClient(httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(Options.ConnectionTimeout)
            };

            HttpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            HttpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            HttpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3872.0 Safari/537.36 Edg/78.0.244.0");
            HttpClient.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            HttpClient.DefaultRequestHeaders.Add("cache-control", "no-cache");
            HttpClient.DefaultRequestHeaders.Add("TimezoneOffset", (-TimeZoneInfo.Local.GetUtcOffset(DateTime.Now)).TotalMinutes.ToString());
        }

        public async Task<string> GetAsync(string url, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default)
        {
            string requestUrl = ConstructUrlWithParameters(url, parameters);

            HttpResponseMessage response = await HttpClient.GetAsync(requestUrl, cancellationToken).ConfigureAwait(false);
            return await response.EnsureLcsSuccessStatusCode().Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string url, Dictionary<string, object> parameters = null, object body = null, string contentType = "application/json", CancellationToken cancellationToken = default)
        {
            if (contentType is null) throw new ArgumentNullException(nameof(contentType));

            string requestUrl = ConstructUrlWithParameters(url, parameters);

            if (!(body is null))
            {
                using (var content = GetContentByMediaTypeType(body, contentType))
                {
                    HttpResponseMessage response = await HttpClient.PostAsync(requestUrl, content, cancellationToken).ConfigureAwait(false);
                    return await response.EnsureLcsSuccessStatusCode().Content.ReadAsStringAsync();
                }
            }
            else
            {
                HttpResponseMessage response = await HttpClient.PostAsync(requestUrl, null, cancellationToken).ConfigureAwait(false);
                return await response.EnsureLcsSuccessStatusCode().Content.ReadAsStringAsync();
            }
        }

        public async Task<T> GetAsync<T>(string url, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default)
        {
            string response = await GetAsync(url, parameters, cancellationToken);

            if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(response, typeof(T));
            }
            else
            {
                var trimmedResponse = response.Trim('(', ')');
                return JsonConvert.DeserializeObject<T>(trimmedResponse);
            }
        }

        public async Task<Stream> GetStreamAsync(string url, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default)
        {
            return await HttpClient.GetStreamAsync(ConstructUrlWithParameters(url, parameters));
        }

        public async Task<T> PostAsync<T>(string url, Dictionary<string, object> parameters = null, object body = null, string mediaType = "application/json", CancellationToken cancellationToken = default)
        {
            string response = await PostAsync(url, parameters, body, mediaType, cancellationToken);
            if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(response, typeof(T));
            }
            else
            {
                response = response.Replace("Data=[]", "Data=");
                return JsonConvert.DeserializeObject<T>(response);
            }
        }

        public async Task<T> GetClientAsync<T>(string baseUrl = null, CancellationToken cancellationToken = default) where T : LcsApiClientBase
        {
            T client;

            int clientId = typeof(T).Name.GetHashCode();

            if (_clients.ContainsKey(clientId))
            {
                client = (T)_clients[clientId];
            }
            else
            {
                client = Activator.CreateInstance(typeof(T), this) as T;

                if (client != null)
                {
                    PerformLogin();

                    TrySetCookies(Options.LcsUrl, Cookies);
                    TrySetCookies(client.BaseUrl, Cookies);

                    if (lastProjectId != null)
                    {
                        UpdateProjectCookiesForUrl(client.BaseUrl, lastProjectId.Value);
                    }

                    await TryRequestVerificationTokenAsync($"{Options.LcsUrl}/V2", cancellationToken);

                    _clients.Add(clientId, client);
                }
            }

            if (client is null) throw new Exception($"Could not create client of type {typeof(T).Name}");

            return client;
        }

        private void TrySetCookies(string url, string cookies)
        {
            var uri = new Uri(url);
            CookieCollection cookiesCollection = _cookieContainer.GetCookies(uri);

            if (cookiesCollection.Count < 6)
            {
                _cookieContainer.SetCookies(uri, cookies);
            }
        }

        private void UpdateProjectCookiesForUrl(string url, int projectId)
        {
            var uri = new Uri(url);
            CookieCollection cookies = _cookieContainer.GetCookies(uri);
            Cookie cookie = null;

            // Get not exired cookie
            foreach (Cookie c in cookies)
            {
                if (c.Name == LCSPID && !c.Expired)
                {
                    cookie = c;
                }
            }

            string newCookieValue = projectId.ToString();
            
            if (!(cookie is null))
            {
                cookie.Value = newCookieValue;
            }
            else
            {
                cookies.Add(new Cookie(LCSPID, newCookieValue));
            }
        }

        public void TryUpdateAllClientCookies(int projectId)
        {
            if (lastProjectId == projectId) return;

            lastProjectId = projectId;
            UpdateAllClientCookies(projectId);
        }

        private void UpdateAllClientCookies(int projectid)
        {
            // Iterate through all created clients and update the project cookie
            foreach (var client in _clients.Values)
            {
                UpdateProjectCookiesForUrl(client.BaseUrl, projectid);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0270:Use coalesce expression", Justification = "Code clarity")]
        public async Task TryRequestVerificationTokenAsync(string url, CancellationToken cancellationToken = default)
        {
            if (!(HttpClient is null) && !HttpClient.DefaultRequestHeaders.Contains(VERIFICATION_TOKEN_HEADER))
            {
                var content = await GetAsync(url, null, cancellationToken);
                if (!(content is null))
                {
                    HtmlDocument doc = new HtmlDocument();
                    doc.LoadHtml(content);

                    var node = doc.DocumentNode.SelectSingleNode($"//input[@name='{VERIFICATION_TOKEN_HEADER}']");

                    if (node is null)
                        throw new Exception("Cannot find verification token header in response.");

                    var token = node.Attributes["value"].Value;
                    HttpClient.DefaultRequestHeaders.Add(VERIFICATION_TOKEN_HEADER, token);
                }
            }
        }

        private static string ConstructUrlWithParameters(string url, Dictionary<string, object> parameters = null)
        {
            string requestUrl = url;
            if (parameters != null && parameters.Count > 0)
            {
                for (int parmIdx = 0; parmIdx < parameters.Count; parmIdx++)
                {
                    var parameter = parameters.ElementAt(parmIdx);
                    object value = parameter.Value;

                    if (value is IEnumerable<string> enumerable && !(value is null))
                    {
                        value = string.Join(",", enumerable);
                    }

                    requestUrl += (parmIdx == 0 ? "?" : "&") + parameter.Key + "=" + value;
                }
            }
            return requestUrl;
        }

        private static HttpContent GetContentByMediaTypeType(object content, string mediaType)
        {
            if (string.IsNullOrEmpty(mediaType)) throw new ArgumentNullException(nameof(mediaType));

            if (mediaType == "application/json")
            {
                return new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, mediaType);
            }
            else if (mediaType == "application/x-www-form-urlencoded")
            {
                return new StringContent(GetUrlEncodedContent(content), Encoding.UTF8, mediaType);
            }
            else
            {
                throw new NotSupportedException($"Media type {mediaType} is not supported");
            }
        }

        private static string GetUrlEncodedContent(object content)
        {
            if (!(content is ICollection<KeyValuePair<string, object>> parameters)) throw new ArgumentException(nameof(parameters));

            string result = string.Empty;
            for (var idx = 0; idx < parameters.Count; idx++)
            {
                var parameter = parameters.ElementAt(idx);
                object value = parameter.Value is string val ? WebUtility.UrlEncode(val) : parameter.Value;
                result += (idx == 0 ? "" : "&") + $"{parameter.Key}={value}";
            }

            return result;
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
