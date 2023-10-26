using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class Metric
    {
        public Counter[]? Counters { get; set; }
        public string? Key { get; set; }
        public int? SortOrder { get; set; }
        public object? Source { get; set; }
    }
}
