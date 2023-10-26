namespace LcsApi.Model
{
	public class OneVersionViewVersion
    {
		public string? ReleaseDisplayName { get; set; }
		public string? ReleaseDisplayVersion { get; set; }
		public int Ring { get; set; }
		public int HotfixCount { get; set; }
		public bool UpdatesAreAvaliable { get; set; }
    }
}