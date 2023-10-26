namespace LcsApi.Model
{
	public class BuildInfoDetails
    {
		public BuildInfoTreeView[]? BuildInfoTreeView { get; set; }
		public string? BuildVersion { get; set; }
		public string? InstalledPlatformBuild { get; set; }
    }
}