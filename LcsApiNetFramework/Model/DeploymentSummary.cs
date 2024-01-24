using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcsApi.Model
{
    public class DeploymentSummary
    {
        public ActionCenterDataViewModel[] ActionCenterDataViewModels { get; set; }
        public DeploymentInstance[] DeploymentInstances { get; set; }
        public string DeploymentSkuName { get; set; }
        public int DisplayOrder { get; set; }
        public string TopologyName { get; set; }
    }
}