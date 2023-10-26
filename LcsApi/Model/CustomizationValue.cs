using System.Text.Json.Serialization;

namespace LcsApi.Model
{
	public class CustomizationValue
    {
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public string? Label { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Value { get; set; }
    }
}