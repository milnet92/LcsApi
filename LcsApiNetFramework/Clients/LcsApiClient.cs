using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LcsApi.Model;
using LcsApi.Model.Common;
using LcsApi.Model.Diagnostics;
using LcsApiNetFramework.Extensions;

namespace LcsApi.Clients
{
    public class LcsApiClient : LcsApiClientBase
    {
        public LcsApiClient(ILcsConnection connection) : base(connection) { }
        public LcsApiClient(ILcsConnection connection, string baseUrl) : base(connection, baseUrl) { }

        /// <summary>
        /// Check if the sandbox environment licence, when the environment is deleted, is available for resurrection
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsSlotAvailableForResurrectionAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>("SaaSDeployment/IsSlotAvailableForResurrection", projectId, new Dictionary<string, object>()
            {
                { "environmentId", environmentId }
            }, cancellationToken);
        }

        /// <summary>
        /// Updates the environment notification list
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="additionalUsers">Additional users updated list separated by ';'</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateNotificationsListAsync(int projectId, Guid environmentId, string additionalUsers, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                { "environmentId", environmentId },
                { "additionalUsers", additionalUsers }
            };

            return await PostLcsResponseAsync<bool>("SaaSDeployment/UpdateNotificationsList", projectId, null, body, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the user notifications list for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<NotificationsUserList> GetNotificationsListAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<NotificationsUserList>("SaaSDeployment/GetNotificationsList", projectId, new Dictionary<string, object>()
            {
                { "environmentId", environmentId }
            }, cancellationToken);
        }

        /// <summary>
        /// Gets a project by its ID.
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>  
        /// <returns>Project data</returns>
        public async Task<Project> GetProjectAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Project>($"RainierProject/GetProject", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the recent project list visitted by the user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectReference[]> GetRecentProjectListAsync(CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectReference[]>("RainierProject/RecentProjectsList", null, null, cancellationToken);
        }

        /// <summary>
        /// Creates a new network seecurity group to access environment's Azure SQL database for Service Fabric deployment environments
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="ruleName">Rule name</param>
        /// <param name="ips">IPs</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddNetworkSecurityGroupServiceFabricDatabaseAsync(int projectId, Guid environmentId, string ruleName, string ips, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                { "newRuleName", ruleName },
                { "newRuleIpOrCidr", ips },
                { "lcsEnvironmentId", environmentId },
                { "newRuleService", "AzureSQL" }
            };

            await PostLcsResponseAsync<object>("EnvironmentServicingV2/SFAddNetworkSecurityRule", projectId, null, body, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Creates a new network seecurity group to access environment's RDP for non Service Fabric deployment environments
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="ruleName">Rule name</param>
        /// <param name="ips">IPs</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> AddNetworkSecurityGroupRdpAsync(int projectId, Guid environmentId, string ruleName, string ips, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                { "newRuleName", ruleName },
                { "newRuleIpOrCidr", ips },
                { "lcsEnvironmentId", environmentId },
                { "newRuleService", "RDP" }
            };

            return await PostLcsResponseAsync<bool>("Environment/AddNetworkSecurityRule", projectId, null, body, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Deletes the network security group for the given service fabric project and environment
        /// </summary>
        /// <param name="projectid">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="rules">Rules</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteServiceFabricNetworkSecurityRules(int projectid, Guid environmentId, string[] rules, CancellationToken cancellationToken = default)
        {
            await PostLcsResponseAsync<object>("EnvironmentServicingV2/SFDeleteNetworkSecurityRules", projectid, new Dictionary<string, object>()
            {
                { "lcsEnvironmentId", environmentId },
                { "rulesToDelete", string.Join("&rulesToDelete[]=", rules) }
            }, null, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Deletes the network security group for the given SaaS project and environment
        /// </summary>
        /// <param name="projectid">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="rules">Rules</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task DeleteSaaSNetworkSecurityRules(int projectid, Guid environmentId, string[] rules, CancellationToken cancellationToken = default)
        {
            await PostLcsResponseAsync<object>("Environment/DeleteNetworkSecurityRules", projectid, new Dictionary<string, object>()
            {
                { "lcsEnvironmentId", environmentId },
                { "rulesToDelete", string.Join("&rulesToDelete[]=", rules) }
            }, null, URL_ENCODED_CONTENTTYPE, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Request access to a Sandbox database for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="reason">Reason for access (Type)</param>
        /// <param name="reasonDetails">Reason details for access</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LcsResponse<Guid>> AddUserWithExpiry(int projectId, Guid environmentId, string reason, string reasonDetails, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "lcsEnvironmentId", environmentId },
                { "reason", reason },
                { "reasonDetails", reasonDetails }
            };

            return await PostLcsResponseAsync<LcsResponse<Guid>>("EnvironmentServicingV2/AddUserWithExpiry", projectId, parameters, null, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the list of projects as a paginated response. The number of items returned
        /// depends on the page size set in the request.
        /// </summary>
        /// <param name="paginatedRequest">Request as <see cref="PaginatedRequest"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<ProjectReference>> GetAllProjectsListAsync(PaginatedRequest paginatedRequest, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<ProjectReference>>("RainierProject/AllProjectsList", null, null, paginatedRequest, JSON_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Get the ECommerce environment data for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="eCommerceEnvironmentId">ECommerce environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ECommerceEnvironment> GetECommerceEnvironmentDataAsync(int projectId, Guid eCommerceEnvironmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ECommerceEnvironment>($"ECommerce/GetEnvironmentData", projectId, new Dictionary<string, object>() { { "environmentId", eCommerceEnvironmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the Retail environment data from the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="retailEnvironmentId">Retail environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RetailEnvironment> GetRetailEnvironmentAsync(int projectId, Guid retailEnvironmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<RetailEnvironment>("RetailDeployment/GetRetailEnvironment", projectId, new Dictionary<string, object>() { { "environmentId", retailEnvironmentId } }, cancellationToken);
        }

        /// <summary>
        /// Get the list of retail base builds for the given project, environment and scale unit
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="scaleUnitName">Scale unit name</param>
        /// <param name="baseVersion">Base version</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RetailBaseBuild[]> GetBaseBuildsAsync(int projectId, Guid environmentId, string scaleUnitName, string baseVersion, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<RetailBaseBuild[]>("RetailDeployment/GetBaseBuilds", projectId, 
                new Dictionary<string, object>() 
                { 
                    { "environmentId", environmentId }, 
                    { "scaleUnitName", scaleUnitName }, 
                    { "baseVersion", baseVersion } 
                }, cancellationToken);
        }

        /// <summary>
        /// Checks the health of the retail system for the given project, environment and scale unit
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Retail environment ID</param>
        /// <param name="scaleUnitId">Scale unit ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RetailSystemCheckHealth> CheckSystemHealthAsync(int projectId, Guid environmentId, string scaleUnitId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<RetailSystemCheckHealth>("RetailDeployment/CheckSystemHealth", projectId, 
                new Dictionary<string, object>() 
                { 
                    { "environmentId", environmentId }, 
                    { "scaleUnitId", scaleUnitId } 
                }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of learning tiles visible in the home page
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LearningTile[]> GetLearningTilesAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<LearningTile[]>("RainierHome/RetrieveLearningTiles", null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the project with its methodology
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectMethodology> SyncProjectWithMethodologyAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<ProjectMethodology>($"RainierProject/SyncProjectWithMethodology", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of services available for the project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string[]> GetProjectServiceList(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<string[]>($"RainierProject/GetProjectServiceList", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of implementation projects for the usera
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectReference[]> GetImplementationProjectsAsync(CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectReference[]>("RainierHome/RetrieveImplementationProjects", null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of beta features for the user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string[]> GetBetaFeaturesForUserAsync(CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<string[]>("Beta/GetBetaFeaturesForUser", null, null, cancellationToken);
        }

        /// <summary>
        /// Get the list of action center messages shown in the project's detatails page
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ActionCenterDataViewModel[]> GetActionCenterResultsAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ActionCenterDataViewModel[]>($"ActionCenter/GetActionCenterResults", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the upcoming update calendar for the selected project 
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpcomingUpdateCalendar> GetUpcomingUpdateCalendarAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<UpcomingUpdateCalendar>($"RainierSettings/GetUpcomingCalendars", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the update pause window for the selected project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UpdatePauseWindowForProject> GetUpdatePauseWindowForProjectAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<UpdatePauseWindowForProject>($"RainierSettings/CheckUpdatePauseWindowForProject", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of services that can be restarted in the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LabelValue> GetServicesToRestartAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<LabelValue>($"EnvironmentServicingV2/GetServicesToRestart", projectId, 
                new Dictionary<string, object>() 
                { 
                    { "lcsEnvironmentId", environmentId } 
                }, cancellationToken);
        }

        /// <summary>
        /// Gets the project owner's organization
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectOrganization> GetProjectOwnerOrganizationAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectOrganization>($"RainierSettings/GetProjectOwnerOrganization", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of organizations for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectOrganization[]> GetProjectOrganizationsAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectOrganization[]>("RainierSettings/GetProjectOrganizations", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the service fabric deployment summary for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentSummary[]> GetServiceFabricDeploymentSummaryAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentSummary[]>($"ServiceFabricDeployment/GetDeploymentSummary", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Get one version update view for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<OneVersionUpdateView> GetOneVersionUpdateViewAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<OneVersionUpdateView>($"Environment/GetOneVersionUpdateView", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the SaaS deployment summary for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentSummary[]> GetSaaSDeploymentSummaryAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentSummary[]>($"SaaSDeployment/GetDeploymentSummary", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the deployment summary metadata (light version) for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentSummary[]> GetDeploymentSummaryMetadataAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentSummary[]>($"SAASDeployment/GetDeploymentSummaryMetadata", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the service facbric  network security group for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<NetworkSecurityGroup> GetServiceFabricNetworkSecurityGroupAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<NetworkSecurityGroup>($"EnvironmentServicingV2/SFGetNetworkSecurityGroup", projectId, new Dictionary<string, object>() { { "lcsEnvironmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the SaaS network security group for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<NetworkSecurityGroup> GetSaaSNetworkSecurityGroup(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<NetworkSecurityGroup>($"Environment/GetNetworkSecurityGroup", projectId, new Dictionary<string, object>() { { "lcsEnvironmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment type for the selected environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentEnvironmentType> GetDeploymentEnvironmentTypeInfoAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentEnvironmentType>($"Environment/GetDeploymentEnvironmentTypeInfo", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the tenant plan details for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<TenantPlanDetails> RetrieveTenantPlansAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<TenantPlanDetails>("RainierProject/RetrieveTenantPlans", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the service access state for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="tfsServerSite">Team Foundation Server site url</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ServiceAccessState> GetServiceAccessStateAsync(int projectId, string tfsServerSite, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ServiceAccessState>("RainierTfs/ServiceAccessState", projectId, new Dictionary<string, object>() { { "site", tfsServerSite } }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of all suppor requests for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SupportRequest[]> GetPermierAndNonPremierIncidentsAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<SupportRequest[]>($"IncidentsList/PremierAndNonPremierIncidents", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of the project's users
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="paginatedRequest">Request as <see cref="PaginatedRequest"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<ProjectUser>> RetrieveProjectUsersAsync(int projectId, PaginatedRequest paginatedRequest, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<ProjectUser>>("RainierProjectUser/RetrieveProjectUsers", projectId, null, paginatedRequest, JSON_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the environment deployment progress informration
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentProgress> GetDeploymentProgressAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentProgress>($"ServiceFabricDeployment/GetDeploymentProgress", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment details
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CloudHostedInstance> GetEnvironmentDetailsAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<CloudHostedInstance>($"ServiceFabricDeployment/GetEnvironmentDetails", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Checks if an environment is an on-premise AX7 environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsOnPremiseAX7EnvironmentAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>($"Environment/IsOnPremiseAX7Environment", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Checks if one version update is applicable for the environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsOneVersionUpdateApplicableAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>($"Environment/IsOneVersionUpdateApplicable", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the Common Data Service details for the environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CDSDeploymentDetails> GetCDSDeploymentDetailsAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<CDSDeploymentDetails>($"ServiceFabricDeployment/GetCDSDeploymentDetails", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the user project capabilities, i.e. the list of actions the user can perform on the project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectUserCapabilities> GetProjectUserCapabilitiesAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectUserCapabilities>("RainierProject/GetProjectUserCapabilities", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Get children actions for the given action and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="parentActionId">Parent action ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Model.Action[]> GetInmediateChildActionsForActionAsync(int projectId, int parentActionId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Model.Action[]>("EnvironmentServicingV2/GetImmediateChildActionsForAction", projectId, new Dictionary<string, object>()
            {
                { "parentActionId", parentActionId },
                { "lcsEnvironmentId", environmentId }
            }, cancellationToken);
        }

        /// <summary>
        /// Gets the details for database export
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DetailsForExport> GetDetailsForExportAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DetailsForExport>("ServicingDataManagement/GetDetailsForExport", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Creates an empty file asset
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="product">Product name</param>
        /// <param name="productVersion">Product version</param>
        /// <param name="assetKind">Asset kind</param>
        /// <param name="componentId">Component ID</param>
        /// <param name="assetTypeName">Asset type name</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EmptyFileAsset> CreateEmptyFileAssetAsync(int projectId, string product, string productVersion, int assetKind, Guid componentId, string assetTypeName, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                { "product", product },
                { "productVersion", productVersion },
                { "assetKind", assetKind },
                { "componentId", componentId },
                { "assetTypeName", assetTypeName }
            };

            return await PostLcsResponseAsync<EmptyFileAsset>("FileAsset/CreateEmptyFileAsset", projectId, null, body, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Creates an empty file asset
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="detailsForExport">Details for export as a <see cref="DetailsForExport"/> instance</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EmptyFileAsset> CreateEmptyFileAssetAsync(int projectId, DetailsForExport detailsForExport, CancellationToken cancellationToken = default)
        {
            return await CreateEmptyFileAssetAsync(projectId,
                detailsForExport.ProductName, 
                detailsForExport.ProductVersion, 
                detailsForExport.AssetKind, 
                detailsForExport.ComponentId, 
                detailsForExport.AssetKind.ToString(), 
                cancellationToken);
        }

        /// <summary>
        /// Gets the diagnostic information for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DiagnosticInfo> GetDiagnosticMessagesAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DiagnosticInfo>($"Environment/GetDiagnosticsMessages", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of cloud hosted environments for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, CloudHostedInstance>> GetDeploymentDetailsAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<Dictionary<string, CloudHostedInstance>>($"DeploymentPortal/GetDeployementDetails", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Checks if Rdp is available for the given project, environment and virtual machine
        /// </summary>
        /// <param name="projectId">Project Id</param>
        /// <param name="hostedInstance">Cloud hosted environment instnace</param>
        /// <param name="virtualMachineReference">Virtual machine</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsRdpResourceAvailableAsync(int projectId, CloudHostedInstance hostedInstance, InstanceReference virtualMachineReference, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<string>($"DeploymentPortal/IsRdpResourceAvailable", projectId, new Dictionary<string, object>()
            {
                { "topologyInstanceId", hostedInstance.InstanceId },
                { "virtualMachineInstanceName", virtualMachineReference.MachineName },
                { "deploymentItemName", virtualMachineReference.ItemName },
                { "azureSubscriptionId", hostedInstance.AzureSubscriptionId },
                { "group", 0 },
                { "isARMTopology", hostedInstance.IsARMTopology },
                { "nsgWarningDisplayed", true }
            }, cancellationToken) != "";
        }

        /// <summary>
        /// Gets the Rdp connection details for the given project, environment and virtual machine
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="hostedInstance">Cloud hosted environment instance</param>
        /// <param name="virtualMachineReference">Virtual machine</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> DownloadRdpResourceAsync(int projectId, CloudHostedInstance hostedInstance, InstanceReference virtualMachineReference, CancellationToken cancellationToken = default)
        {
            return await GetAsync<string>($"DeploymentPortal/IsRdpResourceAvailable", projectId, new Dictionary<string, object>()
            {
                { "topologyInstanceId", hostedInstance.InstanceId },
                { "virtualMachineInstanceName", virtualMachineReference.MachineName },
                { "deploymentItemName", virtualMachineReference.ItemName },
                { "azureSubscriptionId", hostedInstance.AzureSubscriptionId },
                { "group", 0 },
                { "isARMTopology", hostedInstance.IsARMTopology },
                { "nsgWarningDisplayed", true },
                { "isDownloadEnabled", "True" }
            }, cancellationToken);
        }

        /// <summary>
        /// Gets the credentials for the item specified for the given project and environment
        /// </summary>
        /// <param name="projectId">Project Id</param>
        /// <param name="environmentId">Environment Id</param>
        /// <param name="itemName">Item name</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, string>> GetCredentialsAsync(int projectId, Guid environmentId, string itemName, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Dictionary<string, string>>($"DeploymentPortal/GetCredentials", projectId, new Dictionary<string, object>()
            {
                { "environmentId", environmentId },
                { "deploymentItemName", itemName }
            }, cancellationToken);
        }

        /// <summary>
        /// Exports the database for the given environment (Tier2+)
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="componentId">Component ID</param>
        /// <param name="artifactId">Artifact ID</param>
        /// <param name="actionId">Action ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> ExportDatabaseAsync(int projectId, Guid environmentId, Guid componentId, Guid artifactId, int actionId, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<bool>("ServicingDataManagement/ExportDatabase", projectId, null, new Dictionary<string, object>()
            {
                { "environmentId", environmentId },
                { "componentId", componentId },
                { "artifactId", artifactId },
                { "actionId", actionId }
            }, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the action hierarchy for the given action and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="parentActionId">Parent action ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Model.Action> GetActionHierarchyAsync(int projectId, int parentActionId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Model.Action>("EnvironmentServicingV2/GetActionHierarchy", projectId, new Dictionary<string, object>()
            {
                { "rootActionId", parentActionId },
                { "lcsEnvironmentId", environmentId }
            }, cancellationToken);
        }

        /// <summary>
        /// Gets subscription information for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="retrieveOrganizations">Also retrieve organizations information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Subscription> GetSubscriptionAsync(int projectId, bool retrieveOrganizations = false, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Subscription>($"DeploymentPortal/GetSubscription", projectId, new Dictionary<string, object>() { { "retrieveOrganizations", retrieveOrganizations } }, cancellationToken);
        }

        /// <summary>
        /// Get deployment details for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, CloudHostedInstance>> GetDeploymentDetailsForEnvironmentAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Dictionary<string, CloudHostedInstance>>($"DeploymentPortal/GetDeploymentDetailsForEnvironment", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Get environment status information
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="environmentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentStatus> GetEnvironmentStatusAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<EnvironmentStatus>($"Environment/GetEnvironmentStatus", projectId, new Dictionary<string, object>() { { "lcsEnvironmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment details
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CloudHostedInstance> GetSaaSDeploymentDetailAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<CloudHostedInstance>($"SaaSDeployment/GetDeploymentDetail", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment details
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CloudHostedInstance> GetServiceFabricDeploymentDetailAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<CloudHostedInstance>($"ServiceFabricDeployment/GetEnvironmentDetails", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of assets metadata for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="returnAssetTypeMetadataOnly">Retrieve only metadata information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AssetMetadata[]> GetProjectAssetsAsync(int projectId, bool returnAssetTypeMetadataOnly = true, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<AssetMetadata[]>("FileAsset/GetProjectAssets", projectId, new Dictionary<string, object>() { { "returnAssetTypeMetadataOnly", returnAssetTypeMetadataOnly } }, cancellationToken);
        }


        /// <summary>
        /// Validates a deployable package for pre-apply against the given project and sandbox environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="deployablePackage">Deploybale package to validate</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> ValidatePreApplySandboxPackageAsync(int projectId, DeployablePackage deployablePackage, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<string>("EnvironmentServicingV2/ValidatePreApplySandboxPackage", projectId, null, deployablePackage.ToEnvironmentActionParameters(), URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Applies a deployable package to the given project and sandbox environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="deployablePackage">Deployable package to apply to the validation</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentActionResponse> StartSandboxPackageValidationAsync(int projectId, DeployablePackage deployablePackage, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<EnvironmentActionResponse>("EnvironmentServicingV2/StartSandboxPackageValidation", projectId, null, deployablePackage.ToEnvironmentActionParameters(), URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Validates a deplloyable package against the given project and sandbox environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="deployablePackage">Deploybale package to validate</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> ValidateSandboxServicingAsync(int projectId, DeployablePackage deployablePackage, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<string>("EnvironmentServicingV2/ValidateSandboxServicing", projectId, null, deployablePackage.ToEnvironmentActionParameters(), URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Applies a deployable package to the given project and sandbox environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="updateName">Update name</param>
        /// <param name="deployablePackage">Deployable package to apply</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentActionResponse> StartSandboxServicingAsync(int projectId, string updateName, DeployablePackage deployablePackage, CancellationToken cancellationToken = default)
        {
            var args = deployablePackage.ToEnvironmentActionParameters();
            args.Add("updatename", updateName);

            return await PostLcsResponseAsync<EnvironmentActionResponse>("EnvironmentServicingV2/StartSandboxServicing", projectId, null, args, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the list of assets for the given project and asset kind
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetKind">Asset kind ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AssetMetadata[]> GetProjectAssetsAsync(int projectId, int assetKind, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<AssetMetadata[]>("FileAsset/GetProjectAssets", projectId, new Dictionary<string, object>() { { "assetKind", assetKind } }, cancellationToken);
        }

        /// <summary>
        /// Checks if the authenticated user is a non-Microsoft AD user
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsNonMicrosoftADuserAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<bool>("RainierHome/IsNonMicrosoftADuser", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of product versions that can be deployed in the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProductVersion[]> GetProductVersionsAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProductVersion[]>("SAASDeployment/GetProductVersions", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of available topologies for deployment in for the given project, application version and product version
        /// </summary>
        /// <param name="projectId">Product ID</param>
        /// <param name="applicationVersion">Application version (example: APP10.0.37)</param>
        /// <param name="productVersion">Product version (example: CU61_1037)</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentDeployTopology[]> GetAvailableTopologiesAsync(int projectId, string applicationVersion, string productVersion, CancellationToken cancellationToken = default)
        {
            return await GetAsync<EnvironmentDeployTopology[]>("DeploymentPortal/GetAvailableTopologies", projectId, new Dictionary<string, object>()
            {
                { "applicationVersion", applicationVersion },
                { "productVersion", productVersion }
            }, cancellationToken);
        }

        /// <summary>
        /// Gets the available customization options that can be configured during a deployment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="customizationRequest">Request parameters as an <see cref="EnvironmentCustomizationRequest"/> instance</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentCustomization> GetCustomizationsAsync(int projectId, EnvironmentCustomizationRequest customizationRequest, CancellationToken cancellationToken = default)
        {
            customizationRequest.EnsureRequestIsValid();

            return await GetAsync<EnvironmentCustomization>("DeploymentPortal/GetCustomizations", projectId, new Dictionary<string, object>()
            {
                { "topologyName", customizationRequest.TopologyName },
                { "catalogName", customizationRequest.CatalogName },
                { "buildNumber", customizationRequest.BuildNumber },
                { "group", customizationRequest.Group },
                { "connectorId", customizationRequest.ConnectorId },
                { "applicationVersion", customizationRequest.ApplicationVersion },
                { "productVersion", customizationRequest.ProductVersion }
            }, cancellationToken);
        }

        /// <summary>
        /// Checks if the user can deploy an environment in the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> CanDeployEnvironmentAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>("Environment/CanDeployEnvironment", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Validates the entitlement for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> ValidateProjectEntitlementAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>("RainierProject/ValidateProjectEntitlement", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets all Cloud hosted environment metadata for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="filterBy">Filter by criteria</param>
        /// <param name="filterValue">Filter value</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, CloudHostedInstance>> GetAllCheDeploymentsMetadataAsync(int projectId, string filterBy = null, string filterValue = null, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Dictionary<string, CloudHostedInstance>>("DeploymentPortal/GetAllCheDeploymentsMetadata", projectId, new Dictionary<string, object>()
            {
                { "filterBy", filterBy ?? "null" },
                { "filterValue", filterValue ?? "null" }
            }, cancellationToken);
        }

        /// <summary>
        /// Send a request to start, stop or deallocate a cloud hosted environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="request">The request as a <see cref="StartStopDeploymentRequest"/> instance</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> StartStopDeploymentAsync(int projectId, StartStopDeploymentRequest request, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> requestContent = new Dictionary<string, object>()
            {
                { request.Action.ToString().ToLowerInvariant(), null},
                { "topologyName", request.TopologyName },
                { "activityId", request.ActivityId },
                { "azureSubscriptionId", request.AzureSubscriptionId },
                { "environmentGroup", request.EnvironmentGroup },
                { "environmentId", request.EnvironmentId },
                { "productName", request.ProductName },
                { "topologyInstanceId", request.TopologyInstanceId },
            };

            return await PostAsync<bool>("DeploymentPortal/StartStopDeployment", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        ///  Get the list ofi notification for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectNotification[]> GetProjectNotificationConfigurationAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectNotification[]>("Notification/AllProjectNotifications", projectId, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Enables or disables a notification for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="notificationId">Notification ID</param>
        /// <param name="enabled">True if you want to enable a notification, otherwise false</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> UpdateProjectUserNotificationAsync(int projectId, int notificationId, bool enabled, CancellationToken cancellationToken = default)
        {
            var a = "Notification/UpdateProjectUserNotification";

            return await PostLcsResponseAsync<bool>("Notification/UpdateProjectUserNotification", projectId, null, new Dictionary<string, object>()
            {
                { "notificationId", notificationId },
                { "enabled", enabled }
            }, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }



        /// <summary>
        /// Edits a file asset's name and description
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetId">Asset ID</param>
        /// <param name="assetName">New asset name</param>
        /// <param name="assetDescription">New asset description</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task EditFileAssetAsync(int projectId, Guid assetId, string assetName, string assetDescription, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> requestContent = new Dictionary<string, object>()
            {
                { "AssetId", assetId },
                { "Name", assetName },
                { "Description", assetDescription }
            };

            await PostLcsResponseAsync<object>("FileAsset/EditFileAsset", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        ///  Enables or disables maintenance mode for the given environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environonment ID</param>
        /// <param name="enable">If you want to enable maintenance mode, true, otherwise false</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task EnableDisableMaintenanceModeAsync(int projectId, Guid environmentId, bool enable, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> requestContent = new Dictionary<string, object>()
            {
                { "lcsEnvironmentId", environmentId },
                { "enableMaintenanceMode", enable }
            };

            await PostLcsResponseAsync<object>("EnvironmentServicingV2/EnableDisableMaintenanceMode", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the list of shared assets
        /// </summary>
        /// <param name="assetKind">Asset kind</param>
        /// <returns></returns>
        public async Task<AssetMetadata[]> GetSharedAssetsAsync(int assetKind, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<AssetMetadata[]>("FileAsset/GetSharedAssets", null, new Dictionary<string, object>() { { "assetKind", assetKind } }, cancellationToken);
        }

        /// <summary>
        /// Gets the shared asset SAS link
        /// </summary>
        /// <param name="assetId">Asset ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Link> GetSharedAssetSasLinkAsync(Guid assetId, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> requestContent = new Dictionary<string, object>()
            {
                { "assetId", assetId },
                { "isForceDownload", false }
            };

            return await GetLcsResponseAsync<Link>("FileAsset/DownloadSharedFileAsset", null, requestContent, cancellationToken);
        }

        /// <summary>
        /// Gets the project asset SAS link
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetId">Asset ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Link> GetProjectAssetSasLinkAsync(int projectId, Guid assetId, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> requestContent = new Dictionary<string, object>()
            {
                { "assetId", assetId },
                { "isForceDownload", false }
            };

            return await GetLcsResponseAsync<Link>("FileAsset/DownloadProjectFileAsset", projectId, requestContent, cancellationToken);
        }

        /// <summary>
        /// Delete a list of file assets
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetIds">Array of assets</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task DeleteFileAssetsAsync(int projectId, Guid[] assetIds, CancellationToken cancellationToken = default)
        {
            if (assetIds is null || assetIds.Length == 0) throw new ArgumentException("Asset list should not be empty", nameof(assetIds));

            List<KeyValuePair<string, object>> requestContent = new List<KeyValuePair<string, object>>();

            foreach (var assetId in assetIds)
            {
                requestContent.Add(new KeyValuePair<string, object>("AssetIds[]", assetId));
            }

            await PostLcsResponseAsync<object>("FileAsset/EditFileAsset", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Get asset download information for a specific asset
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetId">Asset ID</param>
        /// <param name="orgId">Organization ID</param>
        /// <param name="isForceDownload">This parameter should be kept at false</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AssetDownload> GetAssetDownloadAsync(int projectId, Guid assetId, int orgId, bool isForceDownload = false, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<AssetDownload>("FileAsset/GetAssetDownload", projectId,
                new Dictionary<string, object>()
                {
                    { "assetId", assetId },
                    { "orgId", orgId },
                    { "isForceDownload", isForceDownload }

                }, cancellationToken);
        }

        /// <summary>
        /// Get the list of asset versions for a specific asset
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetId">Asset ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FileAssetVersion[]> GetFileAssetVersionsAsync(int projectId, Guid assetId, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                { "parentFileAssetId", assetId }
            };

            return await PostLcsResponseAsync<FileAssetVersion[]>("FileAsset/GetFileAssetVersions", projectId, null, body, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Imports an asset into the project asset library. This can also be used to import a specific version of an asset
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetId">Asset ID to import</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Asset ID of the new asset imported</returns>
        public async Task<Guid> ImportFileAssetAsync(int projectId, Guid assetId, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new Dictionary<string, object>()
            {
                { "assetId", assetId }
            };

            return await PostLcsResponseAsync<Guid>("FileAsset/ImportFileAsset", projectId, null, body, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Saves the given assets to the user's library
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetIds">Asset IDs to save into the library</param>
        /// <param name="assetType">Asset type</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<bool> SaveAssetsToMyLibrary(int projectId, Guid[] assetIds, int assetType, CancellationToken cancellationToken = default)
        {
            if (assetIds is null || assetIds.Length == 0) throw new ArgumentException("Asset list should not be empty", nameof(assetIds));

            List<KeyValuePair<string, object>> requestContent = new List<KeyValuePair<string, object>>();

            foreach (var assetId in assetIds)
            {
                requestContent.Add(new KeyValuePair<string, object>("AssetIds[]", assetId));
            }

            requestContent.Add(new KeyValuePair<string, object>("AssetType", assetType));

            return await PostLcsResponseAsync<bool>("FileAsset/SaveAssetsToMyLibrary", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Copy the file assets to the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetIds">Asset IDs to copy</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CopyFileAssetsToProject(int projectId, Guid[] assetIds, CancellationToken cancellationToken = default)
        {
            if (assetIds is null || assetIds.Length == 0) throw new ArgumentException("Asset list should not be empty", nameof(assetIds));

            List<KeyValuePair<string, object>> requestContent = new List<KeyValuePair<string, object>>();

            foreach (var assetId in assetIds)
            {
                requestContent.Add(new KeyValuePair<string, object>("AssetIds[]", assetId));
            }

            _ = await PostLcsResponseAsync<object>("FileAsset/CopyFileAssetsToProject", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the list of the current user's organization methodologies
        /// </summary>
        /// <param name="request">Request as a <see cref="PaginatedRequest"/> </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Methodology[]> GetMethodologiesAsync(CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<Methodology[]>("MethodologyManagement/RetrieveMethodologies", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of the current user's organization methodologies as a paginated response
        /// </summary>
        /// <param name="request">Request as a <see cref="PaginatedRequest"/> instance</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<Methodology[]>> GetMethodologiesPaginated(PaginatedRequest request, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<Methodology[]>>("MethodologyManagement/RetrieveMethodologies", null, new Dictionary<string, object>() { { "IsScrollRequired", true } }, request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of products available
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Product[]> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Product[]>("Product/GetProducts", null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the environment action detail that is currently being applied to the environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentAction> GetOngoingActionDetailsAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<EnvironmentAction>("EnvironmentServicingV2/GetOngoingActionDetails", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Checks if addins can be managed for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsAddinsManagementAllowedAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>("AddIns/IsAddinsManagementAllowed", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Checks if the specified project service is enabled
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="serviceName">Service name</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> IsServiceEnabledForProjectAsync(int projectId, string serviceName, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<bool>("RainierProject/IsServiceEnabledForProject", projectId, new Dictionary<string, object>() { { "serviceName", serviceName } }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of deployable package action details for the specified environment action history ID
        /// </summary>
        /// <param name="projectId"Project ID></param>
        /// <param name="lcsEnvironmentActionHistoryId"></param>
        /// <param name="showAllSteps"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeployablePackageHistoryDetails> GetDeployablePackageHistoryDetailsAsync(int projectId, bool lcsEnvironmentActionHistoryId, bool showAllSteps = false, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeployablePackageHistoryDetails>("Environment/GetDeployablePackageHistoryDetails", projectId, new Dictionary<string, object>()
            {
                { "lcsEnvironmentActionHistoryId", lcsEnvironmentActionHistoryId },
                { "showAllSteps", showAllSteps }
            }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of deployable packages for the cloud hosted environment selected
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="paginatedRequest">Paginated request</param>
        /// <param name="lcsEnvironmentActionId">Environment action ID. To be save, this should be retrieve from <see cref="GetActionHierarchyAsync"/> call</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<DeployablePackage>> GetPagedDeployablePackageListForCloudHostedEnvironmentAsync(int projectId, Guid environmentId, PaginatedRequest paginatedRequest, int lcsEnvironmentActionId = 2, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<DeployablePackage>>("Environment/GetPagedDeployablePackageList", projectId, new Dictionary<string, object>()
            {
                { "environmentId", environmentId },
                { "lcsEnvironmentActionId", lcsEnvironmentActionId }
            }, paginatedRequest, JSON_CONTENTTYPE, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of deployable packages for the cloud hosted environment selected
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="paginatedRequest">Paginated request</param>
        /// <param name="lcsEnvironmentActionId">Environment action ID. To be save, this should be retrieve from <see cref="GetActionHierarchyAsync"/> call</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<DeployablePackage>> GetPagedDeployablePackageListForMiscrosoftHostedEnvironmentAsync(int projectId, Guid environmentId, PaginatedRequest paginatedRequest, int lcsEnvironmentActionId = 54, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<DeployablePackage>>("EnvironmentServicingV2/GetPagedDeployablePackageList", projectId, new Dictionary<string, object>()
            {
                { "lcsEnvironmentId", environmentId },
                { "lcsEnvironmentActionId", lcsEnvironmentActionId }
            }, paginatedRequest, JSON_CONTENTTYPE, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of environment actions applied to the given environment as a paginated response
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<EnvironmentAction>> GetEnvironmentHistoryDetailsAsync(int projectId, Guid environmentId, PaginatedRequest paginatedRequest = null, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<EnvironmentAction>>("Environment/GetEnvironmentHistoryDetails", projectId, new Dictionary<string, object>() { { "environmentId", environmentId } }, paginatedRequest, JSON_CONTENTTYPE, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of database movement action details for the specified environment action history ID
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="lcsEnvironmentActionHistoryId">Environemtn action history ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DatabaseMovementAction> GetDatabaseMovementHistoryDetailsAsync(int projectId, int lcsEnvironmentActionHistoryId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DatabaseMovementAction>("Environment/GetDatabaseMovementHistoryDetails", projectId, new Dictionary<string, object>() { { "lcsEnvironmentActionHistoryId", lcsEnvironmentActionHistoryId } }, cancellationToken);
        }
    }
}
