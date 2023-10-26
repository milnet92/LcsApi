namespace LcsApi.Model
{
	public class EvalRuleLog
    {
		public int Id { get; set; }
		public int ProcessingLogId { get; set; }
		public string? RuleResult { get; set; }
		public DateTime SetValueDateTime { get; set; }
    }
}