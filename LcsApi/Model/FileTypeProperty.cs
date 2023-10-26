namespace LcsApi.Model
{
	public class FileTypeProperty
    {
		public int FileTypeId { get; set; }
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public bool IsVisibleInAssetLibrary { get; set; }
		public bool IsUserInput { get; set; }
		public string? PropertyName { get; set; }
		public int PropertyType { get; set; }
    }
}