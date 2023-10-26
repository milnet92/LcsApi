namespace LcsApi.Model
{
	public class DeploymentCustomization
    {
		public string? FieldName { get; set; }
		public string? DisplayName { get; set; }
		public object? DefaultValue { get; set; }
		public object? SampleValue { get; set; }
		public bool IsEditable { get; set; }
		public bool IsRequired { get; set; }
		public int MaxLength { get; set; }
		public int Width { get; set; }
		public object? RegexToValidate { get; set; }
		public object? ErrorOnRegexValidationFailure { get; set; }
    }
}