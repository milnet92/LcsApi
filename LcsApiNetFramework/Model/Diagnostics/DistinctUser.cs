using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Diagnostics
{
    public class DistinctUser
    {
        public Guid Alias { get; set; }
        public int UniqueSessions { get; set; }
    }
}
