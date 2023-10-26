namespace LcsApi.Model
{
	public class ServicingInfo
    {
		public string? Title { get; set; }
		public string? ActivityId { get; set; }
		public string? StartInformation { get; set; }
		public bool IsCompleted { get; set; }
		public string? CompletedInformation { get; set; }
		public string? LastRefreshedInformation { get; set; }
		public string? BaseVersion { get; set; }
		public string? BaseVersionSemanticVersion { get; set; }
		public string? CustomizationName { get; set; }
		public string? CustomizationFileId { get; set; }
		public int Status { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public object? StatusMessage { get; set; }
		public bool ShowProgressBar { get; set; }
		public double ProgressPercent { get; set; }
		public string? CurrentStep { get; set; }
		public bool ShowSpinner { get; set; }
		public bool ShowErrorIcon { get; set; }
		public bool ShowSuccessfulIcon { get; set; }
		public bool ShowRefreshButton { get; set; }
		public bool ShowDismissButton { get; set; }
		public bool ShowRollbackButton { get; set; }
		public bool ShowSignOffButton { get; set; }
		public bool ShowSeeErrorsButton { get; set; }
		public bool ShowMessage { get; set; }
		public bool ShowChooseAnotherPackageButton { get; set; }
		public bool ShowRetryButton { get; set; }
		public bool ShowVersionAndExtensionInfo { get; set; }
    }
}