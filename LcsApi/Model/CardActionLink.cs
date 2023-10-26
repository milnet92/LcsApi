using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class CardActionLink
    {
        public string? LinkName { get; set; }
        public string? LinkAddress { get; set; }
        public string? ActionControlName { get; set; }
        public int LinkType { get; set; }
        public object? LinkParam { get; set; }
    }
}
