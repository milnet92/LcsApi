namespace LcsApi.Model
{
	public class Credentials
    {
		public string? CredentialInfoKey { get; set; }
		public string? DeploymentItemName { get; set; }
		public string? InstanceName { get; set; }
		public bool IsCredentialKeyVaultUri { get; set; }
		public bool IsPasswordExpired { get; set; }
		public string? Password { get; set; }
		public string? PasswordExpiryTime { get; set; }
		public string? ReasonForAccess { get; set; }
		public string? ReasonForAccessDetails { get; set; }
		public string? SymbolicName { get; set; }
		public string? UserName { get; set; }
    }
}