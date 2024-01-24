using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LcsApi.Model.Common;
using LcsApi.Model.Diagnostics;
using Newtonsoft.Json;

namespace LcsApi.Clients
{
    public class LcsDiagnosticsApiClient : LcsApiClientBase
    {
        public const int DEFAULT_DIAGNOSTICS_RETURN_LIMIT = 50;
        public const int DEFAULT_METRICS_RETURN_LIMIT = 200;
        public const int DEFAULT_STARTDATE_OFFSET = -60;
        
        private const string DEFAULT_API_SUBDOMAIN = "diag";

        public static long CurrentTimeStamp => new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        public static long CurrentTimeStampWithOffset => new DateTimeOffset(DateTime.UtcNow).AddMinutes(DEFAULT_STARTDATE_OFFSET).ToUnixTimeMilliseconds();


        public LcsDiagnosticsApiClient(ILcsConnection connection) : base(connection, null, apiDomain: DEFAULT_API_SUBDOMAIN) { }
        public LcsDiagnosticsApiClient(ILcsConnection connection, string baseUrl) : base(connection, baseUrl) { }

        /* TODO: implement following endpoints
         * LogSearch/GetBatchThrottled
         * LogSearch/GetRetailLogs
         * LogSearch/GetConnectionOutages
         * LogSearch/GetAllCrashes
         * LogSearch/GetAllEventsForActivity
         * LogSearch/GetAllDeadlocks
         * LogSearch/GetEventsForBrowserSessions
         * LogSearch/GetThrottledRawLogs
         * LogSearch/GetEventsForUser
         * LogSearch/GetAPIUsageByAppUser
         * LogSearch/GetWeakCiphersUsage
         */

        /// <summary>
        /// Gets the interaction data from a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="fromMinutes">Minutes respective to present we need data from</param>
        /// <param name="to">Timestamp of the upper date limit. If none is provided, current UTC time stamp is used</param>
        /// <param name="roleInstances">Role instances</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MonitoringInteractionData> GetInteractionDataAsync(int projectId, Guid environmentId, int fromMinutes = -15, long? to = null, string[] roleInstances = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<MonitoringInteractionData>("Monitoring/GetInteractionData", projectId, 
                new Dictionary<string, object>() 
                { 
                    { "environmentId", environmentId},
                    { "minutes", fromMinutes},
                    { "to", to ?? CurrentTimeStamp },
                    { "roleInstances", roleInstances ?? Array.Empty<string>()},
                }, cancellationToken);
        }

        /// <summary>
        /// Gets the user login events for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="limit">Maximum number of records to be returned</param> 
        /// <param name="startDate">From date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="endDate">To date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UserLoginEvent[]> GetUserLoginEventsAsync(int projectId, Guid environmentId, int limit = DEFAULT_DIAGNOSTICS_RETURN_LIMIT, long? startDate = null, long? endDate = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<UserLoginEvent[]>("Monitoring/GetUserLoginEvents", projectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId},
                    { "limit", limit},
                    { "fromDate", startDate ?? CurrentTimeStamp},
                    { "toDate", endDate ?? CurrentTimeStamp},
                }, cancellationToken);
        }

        /// <summary>
        /// Gets all error events for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="limit">Maximum number of records to be returned</param> 
        /// <param name="startDate">From date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="endDate">To date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ErrorEvent[]> GetAllErrorEvents(int projectId, Guid environmentId, int limit = DEFAULT_DIAGNOSTICS_RETURN_LIMIT, long? startDate = null, long? endDate = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<ErrorEvent[]>("LogSearch/GetAllErrorEvents", projectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId },
                    { "limit", limit },
                    { "fromDate", startDate ?? CurrentTimeStamp},
                    { "toDate", endDate ?? CurrentTimeStamp}
                }, cancellationToken);
        }

        /// <summary>
        /// Gets the form error events for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="limit">Maximum number of records to be returned</param>
        /// <param name="formName">Form name</param>
        /// <param name="controlName">Control name</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ErrorEvent[]> GetErrorEventsForFormAsync(int projectId, Guid environmentId, int limit = DEFAULT_DIAGNOSTICS_RETURN_LIMIT, string formName = null, string controlName = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<ErrorEvent[]>("LogSearch/GetErrorEventsForForm", projectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId},
                    { "limit", limit},
                    { "formName", formName ?? string.Empty},
                    { "controlName", controlName ?? string.Empty},
                }, cancellationToken);
        }

        /// <summary>
        /// Gets slow queries detected for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="limit">Maximum number of records to be returned</param> 
        /// <param name="startDate">From date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="endDate">To date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SlowQuery[]> GetSlowQueriesAsync(int projectId, Guid environmentId, int limit = DEFAULT_DIAGNOSTICS_RETURN_LIMIT, long? startDate = null, long? endDate = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<SlowQuery[]>("LogSearch/GetSlowQueries", projectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId},
                    { "limit", limit},
                    { "startDate", startDate ?? CurrentTimeStamp},
                    { "endDate", endDate ?? CurrentTimeStamp},
                }, cancellationToken);
        }

        /// <summary>
        /// Gets slow user interactions detected for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="limit">Maximum number of records to be returned</param> 
        /// <param name="startDate">From date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="endDate">To date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SlowInteraction[]> GetSlowInteractionsAsync(int projectId, Guid environmentId, int limit = DEFAULT_DIAGNOSTICS_RETURN_LIMIT, long? startDate = null, long? endDate = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<SlowInteraction[]>("LogSearch/GetSlowInteractions", projectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId},
                    { "limit", limit},
                    { "startDate", startDate ?? CurrentTimeStamp},
                    { "endDate", endDate ?? CurrentTimeStamp},
                }, cancellationToken);
        }

        /// <summary>
        /// Gets all events for failed batch jobs a specific environment and (optinal) batch job name
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="limit">Maximum number of records to be returned</param> 
        /// <param name="startDate">From date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="endDate">To date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="batchJobName">Batch job name</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, object>> GetAllEventsForFailedBatchJobAsync(int projectId, Guid environmentId, int limit = DEFAULT_DIAGNOSTICS_RETURN_LIMIT, long? startDate = null, long? endDate = null, string batchJobName = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Dictionary<string, object>>("LogSearch/GetAllEventsForFailedBatchJob", projectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId},
                    { "limit", limit},
                    { "startDate", startDate ?? CurrentTimeStamp},
                    { "endDate", endDate ?? CurrentTimeStamp},
                    { "batchJobName", batchJobName ?? string.Empty},
                }, cancellationToken);
        }

        /// <summary>
        /// Gets distinct user whom created a session detected for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="limit">Maximum number of records to be returned</param> 
        /// <param name="startDate">From date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="endDate">To date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DistinctUser[]> GetDistinctUsersAsync(int porjectId, Guid environmentId, int limit = DEFAULT_DIAGNOSTICS_RETURN_LIMIT, long? startDate = null, long? endDate = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync<DistinctUser[]>("LogSearch/GetDistinctUsers", porjectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId},
                    { "limit", limit},
                    { "startDate", startDate ?? CurrentTimeStamp},
                    { "endDate", endDate ?? CurrentTimeStamp},
                }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment monitoring data
        /// </summary>
        /// <param name="projectID">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentMonitoringData> GetEnvironmentMetricsAsync(int projectID, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<EnvironmentMonitoringData>("ComponentMonitors/GetEnvironmentMonitoringData", projectID,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId}
                }, cancellationToken);
        }

        /// <summary>
        /// Gets metric data for the specified metric names, dates, service unit and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="metricNames">Metric names. If none specified, following metrics will be requested:
        /// <list type="definition">
        /// <item><term>Batch jobs</term><description>\Microsoft Dynamics AX Batch Server Group(total)\Batch Critical Job failed per second</description></item>
        /// <item><term>Deadlocks</term><description>\Microsoft Dynamics AX Database(axhost)\SQL deadlock errors as percentage of total</description></item>
        /// <item><term>Duplicate keys</term><description>\Microsoft Dynamics AX Database(axhost)\SQL duplicate key exceptions as percentage of total</description></item>
        /// <item><term>Sql statement errors</term><description>\Microsoft Dynamics AX Database(axhost)\SQL statements failed as percentage of total</description></item>
        /// <item><term>Sql slow statements</term><description>\Microsoft Dynamics AX Database(axhost)\Slow SQL statements executed as percentage of total</description></item>
        /// <item><term>Available MB</term><description>\Memory\Available MBytes</description></item>
        /// <item><term>Processor timer</term><description>\Processor(_Total)\% Processor Timen</description></item>
        /// </list>
        /// </param>
        /// <param name="limit">Maximum number of records to be returned</param> 
        /// <param name="startDate">From date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="endDate">To date as a unix timestamp. If none is provided, current UTC timestamp is used</param>
        /// <param name="serviceUnit">Service unit</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [Obsolete("Health metrics is known to be discontinued by Microsoft. However, it is still in use and visible in Health metrics LCS page.")]
        public async Task<Dictionary<string, Dictionary<string, MetricData>>> GetMetricDataAsync(
            int projectId, 
            Guid environmentId, 
            string[] metricNames = null, 
            int limit = DEFAULT_METRICS_RETURN_LIMIT,
            long? startDate = null, 
            long? endDate = null, 
            string serviceUnit = null,
            CancellationToken cancellationToken = default)
        {
            List<KeyValuePair<string, object>> body = new List<KeyValuePair<string, object>>()
            {
                new KeyValuePair < string, object >("startStr", startDate ?? CurrentTimeStamp),
                new KeyValuePair < string, object >("endStr", endDate ?? CurrentTimeStamp),
                new KeyValuePair < string, object >("serviceUnit", serviceUnit ?? string.Empty),
                new KeyValuePair < string, object >("maxPntsStr", limit)
            };

            if (metricNames is null)
            {
                body.Add(new KeyValuePair<string, object>("metrics[]", @"\Microsoft Dynamics AX Batch Server Group(total)\Batch Critical Job failed per second"));
                body.Add(new KeyValuePair<string, object>("metrics[]", @"\Microsoft Dynamics AX Database(axhost)\SQL deadlock errors as percentage of total"));
                body.Add(new KeyValuePair<string, object>("metrics[]", @"\Microsoft Dynamics AX Database(axhost)\SQL duplicate key exceptions as percentage of total"));
                body.Add(new KeyValuePair<string, object>("metrics[]", @"\Microsoft Dynamics AX Database(axhost)\SQL statements failed as percentage of total"));
                body.Add(new KeyValuePair<string, object>("metrics[]", @"\Microsoft Dynamics AX Database(axhost)\Slow SQL statements executed as percentage of total"));
                body.Add(new KeyValuePair<string, object>("metrics[]", @"\Memory\Available MBytes"));
                body.Add(new KeyValuePair<string, object>("metrics[]", @"\Processor(_Total)\% Processor Timen"));
            }
            else
            {
                foreach (string metricName in metricNames)
                {
                    body.Add(new KeyValuePair<string, object>("metrics[]", metricName));
                }
            }

            return await PostAsync<Dictionary<string, Dictionary<string, MetricData>>>("ComponentMonitors/GetMetricData", projectId, 
                new Dictionary<string, object>() { { "environmentId", environmentId } }, body, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Get sql actions available in SQL insights for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="accessLevel">Access level for the actions</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SqlAction[]> GetSqlActionsAsync(int projectId, Guid environmentId, SqlActionAccessLevel accessLevel, CancellationToken cancellationToken = default)
        {
            return await GetAsync<SqlAction[]>("LogSearch/GetSqlActions", projectId,
                new Dictionary<string, object>()
                {
                    { "environmentId", environmentId},
                    { "accessLevel", accessLevel},
                }, cancellationToken);
        }

        /// <summary>
        /// Invokes the specified SQL insights query and returns the results
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="environmentId"></param>
        /// <param name="queryName"></param>
        /// <param name="actionType"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FastQueryResult[]> InvokeFastQueryAsync(int projectId, Guid environmentId, string queryName, string actionType = "Query", string queryDescription = null, Dictionary<string, object> parameters = null, CancellationToken cancellationToken = default)
        {
            var body = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("environmentId", environmentId),
                new KeyValuePair < string, object >("queryName", queryName),
                new KeyValuePair < string, object >("queryDescription", queryDescription ?? string.Empty),
                new KeyValuePair < string, object >("actionType", actionType)
            };

            if (!(parameters is null))
            { 
                foreach (var parameter in parameters)
                {
                    body.Add(new KeyValuePair<string, object>(parameter.Key, parameter.Value));
                }
            }

            var rawResponse = await PostLcsResponseAsync<string>("Performance/InvokeFastQuery", projectId, null, body, URL_ENCODED_CONTENTTYPE, cancellationToken);

            return !(rawResponse is null) ? JsonConvert.DeserializeObject<FastQueryResult[]>(rawResponse) : default;
        }

        /// <summary>
        /// Gets the current running queries for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FastQueryResult[]> GetCurrentRunningQueriesAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await InvokeFastQueryAsync(projectId, environmentId, "CurrentRunningQueries", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the current blocking statements for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FastQueryResult[]> GetCurrentBlockingStatements(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await InvokeFastQueryAsync(projectId, environmentId, "GetCurrentBlockingStatements", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the current blocking tree for a specific environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FastQueryResult[]> GetCurrentBlockingTree(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await InvokeFastQueryAsync(projectId, environmentId, "CurrentBlockingTree", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Kills a Sql process by its process ID on the given environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="processId">Process ID</param>
        /// <param name="reason">Reason for killing the process</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task EndSqlByProcessId(int projectId, Guid environmentId, int processId, string reason, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> additionalParameters = new Dictionary<string, object>()
            {
                { "queryParameters[0][Name]", "Process ID" },
                { "queryParameters[0][Label]", "Process ID" },
                { "queryParameters[0][SQLParameterName]", "@processID" },
                { "queryParameters[0][DotNetType]", "System.Int32" },
                { "queryParameters[0][Value]", processId },
                { "reason", reason }
            };

            _ = await InvokeFastQueryAsync(projectId, environmentId, "EndSQLPID", "Command", parameters: additionalParameters, cancellationToken: cancellationToken);
        }
    }
}
