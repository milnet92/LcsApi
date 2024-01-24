using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class FastQueryResult
    {
        [JsonProperty("SESSION_ID")]
        public int? SessionId { get; set; }

        [JsonProperty("BATCH_INFO")]
        public string BatchInfo { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("Blocking_Session_Id")]
        public int? BlockingSessionId { get; set; }

        [JsonProperty("program_name")]
        public string ProgramName { get; set; }

        [JsonProperty("login_name")]
        public string LoginName { get; set; }

        [JsonProperty("host_name")]
        public string HostName { get; set; }

        [JsonProperty("host_process_id")]
        public int? HostProcessId { get; set; }

        [JsonProperty("SQL")]
        public string SQL { get; set; }

        [JsonProperty("CPU_TIME")]
        public int? CpuTime { get; set; }

        [JsonProperty("TOTAL_ELAPSED_TIME")]
        public int? TotalElapsedTime { get; set; }

        [JsonProperty("READS")]
        public int? Reads { get; set; }

        [JsonProperty("WRITES")]
        public int? Writes { get; set; }

        [JsonProperty("LOGICAL_READS")]
        public int? LocalReads { get; set; }

        [JsonProperty("WAIT_TIME")]
        public int? WaitTime { get; set; }

        [JsonProperty("WAIT_TYPE")]
        public string WaitType { get; set; }

        [JsonProperty("WAIT_RESOURCE")]
        public string WaitResource { get; set; }
    }


}
