using System.Collections.Generic;

namespace LcsApi.Model
{
	public class InstanceReference
    {
		public Dictionary<string, string> Credentials { get; set; }
		public string DeploymentStatus { get; set; }
		public string DisplayName { get; set; }
		public string ItemName { get; set; }
		public string Location { get; set; }
		public string MachineName { get; set; }
		public string RDPConnectionDetails { get; set; }
    }
}