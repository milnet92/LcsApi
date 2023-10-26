namespace LcsApi.Model
{
	public class ProjectUserCapabilities
    {
		public bool IsDriRole { get; set; }
		public bool IsDseRole { get; set; }
		public bool IsEnvironmentAdmin { get; set; }
		public bool IsNonMaintainUserRole { get; set; }
		public bool IsNonPrivilegedDseRole { get; set; }
		public bool IsPrivilegedDseRole { get; set; }
		public bool IsProjectOwner { get; set; }
		public int UserRole { get; set; }
		public string? UserRoleDisplayText { get; set; }
    }
}