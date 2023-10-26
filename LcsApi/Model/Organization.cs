using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class Organization
    {
		public string? ADTenantId { get; set; }
		public int ExternalId { get; set; }
		public bool IsTemporary { get; set; }
		public object? LicenseSerialNumber { get; set; }
		public string? Name { get; set; }
		public int OrgId { get; set; }
		public string? TelemetryId { get; set; }
		public OrganizationType Type { get; set; }
    }
}