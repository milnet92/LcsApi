using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class DatabaseMovementAction
    {
        public Guid? ActivityId { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DbVersion { get; set; }
        public bool IsPointIntime { get; set; }
        public string OperationName { get; set; }
        public string RequestedBy { get; set; }
        public string Source { get; set; }
        public string Status { get; set; }
        public string Target { get; set; }
    }
}
