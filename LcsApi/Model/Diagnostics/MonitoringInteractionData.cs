using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class MonitoringInteractionData
    {
        public object[]? CrashData { get; set; }
        public InteractionData[]? InteractionData { get; set; }
        public RoleInstance[]? RoleInstances { get; set; }
        public SqlUtilization[]? SqlUtilizationData { get; set; }
    }
}
