using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class StartStopDeploymentRequest
    {
        public Guid ActivityId { get; set; }
        public string? ProductName { get; set; }
        public string? TopologyName { get; set; }
        public string? TopologyInstanceId { get; set; }
        public Guid AzureSubscriptionId { get; set; }
        public int EnvironmentGroup { get; set; }
        public Guid? EnvironmentId { get; set; }
        public CloudHostedEnvironmentAction Action { get; set; }

        public StartStopDeploymentRequest(CloudHostedInstance cloudHostedInstance, CloudHostedEnvironmentAction action)
        {
            Action = action;
            ActivityId = cloudHostedInstance.ActivityId ?? throw new ArgumentException(nameof(cloudHostedInstance.ActivityId));
            AzureSubscriptionId = cloudHostedInstance.AzureSubscriptionId ?? throw new ArgumentException(nameof(cloudHostedInstance.AzureSubscriptionId));
            TopologyInstanceId = cloudHostedInstance.InstanceId ?? throw new ArgumentException(nameof(cloudHostedInstance.InstanceId));
            ProductName = cloudHostedInstance.ProductName ?? throw new ArgumentException(nameof(cloudHostedInstance.ProductName));
            TopologyName = cloudHostedInstance.TopologyName ?? throw new ArgumentException(nameof(cloudHostedInstance.TopologyName));
            EnvironmentId = cloudHostedInstance.EnvironmentId ?? throw new ArgumentException(nameof(cloudHostedInstance.EnvironmentId));
            EnvironmentGroup = 0;
        }

        public StartStopDeploymentRequest() { }
    }
}
