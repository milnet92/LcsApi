using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LcsApi.Model.Sizing;

namespace LcsApi.Clients
{
    internal class LcsSizingApiClient : LcsApiClientBase
    {
        private const string DEFAULT_API_SUBDOMAIN = "sizing";

        public LcsSizingApiClient(ILcsConnection connection) : base(connection, null, apiDomain: DEFAULT_API_SUBDOMAIN) { }
        public LcsSizingApiClient(ILcsConnection connection, string baseUrl) : base(connection, baseUrl) { }

        /// <summary>
        /// Get the subscription estimates for a specific project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SubscriptionEstimate?> GetEstimatesAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<SubscriptionEstimate>($"SubscriptionEstimator/GetEstimates", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Checks if the project is implementation
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsAnImplementationProjectAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>($"SubscriptionEstimator/IsAnImplementationProject", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the activation history for a specific estimate
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="estimateId">Estimate ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ActivationHistory[]?> GetActivationHistoryAsync(int projectId, int estimateId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ActivationHistory[]>($"SubscriptionEstimator/GetActivationHistory", projectId, new(){ { "estimateId", estimateId } }, cancellationToken);
        }

        /// <summary>
        /// Get the answers given by the user for a specific estimate.
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="estimateId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EstimateAnswer[]?> GetAnswersAsync(int projectId, int estimateId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<EstimateAnswer[]>($"SubscriptionEstimator/GetAnswers", projectId, new() { { "estimateId", estimateId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the sample usage profile timesheet file stream
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Stream> GetSampleUsageProfileLinkAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetStreamAsync($"SubscriptionEstimator/GetSampleUsageProfileLink", projectId, null, cancellationToken);
        }
    }
}
