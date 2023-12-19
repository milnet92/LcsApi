using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class UpdatePauseWindowForProject
    {
        public bool IsPauseUpdateEnabled { get; set; }
        public string? PauseNotificationMessage { get; set; }
        public bool ShowEditPauseSettings { get; set; }
        public bool ShowPauseNotification { get; set; }
    }
}
