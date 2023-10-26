using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace LcsApi.Model
{
	public class DependentCustomizationValues
    {
		[JsonPropertyName("Address space")]
		public Dictionary<string, CustomizationValue[]?>? AddressSpace { get; set; }

		[JsonPropertyName("Application subnet name")]
		public Dictionary<string, CustomizationValue[]?>? ApplicationSubnetName { get; set; }

		[JsonPropertyName("Application Gateway Subnet Name")]
		public Dictionary<string, CustomizationValue[]?>? ApplicationGatewaySubnetName { get; set; }

		[JsonPropertyName("Sql HA Subnet name")]
		public Dictionary<string, CustomizationValue[]?>? SqlHASubnetName { get; set; }
    }
}