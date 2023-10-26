namespace LcsApi.Model
{
	public class EnvironmentDeployTopologyValue
    {
		public string? DisplayName { get; set; }
		public string? Description { get; set; }
		public string? HeaderText { get; set; }
		public bool IsDownloadGroup { get; set; }
		public TopologyValue[]? Values { get; set; }
    }
}