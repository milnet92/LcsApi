namespace LcsApi.Model
{
	public class ExportedInstance
    {
		public string BuildInfo { get; set; }
		public string CurrentApplicationBuildVersion { get; set; }
		public string CurrentApplicationReleaseName { get; set; }
		public string CurrentPlatformReleaseName { get; set; }
		public string CurrentPlatformVersion { get; set; }
		public string DeploymentStatus { get; set; }
		public string EnvironmentId { get; set; }
		public string HostingType { get; set; }
		public string InstanceName { get; set; }
		public string Organization { get; set; }
		public string ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string TopologyName { get; set; }
		public string TopologyType { get; set; }
		public string TopologyVersion { get; set; }
    }
}