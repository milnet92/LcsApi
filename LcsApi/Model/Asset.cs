namespace LcsApi.Model
{
	public class Asset
    {
		public bool? CanDelete { get; set; }
		public bool? CanNavigate { get; set; }
		public bool? CanPublish { get; set; }
		public bool? CanUpdate { get; set; }
		public string? CreatedByName { get; set; }
		public string? Description { get; set; }
		public string? DisplayCreatedDate { get; set; }
		public string? DisplayState { get; set; }
		public string? DisplayScope { get; set; }
		public string? FileDescription { get; set; }
		public string? FileName { get; set; }
		public Guid Id { get; set; }
		public bool? IsInvalid { get; set; }
		public string? Location { get; set; }
		public string? Name { get; set; }
		public string? ValidationStatusText { get; set; }
		public int? ValidationStatus { get; set; }
		public int? Version { get; set; }
		public string? DisplayModifiedDate { get; set; }
		public string? ModifiedByName { get; set; }
		public string? LocalCreatedDate { get; set; }
		public string? LocalModifiedDate { get; set; }
    }
}