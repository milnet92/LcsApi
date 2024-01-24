using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class SlowInteraction
    {
        [JsonProperty("TIMESTAMP")]
        public DateTime TimeStamp { get; set; }

        public string ActivityId { get; set; }

        [JsonProperty("combinedDurationInMinutes")]
        public int? CombinedDurationInMinutes { get; set; }

        public string TaskName { get; set; }

        public string Alias { get; set; }

        public string OpcodeName { get; set; }

        public string FormName { get; set  ; }

        public string ControlName { get; set; }

        public string CommandName { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("executionTimeSeconds")]
        public double? ExecutionTimeSeconds { get; set; }

        [JsonProperty("callStack")]
        public string CallStack { get; set; }

        [JsonProperty("statement")]
        public string Statement { get; set; }
    }


}
