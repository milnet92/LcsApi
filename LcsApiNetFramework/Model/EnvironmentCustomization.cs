namespace LcsApi.Model
{
	public class EnvironmentCustomization
    {
		public string Caption { get; set; }
		public string TopologyDescription { get; set; }
		public InstanceCustomization[] InstanceCustomizations { get; set; }
		public DeploymentCustomization[] DeploymentCustomizations { get; set; }
		public CustomizationGroup[] CustomizationGroups { get; set; }
		public CustomizationValue EstimateCustomization { get; set; }
		public string[] EstimateNames { get; set; }
		public bool IsEditable { get; set; }
		public bool IsUnoDevPublic { get; set; }
    }
}