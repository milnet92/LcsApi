using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class DeploymentInstance
    {
		public string? AzureSubscriptionId { get; set; }
		public object? BuildNumber { get; set; }
		public object? CatalogName { get; set; }
		public int ConnectorId { get; set; }
		public DeploymentEnvironmentType DeploymentEnvironmentType { get; set; }
		public string? DeploymentHealthSummary { get; set; }
		public int DeploymentSkuId { get; set; }
		public string? DeploymentSkuType { get; set; }
		public bool EnableDeleteEnvironmentDashboardButton { get; set; }
		public bool EnableRefreshEnvironmentHealthStateButton { get; set; }
		public Guid EnvironmentId { get; set; }
		public string? InstanceId { get; set; }
		public bool IsAvailableForConfiguration { get; set; }
		public bool IsDeployed { get; set; }
		public bool IsDiagnosticsEnabled { get; set; }
		public bool IsFreeTier1Suppressed { get; set; }
		public bool IsHealthy { get; set; }
		public bool IsNotConfigured { get; set; }
		public bool IsTier1LeaseAvailable { get; set; }
		public bool IsTopologyLoadError { get; set; }
		public bool IsTopologySignedOff { get; set; }
		public bool ShowFullDetailsLink { get; set; }
		public bool ShowLastUpdateReceivedDate { get; set; }
		public bool ShowReconfigureOption { get; set; }
		public object? TopologyDisplayName { get; set; }
		public object? TopologyId { get; set; }
		public object? TopologyName { get; set; }
		public object? TopologyType { get; set; }
		public object? TopologyVersion { get; set; }
    }
}