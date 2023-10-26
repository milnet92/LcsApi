using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class ActionDetails
    {
		public string? ActionStatusText { get; set; }
		public string? ActionType { get; set; }
		public int ActionTypeId { get; set; }
		public string? CompletionDate { get; set; }
		public int Id { get; set; }
		public bool IsPostServicing { get; set; }
		public string? Name { get; set; }
		public string? PackageAssetId { get; set; }
		public string? PackageType { get; set; }
		public int ServicingAction { get; set; }
		public string? StartDate { get; set; }
		public LcsEnvironmentActionStatus? Status { get; set; }
		public string? EnvironmentName { get; set; }
    }
}