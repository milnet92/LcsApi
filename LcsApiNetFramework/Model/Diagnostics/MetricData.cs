using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class MetricData
    {
        public string AccountName { get; set; }
        public MetricDataValue[] Data { get; set; }
        public string MetricName { get; set; }
        public string MetricNamespace { get; set; }
    }
}
