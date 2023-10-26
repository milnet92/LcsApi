using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class RoleInstance
    {
        public string? Id { get; set; }
        public string? MetricNamespace { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public object? ServiceUnit { get; set; }
    }

}
