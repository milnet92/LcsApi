using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LcsApi.Authentication;
using OpenQA.Selenium.DevTools.V116.Page;

namespace LcsApi.Clients
{
    public interface ILcsConnection
    { 
        public IBrowserAuthenticationProvider AuthenticationProvider { get; }
        public LcsConnectionOptions Options { get; }
        public string? Cookies { get; }
        public void TryUpdateAllClientCookies(int projectId);
        public void PerformLogin();

        public Task<T?> GetAsync<T>(string url, Dictionary<string, object>? parameters = null, CancellationToken cancellationToken = default);
        public Task<Stream> GetStreamAsync(string url, Dictionary<string, object>? parameters = null, CancellationToken cancellationToken = default);

        public Task<T?> PostAsync<T>(string url, Dictionary<string, object>? parameters, object? content, string contentType, CancellationToken cancellationToken = default);
        public Task<T> GetClientAsync<T>(string? baseUrl = null, CancellationToken cancellationToken = default) where T : LcsApiClientBase;
    }
}
