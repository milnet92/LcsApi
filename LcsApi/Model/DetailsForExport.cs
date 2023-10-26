namespace LcsApi.Model
{
	public class DetailsForExport
    {
		public int AssetKind { get; set; }
		public Guid ComponentId { get; set; }
		public string? ProductName { get; set; }
		public string? ProductVersion { get; set; }
    }
}