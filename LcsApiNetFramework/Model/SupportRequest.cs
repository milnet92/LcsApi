using System;

namespace LcsApi.Model
{
	public class SupportRequest
    {
		public string SupportRequestNumber { get; set; }
		public string VsoId { get; set; }
		public string VstsDeepLink { get; set; }
		public string Title { get; set; }
		public string Status { get; set; }
		public string DateCreatedLocalized { get; set; }
		public string CreatedBy { get; set; }
		public string IncidentType { get; set; }
		public string PlanType { get; set; }
		public bool IsHyperlink { get; set; }
		public DateTime DateCreatedUtc { get; set; }
		public string MsSolveLink { get; set; }
		public object IssueSearchLink { get; set; }
		public object ResolutionProgressLabel { get; set; }
		public int ProjectId { get; set; }
		public string ProjectLink { get; set; }
		public string ProjectName { get; set; }
    }
}