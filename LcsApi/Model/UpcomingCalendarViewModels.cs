namespace LcsApi.Model
{
	public class UpcomingCalendarViewModels
    {
		public string? EnvironmentName { get; set; }
		public int StatusEnum { get; set; }
		public int EventNameEnum { get; set; }
		public int CalendarId { get; set; }
		public string? UtcStartDateTime { get; set; }
		public string? EnvironmentId { get; set; }
		public string? Month { get; set; }
		public string? Date { get; set; }
		public string? Time { get; set; }
		public int DownTimeInMinutes { get; set; }
		public string? EventName { get; set; }
		public string? Status { get; set; }
		public bool IsModified { get; set; }
		public int WorkflowInstanceId { get; set; }
    }
}