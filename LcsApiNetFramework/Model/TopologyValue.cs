namespace LcsApi.Model
{
	public class TopologyValue
    {
		public string TopologyId { get; set; }
		public string CatalogName { get; set; }
		public string TopologyName { get; set; }
		public string TopologyType { get; set; }
		public string ProductName { get; set; }
		public string BuildNumber { get; set; }
		public int TopologyVersion { get; set; }
		public string GroupName { get; set; }
		public string GroupDescription { get; set; }
		public bool HasDownloadLinks { get; set; }
		public string GroupKeys { get; set; }
		public bool IsArmEnabled { get; set; }
    }
}