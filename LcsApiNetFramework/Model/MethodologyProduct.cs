using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class MethodologyProduct
    {
        public int MethodologyId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelemetryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public object LocalCreatedDate { get; set; }
        public object LocalModifiedDate { get; set; }
    }
}
