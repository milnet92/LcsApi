using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class ProjectOrganization
    {
        public int OrgId { get; set; }
        public int ExternalId { get; set; }
        public string? Name { get; set; }
        public bool IsTemporary { get; set; }
        public bool HasVoiceExpired { get; set; }
        public string? VoiceExpiredMessage { get; set; }
        public string? OrganizationType { get; set; }
        public string? VoiceIdDisplay { get; set; }
        public string? LicenseSerialNumber { get; set; }
        public Guid? TenantId { get; set; }
    }
}
