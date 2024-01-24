using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class UpcomingUpdateCalendar
    {
        public int NumberOfInteractableCalendarEntries { get; set; }
        public UpcomingCalendarViewModel[] UpcomingCalendarViewModels { get; set; }
    }
}
