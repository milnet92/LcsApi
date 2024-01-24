namespace LcsApi.Model
{
	public class InstanceCustomization
    {
		public string ItemName { get; set; }
		public string DisplayName { get; set; }
		public int MinValue { get; set; }
		public int MaxValue { get; set; }
		public bool IsInstanceCountCustomizable { get; set; }
		public bool IsRoleSizeCustomizable { get; set; }
		public CustomizationValue[] RoleSizes { get; set; }
		public CustomizationValue[] InstanceCounts { get; set; }
		public int CurrentInstanceCount { get; set; }
		public int DefaultValue { get; set; }
		public string DefaultRoleSize { get; set; }
    }
}