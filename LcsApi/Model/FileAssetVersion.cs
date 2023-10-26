using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class FileAssetVersion
    {
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? FileDescription { get; set; }
        public string? DisplaySize { get; set; }
        public int CommitStatus { get; set; }
        public int State { get; set; }
        public int Scope { get; set; }
        public object? FileLocation { get; set; }
        public int Version { get; set; }
        public int FileType { get; set; }
        public object? CreatedByName { get; set; }
        public string? ModifiedByName { get; set; }
        public bool IsGoldBuild { get; set; }
        public object? DataPackageApplicationDetails { get; set; }
        public int ValidationStatus { get; set; }
        public string? AadTenantId { get; set; }
        public string? ValidationStatusText { get; set; }
        public object? NextValidationDate { get; set; }
        public int NumValidationAttempts { get; set; }
        public int NumTenantTaggingAttempts { get; set; }
        public object? ReleaseDetailsAssetId { get; set; }
        public FileAssetProperty[]? FileAssetProperties { get; set; }
        public bool IsMockData { get; set; }
        public object? ReleaseDetailsLink { get; set; }
        public string? ParentAssetId { get; set; }
        public bool IsInvalid { get; set; }
        public string? DisplayValidationSymbol { get; set; }
        public string? DisplayModifiedDate { get; set; }
        public string? DisplayCreatedDate { get; set; }
        public object? DisplayId { get; set; }
        public string? Name { get; set; }
        public object? Description { get; set; }
        public string? DisplayScope { get; set; }
        public string? DisplayState { get; set; }
        public string? Location { get; set; }
        public bool IsAbsoluteLocation { get; set; }
        public bool CanDelete { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanPublish { get; set; }
        public bool CanNavigate { get; set; }
        public string? DisplayVersion { get; set; }
        public int OriginalScope { get; set; }
        public object? DisplayOriginalScope { get; set; }
        public object[]? DisplayMessages { get; set; }
        public string? TelemetryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? LocalCreatedDate { get; set; }
        public string? LocalModifiedDate { get; set; }
    }
}
