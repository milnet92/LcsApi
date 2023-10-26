namespace LcsApi.Model
{
	public class AssetMetadata
    {
		public int AssetKind { get; set; }
		public string? AssetTypeName { get; set; }
		public string? AssetTypePluralName { get; set; }
		public int Category { get; set; }
		public bool IsAddBtnVisible { get; set; }
		public bool IsDeleteBtnVisible { get; set; }
		public bool IsEditBtnVisible { get; set; }
		public bool IsGoldBuildBtnVisible { get; set; }
		public bool IsImportBtnVisible { get; set; }
		public bool IsSaveToMyLibraryBtnVisible { get; set; }
		public bool IsVersionBtnVisible { get; set; }
		public string?[]? Extensions { get; set; }
		public string? Product { get; set; }
		public string? ProductVersion { get; set; }
		public FileTypeProperty[]? FileTypeProperties { get; set; }
		public Asset[]? Assets { get; set; }

    }
}