namespace LcsApi.Model
{
	public class HostedInstance
    {
		public DeploymentInstance[]? DeploymentInstances { get; set; }
		public string? DeploymentSkuName { get; set; }
		public int DisplayOrder { get; set; }
		public object? TopologyName { get; set; }
    }
}