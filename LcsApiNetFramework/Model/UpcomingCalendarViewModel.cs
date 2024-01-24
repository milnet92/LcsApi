using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class UpcomingCalendarViewModel
    {
        public string EnvironmentName { get; set; }
        public int StatusEnum { get; set; }
        public int EventNameEnum { get; set; }
        public int CalendarId { get; set; }
        public DateTime UtcStartDateTime { get; set; }
        public Guid EnvironmentId { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int DownTimeInMinutes { get; set; }
        public string EventName { get; set; }
        public string Status { get; set; }
        public bool IsModified { get; set; }
        public int WorkflowInstanceId { get; set; }
    }
}
