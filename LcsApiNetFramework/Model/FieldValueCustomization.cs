namespace LcsApi.Model
{
	public class FieldValueCustomization
    {
		public string FieldName { get; set; }
		public string DisplayName { get; set; }
		public object ErrorOnRegexValidationFailure { get; set; }
		public string DefaultValue { get; set; }
		public string SampleValue { get; set; }
		public bool IsEditable { get; set; }
		public bool IsRequired { get; set; }
		public int MaxLength { get; set; }
		public string RegexToValidate { get; set; }
		public int Width { get; set; }

    }
}