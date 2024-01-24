using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LcsApi.Authentication;

namespace LcsApi.Clients
{
    public interface ILcsConnection
    { 
        IBrowserAuthenticationProvider AuthenticationProvider { get; }
        LcsConnectionOptions Options { get; }
        string Cookies { get; }
        void TryUpdateAllClientCookies(int projectId);
        void PerformLogin();

        Task<T> GetAsync<T>(string url, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default);
        Task<Stream> GetStreamAsync(string url, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default);

        Task<T> PostAsync<T>(string url, Dictionary<string, object> parameters, object content, string contentType, CancellationToken cancellationToken = default);
        Task<T> GetClientAsync<T>(string baseUrl = null, CancellationToken cancellationToken = default) where T : LcsApiClientBase;
    }
}
