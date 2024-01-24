using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Sizing
{
    public class EstimateAnswer
    {
        public int DefaultValue { get; set; }
        public int Id { get; set; }
        public bool IsRequiredQuestion { get; set; }
        public string Key { get; set; }
        public string Label { get; set; }
        public int MaxValue { get; set; }
        public int UserSelectedValue { get; set; }
    }
}
