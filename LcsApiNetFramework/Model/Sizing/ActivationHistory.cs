using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model.Sizing
{
    public class ActivationHistory
    {
        public string ActivatedByUserName { get; set; }
        public string ActivationDate { get; set; }
        public string ActivePeriod { get; set; }
        public string DeactivationDate { get; set; }
        public int InfraEstimateId { get; set; }
    }
}
