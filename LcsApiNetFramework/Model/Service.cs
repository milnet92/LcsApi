using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Name { get; set; }
        public int ServiceType { get; set; }
        public string ServiceUrl { get; set; }
        public bool DisplayInUI { get; set; }
        public object[] Products { get; set; }
        public object[] UnfilteredTiles { get; set; }
        public object[] UnfilteredPinTemplates { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public object LocalCreatedDate { get; set; }
        public object LocalModifiedDate { get; set; }
    }
}
