using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Common
{
    public class PaginatedRequest
    {
        public DynamicPaging DynamicPaging { get; set; }
        public object Filtering { get; set; }
    }
}
