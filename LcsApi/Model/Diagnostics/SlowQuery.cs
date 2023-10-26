using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class SlowQuery
    {
        [JsonPropertyName("statement")]
        public string? Statement { get; set; }

        [JsonPropertyName("callStack")]
        public string? CallStack { get; set; }

        public double Utilization { get; set; }

        public double AvgExecutionTimeInSeconds { get; set; }

        public int ExecutionCount { get; set; }
    }


}
