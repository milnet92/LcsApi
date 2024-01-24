using System.Collections.Generic;
using Newtonsoft.Json;

namespace LcsApi.Model
{
	public class DependentCustomizationValues
    {
		[JsonProperty("Address space")]
		public Dictionary<string, CustomizationValue[]> AddressSpace { get; set; }

		[JsonProperty("Application subnet name")]
		public Dictionary<string, CustomizationValue[]> ApplicationSubnetName { get; set; }

		[JsonProperty("Application Gateway Subnet Name")]
		public Dictionary<string, CustomizationValue[]> ApplicationGatewaySubnetName { get; set; }

		[JsonProperty("Sql HA Subnet name")]
		public Dictionary<string, CustomizationValue[]> SqlHASubnetName { get; set; }
    }
}