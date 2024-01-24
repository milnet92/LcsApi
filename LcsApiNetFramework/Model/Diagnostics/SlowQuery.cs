using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class SlowQuery
    {
        [JsonProperty("statement")]
        public string Statement { get; set; }

        [JsonProperty("callStack")]
        public string CallStack { get; set; }

        public double Utilization { get; set; }

        public double AvgExecutionTimeInSeconds { get; set; }

        public int ExecutionCount { get; set; }
    }


}
