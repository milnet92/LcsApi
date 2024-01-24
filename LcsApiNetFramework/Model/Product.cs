using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string DisplayName { get; set; }
        public Version[] Versions { get; set; }
        public int DefaultMethodologyId { get; set; }
        public int SupportedLcsRegions { get; set; }
        public Service[] Services { get; set; }
    }
}
