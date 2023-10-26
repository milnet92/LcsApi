namespace LcsApi.Model
{
	public class CDSDeploymentDetails
    {
		public int CurrentConfigurationState { get; set; }
		public string? AdditionalInfoMessage { get; set; }
		public string? CDSInstanceName { get; set; }
		public string? CDSEnvironmentId { get; set; }
		public string? CDSInstanceUri { get; set; }
		public bool AllowNewCDSConfiguration { get; set; }
		public bool AllowCDSResume { get; set; }
		public bool AllowDualWriteSetup { get; set; }
		public bool ShowProvisioningTriggeredMessage { get; set; }
		public bool ShowProvisioningResumedMessage { get; set; }
		public bool ShowCdsInfoMisMatchMessage { get; set; }
		public bool ShowCdsInfoMissingOnCHEMessage { get; set; }
		public bool ShowCdsInfoMissingOnNonCHEMessage { get; set; }
		public object? CdsInfoMisMatchMessage { get; set; }
		public object? CdsInfoMissingOnNonCHEMessage { get; set; }
		public bool IsCDSInstanceConfigured { get; set; }
		public string? DisplayErrorMessage { get; set; }
    }
}