namespace LcsApi.Model
{
	public class RetailEnvironment
    {
		public ScaleUnit[] ScaleUnits { get; set; }
		public string EnvironmentName { get; set; }
		public bool IsDiagnosticsEnabled { get; set; }
		public bool IsCloudEnvironment { get; set; }
		public bool IsMultiScaleEnabled { get; set; }
		public string AosEndpoint { get; set; }
		public string AssetLibraryEndpoint { get; set; }
		public string Region { get; set; }
    }
}