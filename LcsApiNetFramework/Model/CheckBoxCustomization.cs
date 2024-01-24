namespace LcsApi.Model
{
	public class CheckBoxCustomization
    {
		public string FieldName { get; set; }
		public string DisplayName { get; set; }
		public bool IsEditable { get; set; }
		public bool IsRequired { get; set; }
		public CustomizationValueSelection[] Values { get; set; }
    }
}