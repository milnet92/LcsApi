using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LcsApi.Authentication;
using LcsApi.Exceptions;
using LcsApi.Model.Common;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LcsApi.Clients
{
    public abstract class LcsApiClientBase
    {
        public const string JSON_CONTENTTYPE = "application/json";
        public const string URL_ENCODED_CONTENTTYPE = "application/x-www-form-urlencoded";

        protected internal ILcsConnection Connection { get; private set; }
        public string BaseUrl { get; init; }
        public virtual string VerificationTokenUrl => $"{BaseUrl}/V2";

        internal LcsApiClientBase(ILcsConnection connection, string? baseUrl = null, string? apiDomain = null)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            
            string baseUrlValue = baseUrl ?? connection.Options.LcsUrl;

            if (!string.IsNullOrEmpty(apiDomain))
            {
                Uri uri = new Uri(baseUrlValue);
                BaseUrl = $"{uri.Scheme}://{apiDomain}.{uri.Host}";
            }
            else
            {
                BaseUrl = baseUrlValue;
            }
        }

        public async Task<T?> GetAsync<T>(string url, int? projectId = null, Dictionary<string, object>? parameters = null, CancellationToken cancellationToken = default)
        {
            if (projectId != null)
            {
                Connection.TryUpdateAllClientCookies(projectId.Value);

                return await Connection.GetAsync<T>($"{BaseUrl}/{url}/{projectId}", parameters, cancellationToken);
            }
            else
            {
                return await Connection.GetAsync<T>($"{BaseUrl}/{url}", parameters, cancellationToken);
            }
        }

        public async Task<T?> PostAsync<T>(string url, int? projectId = null, Dictionary<string, object>? parameters = null, object? content = null, string contentType = JSON_CONTENTTYPE, CancellationToken cancellationToken = default)
        {
            if (projectId != null)
            {
                Connection.TryUpdateAllClientCookies(projectId.Value);

                return await Connection.PostAsync<T>($"{BaseUrl}/{url}/{projectId}", parameters, content, contentType, cancellationToken);
            }
            else
            {
                return await Connection.PostAsync<T>($"{BaseUrl}/{url}", parameters, content, contentType, cancellationToken);
            }
        }

        public async Task<Stream> GetStreamAsync(string url, int? projectId = null, Dictionary<string, object>? parameters = null, CancellationToken cancellationToken = default)
        {
            if (projectId != null)
            {
                Connection.TryUpdateAllClientCookies(projectId.Value);

                return await Connection.GetStreamAsync($"{BaseUrl}/{url}/{projectId}", parameters, cancellationToken);
            }
            else
            {
                return await Connection.GetStreamAsync($"{BaseUrl}/{url}", parameters, cancellationToken);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0270:Use coalesce expression", Justification = "Code clarity")]
        public async Task<T?> PostLcsResponseAsync<T>(string url, int? projectId = null, Dictionary<string, object>? parameters = null, object? content = null, string contentType = JSON_CONTENTTYPE, CancellationToken cancellationToken = default)
        {
            LcsResponse<T> response = (await PostAsync<LcsResponse<T>>(url, projectId, parameters, content, contentType, cancellationToken))!;

            if (response is null)
            {
                throw new Exception("Response is empty");
            }

            if (!response.Success)
            {
                throw new LcsResponseException(response.ErrorCode, response.Message, response.MessageTitle, response.ErrorList);
            }

            return response.Data;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0270:Use coalesce expression", Justification = "Code clarity")]
        public async Task<T?> GetLcsResponseAsync<T>(string url, int? projectId = null, Dictionary<string, object>? parameters = null, CancellationToken cancellationToken = default)
        {
            LcsResponse<T?> response = (await GetAsync<LcsResponse<T>>(url, projectId, parameters, cancellationToken))!;

            if (response is null)
            {
                throw new Exception("Response is empty");
            }

            if (!response.Success)
            {
                throw new LcsResponseException(response.ErrorCode, response.Message, response.MessageTitle, response.ErrorList);
            }

            return response.Data;
        }
    }
}
