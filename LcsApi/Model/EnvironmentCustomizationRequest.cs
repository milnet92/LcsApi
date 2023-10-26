using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class EnvironmentCustomizationRequest
    {
        public string TopologyName { get; set; } = string.Empty;
        public string CatalogName { get; set; } = "AX";
        public string BuildNumber { get; set; } = "DYNAMIC";
        public string Group { get; set; } = "undefined";
        public int ConnectorId { get; set; }
        public string ApplicationVersion { get; set; } = string.Empty;
        public string ProductVersion { get; set; } = string.Empty;

        internal void EnsureRequestIsValid()
        {
            if (string.IsNullOrEmpty(TopologyName))
                throw new ArgumentException("TopologyName is required", nameof(TopologyName));

            if (string.IsNullOrEmpty(CatalogName))
                throw new ArgumentException("CatalogName is required", nameof(CatalogName));

            if (string.IsNullOrEmpty(BuildNumber))
                throw new ArgumentException("BuildNumber is required", nameof(BuildNumber));

            if (string.IsNullOrEmpty(Group))
                throw new ArgumentException("Group is required", nameof(Group));

            if (ConnectorId == 0)
                throw new ArgumentException("ConnectorId is required", nameof(ConnectorId));

            if (string.IsNullOrEmpty(ApplicationVersion))
                throw new ArgumentException("ApplicationVersion is required", nameof(ApplicationVersion));

            if (string.IsNullOrEmpty(ProductVersion))
                throw new ArgumentException("ProductVersion is required", nameof(ProductVersion));
        }
    }
}
