namespace LcsApi.Model
{
	public class Report
    {
		public string[]? CollectorNames { get; set; }
		public int Id { get; set; }
		public bool IsOnReportPage { get; set; }
		public string? QueryText { get; set; }
		public object? ReportPageUrl { get; set; }
		public string? Title { get; set; }
    }
}