using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class CloudHostedInstance
    {
		public Guid? ActivityId { get; set; }
		public Guid? AzureSubscriptionId { get; set; }
		public string? BuildInfo { get; set; }
		public string? BuildNumber { get; set; }
		public bool CanApplyUpdatesToUpgradeEnvironment { get; set; }
		public bool CanCleanup { get; set; }
		public bool CanDeallocate { get; set; }
		public bool CanDelete { get; set; }
		public bool CanDseCreateStaging { get; set; }
		public bool CanEdit { get; set; }
		public bool CanEnableDR { get; set; }
		public bool CanFailback { get; set; }
		public bool CanFailover { get; set; }
		public bool CanMarkUpgradeComplete { get; set; }
		public bool CanRestart { get; set; }
		public bool CanRollbackUpgradeEnvironment { get; set; }
		public bool CanShowAzureConnector { get; set; }
		public bool CanShowLoginButton { get; set; }
		public bool CanShowNavigationLinks { get; set; }
		public bool CanShowRdp { get; set; }
		public bool CanShowSqlEnableAccess { get; set; }
		public bool CanShowStagingEnvironmentId { get; set; }
		public bool CanShowTrialLink { get; set; }
		public bool CanStart { get; set; }
		public bool CanStop { get; set; }
		public bool CanUpgradeEnvironmentDatabase { get; set; }
		public string? CatalogName { get; set; }
		public object? ClientInstances { get; set; }
		public string?[]? CloudServiceNames { get; set; }
		public string? CloudStorageLocation { get; set; }
		public string? CloudStorageLocationLabel { get; set; }
		public string? ConnectorId { get; set; }
		public string? ConnectorName { get; set; }
		public Credentials[]? ContosoCredentials { get; set; }
		public string? CurrentApplicationBuildVersion { get; set; }
		public string? CurrentApplicationReleaseName { get; set; }
		public string? CurrentPlatformReleaseName { get; set; }
		public string? CurrentPlatformVersion { get; set; }
		public string? DeployedBy { get; set; }
		public string? DeployedOn { get; set; }//Todo
		public string? DeploymentAction { get; set; }
		public int DeploymentErrorCode { get; set; }
		public string? DeploymentId { get; set; }
		public DeploymentState? DeploymentState { get; set; }
		public string? DeploymentStatus { get; set; }
		public object? DevOpsDetails { get; set; }
		public string? DevTestEnvironmentType { get; set; }
		public string? DisasterRecoveryLocation { get; set; }
		public string? DisasterRecoveryLocationLabel { get; set; }
		public string? DisplayName { get; set; }
		public string? EnvironmentAdmin { get; set; }
		public EnvironmentCDSDetails? EnvironmentCDSDetails { get; set; }
		public Guid? EnvironmentId { get; set; }
		public string? EnvironmentName { get; set; }
		public EnvironmentNotifications? EnvironmentNotifications { get; set; }
		public object? Errors { get; set; }
		public bool HasStagingEnvironment { get; set; }
		public string? InstanceId { get; set; }
		public InstanceReference[]? Instances { get; set; }
		public DeploymentAction? InternalDeploymentAction { get; set; }
		public DeploymentStatus? InternalDeploymentStatus { get; set; }
		public bool IsARMTopology { get; set; }
		public bool IsDiagnosticsEnabledEnvironment { get; set; }
		public bool IsEnableMaintenanceMode { get; set; }
		public bool IsGuidelinesLinkVisible { get; set; }
		public bool IsHistoryVisible { get; set; }
		public bool IsInitialDeploymentState { get; set; }
		public bool IsMaintainVisible { get; set; }
		public bool IsManualUpgradeInProgress { get; set; }
		public bool IsNotificationListVisible { get; set; }
		public bool IsPinToD365Enabled { get; set; }
		public bool IsPinToD365Visible { get; set; }
		public bool IsPreparationFailed { get; set; }
		public bool IsPublishedToD365 { get; set; }
		public bool IsSandboxUpgradeEnvironment { get; set; }
		public bool IsServicingEstimationEnabled { get; set; }
		public bool IsStagingDeploymentFailed { get; set; }
		public bool IsStagingDeploymentSucceeded { get; set; }
		public bool IsUpgradeSelfServeCancelledOrCompleted { get; set; }
		public bool IsUpgradeSelfServeInProgress { get; set; }
		public bool IsUpgradeTimeExpired { get; set; }
		public object? JITExpireTimeRemaining { get; set; }
		public JITOptions[]? JITOptions { get; set; }
		public JITRequestAccessEnabledState JITRequestAccessEnabledState { get; set; }
		public object? JITRequestActivityId { get; set; }
		public bool JITRequestShowError { get; set; }
		public object? JITWorkItemDetails { get; set; }
		public string? LicenseLink { get; set; }
		public Credentials[]? LocalCredentials { get; set; }
		public object? Location { get; set; }
		public object? LogOnDetails { get; set; }
		public Navigationlink[]? NavigationLinks { get; set; }
		public string? ProductName { get; set; }
		public string? ProductRegisteredName { get; set; }
		public object? RdsFarmAccessRdp { get; set; }
		public object? RdsWebAccessCertificate { get; set; }
		public object? RdsWebAccessLink { get; set; }
		public RefinedEnvironmentType? RefinedEnvironmentType { get; set; }
		public string? ResourceGroupName { get; set; }
		public SaasEnvironmentType? SaasEnvironmentType { get; set; }
		public object? ServiceIds { get; set; }
		public bool ShowRetailComponents { get; set; }
		public bool ShowSslCertRotateWarning { get; set; }
		public bool ShowUpgradeEnvironmentDetails { get; set; }
		public Credentials[]? SqlAzureCredentials { get; set; }
		public System.Guid StagingActivityId { get; set; }
		public string? StagingDeployedBy { get; set; }
		public string? StagingDeployedOn { get; set; }//Todo
		public string? StagingEnvironmentAdministrator { get; set; }
		public string? StagingEnvironmentId { get; set; }
		public string? StagingPrimaryRegion { get; set; }
		public string? StagingSecondaryRegion { get; set; }
		public string? StagingTargetVersion { get; set; }
		public string? TimeForUpgradeText { get; set; }
		public string? TopologyDescription { get; set; }
		public string? TopologyDisplayName { get; set; }
		public string? TopologyId { get; set; }
		public string? TopologyName { get; set; }
		public string? TopologyType { get; set; }
		public string? TopologyVersion { get; set; }
		public UpgradeEnvironmentStatus? UpgradeEnvironmentStatus { get; set; }
		public int VirtualMachineCount { get; set; }
		public object? Warnings { get; set; }
    }
}