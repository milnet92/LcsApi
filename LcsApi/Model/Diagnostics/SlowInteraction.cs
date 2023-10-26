using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class SlowInteraction
    {
        [JsonPropertyName("TIMESTAMP")]
        public DateTime TimeStamp { get; set; }

        public string? ActivityId { get; set; }

        [JsonPropertyName("combinedDurationInMinutes")]
        public int? CombinedDurationInMinutes { get; set; }

        public string? TaskName { get; set; }

        public string? Alias { get; set; }

        public string? OpcodeName { get; set; }

        public string? FormName { get; set  ; }

        public string? ControlName { get; set; }

        public string? CommandName { get; set; }

        [JsonPropertyName("path")]
        public string? Path { get; set; }

        [JsonPropertyName("errorMessage")]
        public string? ErrorMessage { get; set; }

        [JsonPropertyName("executionTimeSeconds")]
        public double? ExecutionTimeSeconds { get; set; }

        [JsonPropertyName("callStack")]
        public string? CallStack { get; set; }

        [JsonPropertyName("statement")]
        public string? Statement { get; set; }
    }


}
