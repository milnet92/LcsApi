using System;

namespace LcsApi.Model
{
	public class EnvironmentAction
    {
		public string ActionStatusText { get; set; }
		public string ActionType { get; set; }
		public int ActionTypeId { get; set; }
		public bool CanCancelOngoingOperation { get; set; }
		public long Id { get; set; }
		public bool IsPostServicing { get; set; }
		public string Name { get; set; }
		public Guid? PackageAssetId { get; set; }
		public string PackageType { get; set; }
		public int Status { get; set; }
		public int? ServicingAction { get; set; }
		public string StartDate { get; set; }
		public string CompletionDate { get; set; }
    }
}