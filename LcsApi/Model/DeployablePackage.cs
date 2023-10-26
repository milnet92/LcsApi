namespace LcsApi.Model
{
	public class DeployablePackage
    {
		public string? AppVersion { get; set; }
		public string? Description { get; set; }
		public string? EstimatedDuration { get; set; }
		public int FileAssetDisplayVersion { get; set; }
		public int LcsEnvironmentActionId { get; set; }
		public string? LcsEnvironmentId { get; set; }
		public string? ModifiedBy { get; set; }
		public string? ModifiedDate { get; set; }//Todo
		public string? Name { get; set; }
		public string? PackageId { get; set; }
		public string? PackageType { get; set; }
		public string? PlatformVersion { get; set; }
		public string? Publisher { get; set; }
		public string? Scope { get; set; }
    }
}