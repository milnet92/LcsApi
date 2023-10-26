namespace LcsApi.Model
{
	public class ECommerceEnvironment
    {
		public Dictionary<string, string?>? CsuDetails { get; set; }
		public bool IsEnabled { get; set; }
		public string? EcommerceSiteLink { get; set; }
		public string? SiteManagementToolLink { get; set; }
		public string? TenantName { get; set; }
		public bool IsRnREnabled { get; set; }
		public ECommerceDeploymentInfo? LastSuccessfulDeployment { get; set; }
		public ECommerceDeploymentInfo? InProgressDeployment { get; set; }
		public object? ProvisioningErrorMessages { get; set; }
		public bool IsDeleteEnabled { get; set; }
		public bool IsSupported { get; set; }
		public bool IsProductionEnvironment { get; set; }
		public object? EcommerceNotSupportedMessage { get; set; }
		public string? EcommerceGeo { get; set; }
		public string? CustomDomains { get; set; }
		public bool ShowInsufficientLicensesError { get; set; }
		public bool ShowLicenseWarningMessage { get; set; }
		public bool IsUserError { get; set; }
		public object? Message { get; set; }
		public object? ErrorCodes { get; set; }
    }
}