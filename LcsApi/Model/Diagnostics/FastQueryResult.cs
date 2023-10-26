using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class FastQueryResult
    {
        [JsonPropertyName("SESSION_ID")]
        public int? SessionId { get; set; }

        [JsonPropertyName("BATCH_INFO")]
        public string? BatchInfo { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("Blocking_Session_Id")]
        public int? BlockingSessionId { get; set; }

        [JsonPropertyName("program_name")]
        public string? ProgramName { get; set; }

        [JsonPropertyName("login_name")]
        public string? LoginName { get; set; }

        [JsonPropertyName("host_name")]
        public string? HostName { get; set; }

        [JsonPropertyName("host_process_id")]
        public int? HostProcessId { get; set; }

        [JsonPropertyName("SQL")]
        public string? SQL { get; set; }

        [JsonPropertyName("CPU_TIME")]
        public int? CpuTime { get; set; }

        [JsonPropertyName("TOTAL_ELAPSED_TIME")]
        public int? TotalElapsedTime { get; set; }

        [JsonPropertyName("READS")]
        public int? Reads { get; set; }

        [JsonPropertyName("WRITES")]
        public int? Writes { get; set; }

        [JsonPropertyName("LOGICAL_READS")]
        public int? LocalReads { get; set; }

        [JsonPropertyName("WAIT_TIME")]
        public int? WaitTime { get; set; }

        [JsonPropertyName("WAIT_TYPE")]
        public string? WaitType { get; set; }

        [JsonPropertyName("WAIT_RESOURCE")]
        public string? WaitResource { get; set; }
    }


}
