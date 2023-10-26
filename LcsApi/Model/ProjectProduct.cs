using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class ProjectProduct
    {
		public ProductId ProductId { get; set; }
		public string? ProductName { get; set; }
		public ProductVersionId ProductVersion { get; set; }
		public string? ProductVersionName { get; set; }
    }
}