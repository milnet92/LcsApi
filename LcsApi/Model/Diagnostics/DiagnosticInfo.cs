namespace LcsApi.Model.Diagnostics
{
    public class DiagnosticInfo
    {
        public string? LastRunTimestamp { get; set; }
        public Message[]? Messages { get; set; }
        public string? InfoMessage { get; set; }
    }
}