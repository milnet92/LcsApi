namespace LcsApi.Model
{
	public class Connector
    {
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? AzureSubscriptionId { get; set; }
		public string? DisplayAzureSubscriptionId { get; set; }
		public string? Location { get; set; }
		public string? DisplayLocation { get; set; }
		public bool IsDefault { get; set; }
		public int ConnectorType { get; set; }
		public bool IsTenantRegistered { get; set; }
		public bool IsArmEnabled { get; set; }
		public string? AzureSubscriptionAADTenantId { get; set; }
		public int CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ModifiedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
    }
}