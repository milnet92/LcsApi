using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class ErrorEvent
    {
        [JsonPropertyName("TIMESTAMP")]
        public DateTime TIMESTAMP { get; set; }

        [JsonPropertyName("PreciseTimeStamp")]
        public DateTime PreciseTimeStamp { get; set; }

        [JsonPropertyName("Tenant")]
        public string? Tenant { get; set; }

        [JsonPropertyName("Role")]
        public string? Role { get; set; }

        [JsonPropertyName("RoleInstance")]
        public string? RoleInstance { get; set; }

        [JsonPropertyName("ClusterName")]
        public string? ClusterName { get; set; }

        [JsonPropertyName("ClusterNodeName")]
        public string? ClusterNodeName { get; set; }

        [JsonPropertyName("ContainerName")]
        public string? ContainerName { get; set; }

        [JsonPropertyName("Level")]
        public int? Level { get; set; }

        [JsonPropertyName("ProviderGuid")]
        public string? ProviderGuid { get; set; }

        [JsonPropertyName("ProviderName")]
        public string? ProviderName { get; set; }

        [JsonPropertyName("EventId")]
        public int? EventId { get; set; }

        [JsonPropertyName("Pid")]
        public int? Pid { get; set; }

        [JsonPropertyName("Tid")]
        public int? Tid { get; set; }

        [JsonPropertyName("OpcodeName")]
        public string? OpcodeName { get; set; }

        [JsonPropertyName("KeywordName")]
        public string? KeywordName { get; set; }

        [JsonPropertyName("TaskName")]
        public string? TaskName { get; set; }

        [JsonPropertyName("ChannelName")]
        public string? ChannelName { get; set; }

        [JsonPropertyName("EventMessage")]
        public string? EventMessage { get; set; }

        [JsonPropertyName("ActivityId")]
        public string? ActivityId { get; set; }

        [JsonPropertyName("EventVersion")]
        public int? EventVersion { get; set; }

        [JsonPropertyName("LevelName")]
        public string? LevelName { get; set; }

        [JsonPropertyName("RelatedActivityId")]
        public string? RelatedActivityId { get; set; }

        [JsonPropertyName("eventGroupId")]
        public int? EventGroupId { get; set; }

        [JsonPropertyName("eventTimestamp")]
        public DateTime EventTimestamp { get; set; }

        [JsonPropertyName("formName")]
        public string? FormName { get; set; }

        [JsonPropertyName("formUniqueId")]
        public int? FormUniqueId { get; set; }

        [JsonPropertyName("performanceEvent")]
        public object? PerformanceEvent { get; set; }

        [JsonPropertyName("targetName")]
        public string? TargetName { get; set; }

        [JsonPropertyName("targetType")]
        public string? TargetType { get; set; }

        [JsonPropertyName("duration")]
        public object? Duration { get; set; }

        [JsonPropertyName("responseTextStatus")]
        public string? ResponseTextStatus { get; set; }

        [JsonPropertyName("responseHTTPStatus")]
        public object? ResponseHTTPStatus { get; set; }

        [JsonPropertyName("requestTimeoutMilliseconds")]
        public object? RequestTimeoutMilliseconds { get; set; }

        [JsonPropertyName("requestRetryCount")]
        public object? RequestRetryCount { get; set; }

        [JsonPropertyName("browserSessionActivityId")]
        public string? BrowserSessionActivityId { get; set; }

        [JsonPropertyName("readyState")]
        public object? ReadyState { get; set; }

        [JsonPropertyName("originalEventTimestamp")]
        public object? OriginalEventTimestamp { get; set; }

        [JsonPropertyName("SourceNamespace")]
        public string? SourceNamespace { get; set; }

        [JsonPropertyName("SourceMoniker")]
        public string? SourceMoniker { get; set; }

        [JsonPropertyName("SourceVersion")]
        public string? SourceVersion { get; set; }

        [JsonPropertyName("errorId")]
        public int? ErrorId { get; set; }

        [JsonPropertyName("errorType")]
        public int? ErrorType { get; set; }

        [JsonPropertyName("errorLocation")]
        public int? ErrorLocation { get; set; }

        [JsonPropertyName("errorLabel")]
        public string? ErrorLabel { get; set; }

        [JsonPropertyName("callStack")]
        public string? CallStack { get; set; }

        [JsonPropertyName("statusCode")]
        public int? StatusCode { get; set; }

        [JsonPropertyName("ClentRestrictedNetwork")]
        public object? ClentRestrictedNetwork { get; set; }

        [JsonPropertyName("sessionAction")]
        public object? SessionAction { get; set; }

        [JsonPropertyName("userAgent")]
        public string? UserAgent { get; set; }

        [JsonPropertyName("operatingSystem")]
        public string? OperatingSystem { get; set; }

        [JsonPropertyName("platform")]
        public string? Platform { get; set; }

        [JsonPropertyName("device")]
        public string? Device { get; set; }

        [JsonPropertyName("cpuClass")]
        public string? CpuClass { get; set; }

        [JsonPropertyName("browserName")]
        public string? BrowserName { get; set; }

        [JsonPropertyName("browserVersion")]
        public string? BrowserVersion { get; set; }

        [JsonPropertyName("touchEnabled")]
        public object? TouchEnabled { get; set; }

        [JsonPropertyName("screenResolution")]
        public string? ScreenResolution { get; set; }

        [JsonPropertyName("viewPortSize")]
        public string? ViewPortSize { get; set; }

        [JsonPropertyName("browserLanguage")]
        public string? BrowserLanguage { get; set; }

        [JsonPropertyName("osLanguage")]
        public string? OsLanguage { get; set; }

        [JsonPropertyName("applicationLanguage")]
        public string? ApplicationLanguage { get; set; }

        [JsonPropertyName("locale")]
        public string? Locale { get; set; }

        [JsonPropertyName("density")]
        public string? Density { get; set; }

        [JsonPropertyName("theme")]
        public string? Theme { get; set; }

        [JsonPropertyName("clientVersion")]
        public string? ClientVersion { get; set; }

        [JsonPropertyName("roundTripTime")]
        public object? RoundTripTime { get; set; }

        [JsonPropertyName("query")]
        public string? Query { get; set; }

        [JsonPropertyName("targetIndex")]
        public object? TargetIndex { get; set; }

        [JsonPropertyName("targetMenuItemDescription")]
        public string? TargetMenuItemDescription { get; set; }

        [JsonPropertyName("ControlName")]
        public string? ControlName { get; set; }

        [JsonPropertyName("CommandName")]
        public string? CommandName { get; set; }

        [JsonPropertyName("failureMessage")]
        public string? FailureMessage { get; set; }

        [JsonPropertyName("formControlName")]
        public string? FormControlName { get; set; }

        [JsonPropertyName("className")]
        public string? ClassName { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("errorCode")]
        public object? ErrorCode { get; set; }

        [JsonPropertyName("targetPath")]
        public string? TargetPath { get; set; }

        [JsonPropertyName("itemCount")]
        public object? ItemCount { get; set; }

        [JsonPropertyName("action")]
        public string? Action { get; set; }

        [JsonPropertyName("actionEvent")]
        public object? ActionEvent { get; set; }

        [JsonPropertyName("inputType")]
        public object? InputType { get; set; }

        [JsonPropertyName("userDefined1")]
        public object? UserDefined1 { get; set; }

        [JsonPropertyName("userDefined2")]
        public object? UserDefined2 { get; set; }

        [JsonPropertyName("extendedData")]
        public string? ExtendedData { get; set; }

        [JsonPropertyName("workspaceName")]
        public string? WorkspaceName { get; set; }

        [JsonPropertyName("pageName")]
        public string? PageName { get; set; }

        [JsonPropertyName("actionName")]
        public string? ActionName { get; set; }

        [JsonPropertyName("currentRequestType")]
        public string? CurrentRequestType { get; set; }

        [JsonPropertyName("systemCallDurationInMilliSeconds")]
        public object? SystemCallDurationInMilliSeconds { get; set; }

        [JsonPropertyName("appCallDurationInMilliSeconds")]
        public object? AppCallDurationInMilliSeconds { get; set; }

        [JsonPropertyName("methodName")]
        public string? MethodName { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("jsonInfo")]
        public string? JsonInfo { get; set; }

        [JsonPropertyName("userGuid")]
        public string? UserGuid { get; set; }

        [JsonPropertyName("LegalEntity")]
        public object? LegalEntity { get; set; }

        [JsonPropertyName("appId")]
        public string? AppId { get; set; }

        [JsonPropertyName("ComponentName")]
        public string? ComponentName { get; set; }

        [JsonPropertyName("exceptionMessage")]
        public string? ExceptionMessage { get; set; }

        [JsonPropertyName("exceptionType")]
        public string? ExceptionType { get; set; }

        [JsonPropertyName("exceptionStackTrace")]
        public string? ExceptionStackTrace { get; set; }

        [JsonPropertyName("exceptionIsNested")]
        public object? ExceptionIsNested { get; set; }

        [JsonPropertyName("feedbackType")]
        public object? FeedbackType { get; set; }

        [JsonPropertyName("feedbackText")]
        public string? FeedbackText { get; set; }

        [JsonPropertyName("Environment")]
        public string? Environment { get; set; }

        [JsonPropertyName("batchJobId")]
        public object? BatchJobId { get; set; }

        [JsonPropertyName("batchTaskId")]
        public object? BatchTaskId { get; set; }

        [JsonPropertyName("rule")]
        public string? Rule { get; set; }

        [JsonPropertyName("isFrozen")]
        public object? IsFrozen { get; set; }

        [JsonPropertyName("totalShown")]
        public object? TotalShown { get; set; }

        [JsonPropertyName("aggregationType")]
        public string? AggregationType { get; set; }
    }


}
