using System.Collections.Generic;

namespace LcsApi.Model.Common
{
    public class LcsResponse<T>
    {
        public object ActivityId { get; set; }
        public T Data { get; set; }
        public int ErrorCode { get; set; }
        public Dictionary<string, string> ErrorList { get; set; }
        public string Message { get; set; }
        public string MessageTitle { get; set; }
        public bool Success { get; set; }
    }
}