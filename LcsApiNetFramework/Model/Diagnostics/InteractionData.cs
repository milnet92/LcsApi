using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class InteractionData
    {
        public string ActivityId { get; set; }
        public string BrowserSessionActivityId { get; set; }
        public object ClientIP { get; set; }
        public string CommandName { get; set; }
        public string ControlName { get; set; }
        public double? EndTime { get; set; }
        public int? ErrorType { get; set; }
        public object EventData { get; set; }
        public string FormName { get; set; }
        public bool IsWarmEvent { get; set; }
        public string RoleInstance { get; set; }
        public object SessionKey { get; set; }
        public double StartTime { get; set; }
        public string TaskName { get; set; }
        public double TimeStamp { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
    }
}