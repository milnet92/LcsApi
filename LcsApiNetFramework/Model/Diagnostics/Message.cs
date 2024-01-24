using System;

namespace LcsApi.Model.Diagnostics
{
    public class Message
    {
        public AdditionalInfo[] AdditionalInfo { get; set; }
        public object AntecedentGroups { get; set; }
        public string AppRoleName { get; set; }
        public string CollectorGroup { get; set; }
        public object ConsequentClauseVariable { get; set; }
        public string ErrorCategory { get; set; }
        public EvalRuleLog EvalRuleLog { get; set; }
        public bool ExecutionStatus { get; set; }
        public bool HasPassed { get; set; }
        public string HostInstance { get; set; }
        public int Id { get; set; }
        public int IssueMessageCondition { get; set; }
        public Module Module { get; set; }
        public string Name { get; set; }
        public string Observation { get; set; }
        public object ProductVersions { get; set; }
        public string QueryText { get; set; }
        public string Recommendation { get; set; }
        public Report Report { get; set; }
        public int ResourceTypeId { get; set; }
        public object ResultDateTime { get; set; }
        public int RuleFailedSeverityErrorCount { get; set; }
        public int RuleFailedSeverityInformationalCount { get; set; }
        public int RuleFailedSeverityWarningCount { get; set; }
        public int RulePassedCount { get; set; }
        public string RuleResult { get; set; }
        public int RuleUnknownCount { get; set; }
        public bool ShowRule { get; set; }
        public DateTime UploadTimeUTC { get; set; }
    }
}