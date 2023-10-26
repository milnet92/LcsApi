namespace LcsApi.Model
{
	public class ComboBoxCustomization
    {
		public CustomizationValue[]? Values { get; set; }
		public DependentCustomizationValues? DependentCustomizationValues { get; set; }
		public string? FieldName { get; set; }
		public string? DisplayName { get; set; }
		public string? DefaultValue { get; set; }
		public object? SampleValue { get; set; }
		public bool IsEditable { get; set; }
		public bool IsRequired { get; set; }
		public int MaxLength { get; set; }
		public int Width { get; set; }
		public object? RegexToValidate { get; set; }
		public object? ErrorOnRegexValidationFailure { get; set; }
    }
}