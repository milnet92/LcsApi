using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class UserLoginEvent
    {
        public Guid AADuserId { get; set; }
        public Guid BrowserActivityId { get; set; }
        public DateTime Endtime { get; set; }
        public DateTime Starttime { get; set; }
    }
}
