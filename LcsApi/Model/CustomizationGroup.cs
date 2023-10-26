namespace LcsApi.Model
{
	public class CustomizationGroup
    {
		public string? FieldName { get; set; }
		public string? DisplayName { get; set; }
		public string? Description { get; set; }
		public bool IsCompleted { get; set; }
		public int Category { get; set; }
		public object? CustomizationGroupProperties { get; set; }
		public object? HelpContent { get; set; }
		public string? GroupType { get; set; }
		public DeploymentCustomizationGroupOption[]? DeploymentCustomizationGroupOptions { get; set; }
    }
}