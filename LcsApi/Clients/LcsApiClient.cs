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

namespace LcsApi.Clients
{
    public class LcsApiClient : LcsApiClientBase
    {
        public LcsApiClient(ILcsConnection connection) : base(connection) { }
        public LcsApiClient(ILcsConnection connection, string baseUrl) : base(connection, baseUrl) { }

        /// <summary>
        /// Gets a project by its ID.
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>  
        /// <returns>Project data</returns>
        public async Task<Project?> GetProjectAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Project>($"RainierProject/GetProject", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the recent project list visitted by the user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectReference[]?> GetRecentProjectListAsync(CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectReference[]>("RainierProject/RecentProjectsList", null, null, cancellationToken);
        }

        /// <summary>
        /// Get the list of projects as a paginated response. The number of items returned
        /// depends on the page size set in the request.
        /// </summary>
        /// <param name="paginatedRequest">Request as <see cref="PaginatedRequest"/></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<ProjectReference>?> GetAllProjectsListAsync(PaginatedRequest paginatedRequest, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<ProjectReference>>("RainierProject/AllProjectsList", null, null, paginatedRequest, JSON_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the list of learning tiles visible in the home page
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<LearningTile[]?> GetLearningTilesAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<LearningTile[]>("RainierHome/RetrieveLearningTiles", null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the project with its methodology
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectMethodology?> SyncProjectWithMethodology(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectMethodology>($"RainierProject/SyncProjectWithMethodology", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of services available for the project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string[]?> GetProjectServiceList(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<string[]>($"RainierProject/GetProjectServiceList", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of implementation projects for the usera
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectReference[]?> GetImplementationProjectsAsync(CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectReference[]>("RainierHome/RetrieveImplementationProjects", null, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of beta features for the user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string[]?> GetBetaFeaturesForUserAsync(CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<string[]>("Beta/GetBetaFeaturesForUser", null, null, cancellationToken);
        }

        /// <summary>
        /// Get the list of action center messages shown in the project's detatails page
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ActionCenterDataViewModel[]?> GetActionCenterResultsAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ActionCenterDataViewModel[]>($"ActionCenter/GetActionCenterResults", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the deployment summary for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentSummary[]?> GetDeploymentSummaryAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentSummary[]>($"ServiceFabricDeployment/GetDeploymentSummary", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the deployment summary metadata (light version) for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentSummary[]?> GetDeploymentSummaryMetadataAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentSummary[]>($"SAASDeployment/GetDeploymentSummaryMetadata", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the environment type for the selected environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentEnvironmentType?> GetDeploymentEnvironmentTypeInfoAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentEnvironmentType>($"Environment/GetDeploymentEnvironmentTypeInfo", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment deployment progress informration
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeploymentProgress?> GetDeploymentProgressAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeploymentProgress>($"ServiceFabricDeployment/GetDeploymentProgress", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment details
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CloudHostedInstance?> GetEnvironmentDetailsAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<CloudHostedInstance>($"ServiceFabricDeployment/GetEnvironmentDetails", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
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
            return await GetLcsResponseAsync<bool>($"Environment/IsOnPremiseAX7Environment", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
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
            return await GetLcsResponseAsync<bool>($"Environment/IsOneVersionUpdateApplicable", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the Common Data Service details for the environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CDSDeploymentDetails?> GetCDSDeploymentDetailsAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<CDSDeploymentDetails>($"ServiceFabricDeployment/GetCDSDeploymentDetails", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the user project capabilities, i.e. the list of actions the user can perform on the project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProjectUserCapabilities?> GetProjectUserCapabilitiesAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<ProjectUserCapabilities>($"RainierProject/GetProjectUserCapabilities", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Get children actions for the given action and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="parentActionId">Parent action ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Model.Action[]?> GetInmediateChildActionsForAction(int projectId, int parentActionId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Model.Action[]>($"EnvironmentServicingV2/GetImmediateChildActionsForAction", projectId, new()
            {
                { "parentActionId", parentActionId },
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
        public async Task<Subscription?> GetSubscriptionAsync(int projectId, bool retrieveOrganizations = false, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Subscription>($"DeploymentPortal/GetSubscription", projectId, new() { { "retrieveOrganizations", retrieveOrganizations } }, cancellationToken);
        }

        /// <summary>
        /// Get deployment details for the given project and environment
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, CloudHostedInstance?>?> GetDeploymentDetailsForEnvironment(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Dictionary<string, CloudHostedInstance?>>($"DeploymentPortal/GetDeploymentDetailsForEnvironment", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Get environment status information
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="environmentId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EnvironmentStatus?> GetEnvironmentStatusAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<EnvironmentStatus>($"Environment/GetEnvironmentStatus", projectId, new() { { "lcsEnvironmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the environment details
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CloudHostedInstance?> GetDeploymentDetailAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<CloudHostedInstance>($"SaaSDeployment/GetDeploymentDetail", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of assets metadata for the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="returnAssetTypeMetadataOnly">Retrieve only metadata information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AssetMetadata[]?> GetProjectAssetsAsync(int projectId, bool returnAssetTypeMetadataOnly = true, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<AssetMetadata[]>("FileAsset/GetProjectAssets", projectId, new() { { "returnAssetTypeMetadataOnly", returnAssetTypeMetadataOnly } }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of assets for the given project and asset kind
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="assetKind">Asset kind ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AssetMetadata[]?> GetProjectAssetsAsync(int projectId, int assetKind, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<AssetMetadata[]>("FileAsset/GetProjectAssets", projectId, new() { { "assetKind", assetKind } }, cancellationToken);
        }

        /// <summary>
        /// Checks if the authenticated user is a non-Microsoft AD user
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool?> IsNonMicrosoftADuserAsync(int projectId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<bool>("RainierHome/IsNonMicrosoftADuser", projectId, null, cancellationToken);
        }

        /// <summary>
        /// Gets the list of product versions that can be deployed in the given project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ProductVersion[]?> GetProductVersionsAsync(int projectId, CancellationToken cancellationToken = default)
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
        public async Task<EnvironmentDeployTopology[]?> GetAvailableTopologiesAsync(int projectId, string applicationVersion, string productVersion, CancellationToken cancellationToken = default)
        {
            return await GetAsync<EnvironmentDeployTopology[]>("DeploymentPortal/GetAvailableTopologies", projectId, new()
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
        public async Task<EnvironmentCustomization?> GetCustomizationsAsync(int projectId, EnvironmentCustomizationRequest customizationRequest, CancellationToken cancellationToken = default)
        {
            customizationRequest.EnsureRequestIsValid();

            return await GetAsync<EnvironmentCustomization>("DeploymentPortal/GetCustomizations", projectId, new()
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
        public async Task<Dictionary<string, CloudHostedInstance?>?> GetAllCheDeploymentsMetadataAsync(int projectId, string? filterBy = null, string? filterValue = null, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<Dictionary<string, CloudHostedInstance?>>("DeploymentPortal/GetAllCheDeploymentsMetadata", projectId, new()
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
            Dictionary<string, object?> requestContent = new()
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
            Dictionary<string, object?> requestContent = new()
            {
                { "AssetId", assetId },
                { "Name", assetName },
                { "Description", assetDescription }
            };

            await PostLcsResponseAsync<object>("FileAsset/EditFileAsset", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
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

            List<KeyValuePair<string, object>> requestContent = new();
            foreach (var assetId in assetIds)
            {
                requestContent.Add(new("AssetIds[]", assetId));
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
        public async Task<AssetDownload?> GetAssetDownloadAsync(int projectId, Guid assetId, int orgId, bool isForceDownload = false, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<AssetDownload>("FileAsset/GetAssetDownload", projectId,
                new()
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
        public async Task<FileAssetVersion[]?> GetFileAssetVersionsAsync(int projectId, Guid assetId, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new()
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
        public async Task<Guid?> ImportFileAssetAsync(int projectId, Guid assetId, CancellationToken cancellationToken = default)
        {
            Dictionary<string, object> body = new()
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

            List<KeyValuePair<string, object>> requestContent = new();
            foreach (var assetId in assetIds)
            {
                requestContent.Add(new("AssetIds[]", assetId));
            }

            requestContent.Add(new("AssetType", assetType));

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

            List<KeyValuePair<string, object>> requestContent = new();
            foreach (var assetId in assetIds)
            {
                requestContent.Add(new("AssetIds[]", assetId));
            }

            _ = await PostLcsResponseAsync<object?>("FileAsset/CopyFileAssetsToProject", projectId, null, requestContent, URL_ENCODED_CONTENTTYPE, cancellationToken);
        }

        /// <summary>
        /// Gets the list of the current user's organization methodologies
        /// </summary>
        /// <param name="request">Request as a <see cref="PaginatedRequest"/> </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Methodology[]?> GetMethodologiesAsync(CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<Methodology[]>("MethodologyManagement/RetrieveMethodologies", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of the current user's organization methodologies as a paginated response
        /// </summary>
        /// <param name="request">Request as a <see cref="PaginatedRequest"/> instance</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<Methodology[]>?> GetMethodologiesPaginated(PaginatedRequest request, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<Methodology[]>>("MethodologyManagement/RetrieveMethodologies", null, new() { { "IsScrollRequired", true } }, request, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of products available
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Product[]?> GetProductsAsync(CancellationToken cancellationToken = default)
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
        public async Task<EnvironmentAction?> GetOngoingActionDetailsAsync(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<EnvironmentAction>("EnvironmentServicingV2/GetOngoingActionDetails", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
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
            return await GetLcsResponseAsync<bool>("AddIns/IsAddinsManagementAllowed", projectId, new() { { "environmentId", environmentId } }, cancellationToken);
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
            return await GetLcsResponseAsync<bool>("RainierProject/IsServiceEnabledForProject", projectId, new() { { "serviceName", serviceName } }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of deployable package action details for the specified environment action history ID
        /// </summary>
        /// <param name="projectId"Project ID></param>
        /// <param name="lcsEnvironmentActionHistoryId"></param>
        /// <param name="showAllSteps"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeployablePackageHistoryDetails?> GetDeployablePackageHistoryDetailsAsync(int projectId, bool lcsEnvironmentActionHistoryId, bool showAllSteps = false, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DeployablePackageHistoryDetails>("Environment/GetDeployablePackageHistoryDetails", projectId, new()
            {
                { "lcsEnvironmentActionHistoryId", lcsEnvironmentActionHistoryId },
                { "showAllSteps", showAllSteps }
            }, cancellationToken);
        }

        /// <summary>
        /// Gets the list of environment actions applied to the given environment as a paginated response
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="environmentId">Environment ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginatedResponse<EnvironmentAction>?> GetEnvironmentHistoryDetails(int projectId, Guid environmentId, CancellationToken cancellationToken = default)
        {
            return await PostLcsResponseAsync<PaginatedResponse<EnvironmentAction>>("Environment/GetEnvironmentHistoryDetails", projectId, new() { { "environmentId", environmentId } }, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the list of database movement action details for the specified environment action history ID
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="lcsEnvironmentActionHistoryId">Environemtn action history ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DatabaseMovementAction?> GetDatabaseMovementHistoryDetails(int projectId, int lcsEnvironmentActionHistoryId, CancellationToken cancellationToken = default)
        {
            return await GetLcsResponseAsync<DatabaseMovementAction>("Environment/GetDatabaseMovementHistoryDetails", projectId, new() { { "lcsEnvironmentActionHistoryId", lcsEnvironmentActionHistoryId } }, cancellationToken);
        }
    }
}
