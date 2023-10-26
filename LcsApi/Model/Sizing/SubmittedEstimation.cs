namespace LcsApi.Model.Sizing
{
    public class SubmittedEstimation
    {
        public UsageAnswer[]? UsageAnswers { get; set; }
        public bool IsPrimaryEstimate { get; set; }
        public bool IsLocked { get; set; }
        public object? EstimatedTopology { get; set; }
        public int Id { get; set; }
        public int EstimateDetailId { get; set; }
        public string? Name { get; set; }
        public int EnvironmentType { get; set; }
        public string? EnvironmentDisplayName { get; set; }
        public string? EstimatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string? FullDate { get; set; }
        public int EditedEstimateDetailId { get; set; }
        public bool IsRetail { get; set; }
        public string? UsageSpreadsheetBlobLink { get; set; }
    }
}