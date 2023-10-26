namespace LcsApi.Model
{
	public class TenantPlanDetails
    {
		public string? TenantName { get; set; }
		public string? TenantId { get; set; }
		public Plan[]? Plans { get; set; }
		public SandboxAddon[]? SandboxAddons { get; set; }
		public bool ShowSandboxAddonsGrid { get; set; }
    }
}