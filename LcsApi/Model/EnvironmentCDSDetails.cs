namespace LcsApi.Model
{
	public class EnvironmentCDSDetails
    {
		public string? AdditionalInfoMessage { get; set; }
		public object? AdditionalResourceLinks { get; set; }
		public bool AllowCDSResume { get; set; }
		public bool AllowNewCDSConfiguration { get; set; }
		public string? CDSInstanceName { get; set; }
		public object? CurrentConfigurationState { get; set; }
		public object? DisplayErrorMessage { get; set; }
		public bool IsCDSInstanceConfigured { get; set; }
		public bool ShowProvisioningResumedMessage { get; set; }
		public bool ShowProvisioningTriggeredMessage { get; set; }
    }
}