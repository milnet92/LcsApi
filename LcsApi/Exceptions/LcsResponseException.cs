using LcsApi.Model.Common;

namespace LcsApi.Exceptions
{
    /// <summary>
    /// Exception representing an unsuccessful LCS API response. Typically this is due to a internal server error (500)
    /// </summary>
    public class LcsResponseException : Exception
    {
        /// <summary>
        /// Error code given by Lifecycle Services response object
        /// </summary>
        public int ErrorCode { get; init; }

        /// <summary>
        /// Message title given by Lifecycle Services response object
        /// </summary>
        public string MessageTitle { get; init; }

        /// <summary>
        /// Error list given by Lcs
        /// </summary>
        public Dictionary<string, string> ErrorList { get; init; }

        public LcsResponseException(int errorCode, string? message = null, string? messageTitle = null, Dictionary<string, string>? errorList = null) : base(message)
        {
            ErrorCode = errorCode;
            MessageTitle = messageTitle ?? string.Empty;
            ErrorList = errorList ?? new();
        }

        public LcsResponseException(LcsResponse<object?> lcsResponse) : this(lcsResponse.ErrorCode, lcsResponse.Message, lcsResponse.MessageTitle, lcsResponse.ErrorList) { }
    }
}
