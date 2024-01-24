namespace LcsApi.Model
{
	public class EnvironmentActionResponse
    {
		public string ActivityId { get; set; }
		public string ErrorCode { get; set; }
		public object ErrorList { get; set; }
		public bool IsSuccessful { get; set; }
		public string Message { get; set; }
		public string MessageTitle { get; set; }
    }
}