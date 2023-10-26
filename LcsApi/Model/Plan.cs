namespace LcsApi.Model
{
	public class Plan
    {
		public string? ServicePlanName { get; set; }
		public string? ServicePlanId { get; set; }
		public string? DisplayAssignedDate { get; set; }
		public DateTime AssignedDateTime { get; set; }
		public int PrepaidUnitsQuantity { get; set; }
		public string? PlanStatus { get; set; }
		public string? PlanType { get; set; }
    }
}