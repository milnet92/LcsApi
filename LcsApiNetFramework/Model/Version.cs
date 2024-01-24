using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class Version
    {
        public int Id { get; set; }
        public string VersionNumber { get; set; }
        public string DisplayName { get; set; }
        public bool ShowInUI { get; set; }
    }
}
