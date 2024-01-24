using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class Counter
    {
        public string DisplayName { get; set; }
        public object Source { get; set; }
        public string Text { get; set; }
        public string Unit { get; set; }
    }
}
