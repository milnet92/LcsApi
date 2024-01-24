using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class EnvironmentMonitoringData
    {
        public object AppServicesStatus { get; set; }
        public object AvailabilityStatus { get; set; }
        public object AzureStatus { get; set; }
        public Metric[] Metrics { get; set; }
        public RoleInstance[] RoleInstances { get; set; }
    }
}
