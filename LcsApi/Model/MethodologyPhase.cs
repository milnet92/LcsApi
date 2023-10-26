using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class MethodologyPhase
    {
		public string? Description { get; set; }
		public string? MilestoneDescription { get; set; }
		public string? MilestoneEndDate { get; set; }
		public string? MilestoneStartDate { get; set; }
		public MilestoneStatus MilestoneStatus { get; set; }
		public int PhaseId { get; set; }
		public string? MilestoneName { get; set; }
		public string? EndLabelDate { get; set; }
		public string? Name { get; set; }
		public MilestoneStatus Status { get; set; }
    }
}