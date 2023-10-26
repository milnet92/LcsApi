namespace LcsApi.Model
{
	public class EnvironmentDeployTopology
    {
		public string? DisplayName { get; set; }
		public string? Description { get; set; }
		public string? HeaderText { get; set; }
		public bool IsDownloadGroup { get; set; }
		public EnvironmentDeployTopologyValue[]? Values { get; set; }
    }
}