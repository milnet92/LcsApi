using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class Methodology
    {
        public MethodologyMasterTemplateMapValue[]? MethodologyMasterTemplateMapValues { get; set; }
        public string? GraphId { get; set; }
        public object? BetaFeatureId { get; set; }
        public int Scope { get; set; }
        public bool IsMasterTemplate { get; set; }
        public object[]? OrgMethodologyMaps { get; set; }
        public object[]? Workflow { get; set; }
        public MethodologyProduct[]? MethodologyProduct { get; set; }
        public MethodologyMasterTemplate? MethodologyMasterTemplate { get; set; }
        public string? Description { get; set; }
        public object[]? Resources { get; set; }
        public object[]? Pins { get; set; }
        public object? EntityStatus { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TelemetryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public object? LocalCreatedDate { get; set; }
        public object? LocalModifiedDate { get; set; }
    }
}
