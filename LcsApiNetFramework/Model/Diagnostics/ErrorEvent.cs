using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class ErrorEvent
    {
        [JsonProperty("TIMESTAMP")]
        public DateTime TIMESTAMP { get; set; }

        [JsonProperty("PreciseTimeStamp")]
        public DateTime PreciseTimeStamp { get; set; }

        [JsonProperty("Tenant")]
        public string Tenant { get; set; }

        [JsonProperty("Role")]
        public string Role { get; set; }

        [JsonProperty("RoleInstance")]
        public string RoleInstance { get; set; }

        [JsonProperty("ClusterName")]
        public string ClusterName { get; set; }

        [JsonProperty("ClusterNodeName")]
        public string ClusterNodeName { get; set; }

        [JsonProperty("ContainerName")]
        public string ContainerName { get; set; }

        [JsonProperty("Level")]
        public int? Level { get; set; }

        [JsonProperty("ProviderGuid")]
        public string ProviderGuid { get; set; }

        [JsonProperty("ProviderName")]
        public string ProviderName { get; set; }

        [JsonProperty("EventId")]
        public int? EventId { get; set; }

        [JsonProperty("Pid")]
        public int? Pid { get; set; }

        [JsonProperty("Tid")]
        public int? Tid { get; set; }

        [JsonProperty("OpcodeName")]
        public string OpcodeName { get; set; }

        [JsonProperty("KeywordName")]
        public string KeywordName { get; set; }

        [JsonProperty("TaskName")]
        public string TaskName { get; set; }

        [JsonProperty("ChannelName")]
        public string ChannelName { get; set; }

        [JsonProperty("EventMessage")]
        public string EventMessage { get; set; }

        [JsonProperty("ActivityId")]
        public string ActivityId { get; set; }

        [JsonProperty("EventVersion")]
        public int? EventVersion { get; set; }

        [JsonProperty("LevelName")]
        public string LevelName { get; set; }

        [JsonProperty("RelatedActivityId")]
        public string RelatedActivityId { get; set; }

        [JsonProperty("eventGroupId")]
        public int? EventGroupId { get; set; }

        [JsonProperty("eventTimestamp")]
        public DateTime EventTimestamp { get; set; }

        [JsonProperty("formName")]
        public string FormName { get; set; }

        [JsonProperty("formUniqueId")]
        public int? FormUniqueId { get; set; }

        [JsonProperty("performanceEvent")]
        public object PerformanceEvent { get; set; }

        [JsonProperty("targetName")]
        public string TargetName { get; set; }

        [JsonProperty("targetType")]
        public string TargetType { get; set; }

        [JsonProperty("duration")]
        public object Duration { get; set; }

        [JsonProperty("responseTextStatus")]
        public string ResponseTextStatus { get; set; }

        [JsonProperty("responseHTTPStatus")]
        public object ResponseHTTPStatus { get; set; }

        [JsonProperty("requestTimeoutMilliseconds")]
        public object RequestTimeoutMilliseconds { get; set; }

        [JsonProperty("requestRetryCount")]
        public object RequestRetryCount { get; set; }

        [JsonProperty("browserSessionActivityId")]
        public string BrowserSessionActivityId { get; set; }

        [JsonProperty("readyState")]
        public object ReadyState { get; set; }

        [JsonProperty("originalEventTimestamp")]
        public object OriginalEventTimestamp { get; set; }

        [JsonProperty("SourceNamespace")]
        public string SourceNamespace { get; set; }

        [JsonProperty("SourceMoniker")]
        public string SourceMoniker { get; set; }

        [JsonProperty("SourceVersion")]
        public string SourceVersion { get; set; }

        [JsonProperty("errorId")]
        public int? ErrorId { get; set; }

        [JsonProperty("errorType")]
        public int? ErrorType { get; set; }

        [JsonProperty("errorLocation")]
        public int? ErrorLocation { get; set; }

        [JsonProperty("errorLabel")]
        public string ErrorLabel { get; set; }

        [JsonProperty("callStack")]
        public string CallStack { get; set; }

        [JsonProperty("statusCode")]
        public int? StatusCode { get; set; }

        [JsonProperty("ClentRestrictedNetwork")]
        public object ClentRestrictedNetwork { get; set; }

        [JsonProperty("sessionAction")]
        public object SessionAction { get; set; }

        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("operatingSystem")]
        public string OperatingSystem { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("cpuClass")]
        public string CpuClass { get; set; }

        [JsonProperty("browserName")]
        public string BrowserName { get; set; }

        [JsonProperty("browserVersion")]
        public string BrowserVersion { get; set; }

        [JsonProperty("touchEnabled")]
        public object TouchEnabled { get; set; }

        [JsonProperty("screenResolution")]
        public string ScreenResolution { get; set; }

        [JsonProperty("viewPortSize")]
        public string ViewPortSize { get; set; }

        [JsonProperty("browserLanguage")]
        public string BrowserLanguage { get; set; }

        [JsonProperty("osLanguage")]
        public string OsLanguage { get; set; }

        [JsonProperty("applicationLanguage")]
        public string ApplicationLanguage { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("density")]
        public string Density { get; set; }

        [JsonProperty("theme")]
        public string Theme { get; set; }

        [JsonProperty("clientVersion")]
        public string ClientVersion { get; set; }

        [JsonProperty("roundTripTime")]
        public object RoundTripTime { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("targetIndex")]
        public object TargetIndex { get; set; }

        [JsonProperty("targetMenuItemDescription")]
        public string TargetMenuItemDescription { get; set; }

        [JsonProperty("ControlName")]
        public string ControlName { get; set; }

        [JsonProperty("CommandName")]
        public string CommandName { get; set; }

        [JsonProperty("failureMessage")]
        public string FailureMessage { get; set; }

        [JsonProperty("formControlName")]
        public string FormControlName { get; set; }

        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("errorCode")]
        public object ErrorCode { get; set; }

        [JsonProperty("targetPath")]
        public string TargetPath { get; set; }

        [JsonProperty("itemCount")]
        public object ItemCount { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("actionEvent")]
        public object ActionEvent { get; set; }

        [JsonProperty("inputType")]
        public object InputType { get; set; }

        [JsonProperty("userDefined1")]
        public object UserDefined1 { get; set; }

        [JsonProperty("userDefined2")]
        public object UserDefined2 { get; set; }

        [JsonProperty("extendedData")]
        public string ExtendedData { get; set; }

        [JsonProperty("workspaceName")]
        public string WorkspaceName { get; set; }

        [JsonProperty("pageName")]
        public string PageName { get; set; }

        [JsonProperty("actionName")]
        public string ActionName { get; set; }

        [JsonProperty("currentRequestType")]
        public string CurrentRequestType { get; set; }

        [JsonProperty("systemCallDurationInMilliSeconds")]
        public object SystemCallDurationInMilliSeconds { get; set; }

        [JsonProperty("appCallDurationInMilliSeconds")]
        public object AppCallDurationInMilliSeconds { get; set; }

        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("jsonInfo")]
        public string JsonInfo { get; set; }

        [JsonProperty("userGuid")]
        public string UserGuid { get; set; }

        [JsonProperty("LegalEntity")]
        public object LegalEntity { get; set; }

        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("ComponentName")]
        public string ComponentName { get; set; }

        [JsonProperty("exceptionMessage")]
        public string ExceptionMessage { get; set; }

        [JsonProperty("exceptionType")]
        public string ExceptionType { get; set; }

        [JsonProperty("exceptionStackTrace")]
        public string ExceptionStackTrace { get; set; }

        [JsonProperty("exceptionIsNested")]
        public object ExceptionIsNested { get; set; }

        [JsonProperty("feedbackType")]
        public object FeedbackType { get; set; }

        [JsonProperty("feedbackText")]
        public string FeedbackText { get; set; }

        [JsonProperty("Environment")]
        public string Environment { get; set; }

        [JsonProperty("batchJobId")]
        public object BatchJobId { get; set; }

        [JsonProperty("batchTaskId")]
        public object BatchTaskId { get; set; }

        [JsonProperty("rule")]
        public string Rule { get; set; }

        [JsonProperty("isFrozen")]
        public object IsFrozen { get; set; }

        [JsonProperty("totalShown")]
        public object TotalShown { get; set; }

        [JsonProperty("aggregationType")]
        public string AggregationType { get; set; }
    }


}
