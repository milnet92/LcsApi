namespace LcsApi.Model
{
	public class RetailSystemCheckHealth
    {
		public bool IsDatabaseHealthy { get; set; }
		public bool IsRealTimeServiceHealthy { get; set; }
		public bool IsRetailServerHealthy { get; set; }
    }
}