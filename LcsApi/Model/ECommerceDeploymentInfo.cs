namespace LcsApi.Model
{
	public class ECommerceDeploymentInfo
    {
		public string? Version { get; set; }
		public string? Name { get; set; }
		public string? StartDate { get; set; }
		public string? CompletionDate { get; set; }
		public string? LastRefreshedDate { get; set; }
		public string? UserName { get; set; }
		public string? DeploymentId { get; set; }
		public string? Status { get; set; }
		public string? StatusText { get; set; }
		public bool ShowDetails { get; set; }
		public bool ShowRefreshButton { get; set; }
		public bool ShowDismissButton { get; set; }
		public bool ShowRedeployButton { get; set; }
		public bool ShowRetryInitializationButton { get; set; }
		public int PackageType { get; set; }
		public bool ShowMessage { get; set; }
		public string? StatusMessage { get; set; }
		public bool ShowSskVersion { get; set; }
		public string? SskVersion { get; set; }
		public bool ShowSdkVersion { get; set; }
		public string? SdkVersion { get; set; }
    }
}