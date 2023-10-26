namespace LcsApi.Model
{
	public class ProductVersion
    {
		public SupportedPlatformVersion[]? SupportedPlatformVersions { get; set; }
		public string? Identifier { get; set; }
		public string? DisplayName { get; set; }
		public int OrdinalValue { get; set; }
    }
}