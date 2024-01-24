namespace LcsApi.Model
{
	public class ScaleUnit
    {
		public string Name { get; set; }
		public bool ShowUpdateButton { get; set; }
		public bool ShowUpdateExtensionButton { get; set; }
		public bool ShowSignOffButton { get; set; }
		public bool ShowDetails { get; set; }
		public bool ShowServicingInfo { get; set; }
		public bool ShowDeleteButton { get; set; }
		public bool EnableDeleteButton { get; set; }
		public string BaseVersion { get; set; }
		public string BaseVersionSemanticVersion { get; set; }
		public string BaseBuildPublishedDateInfo { get; set; }
		public string CustomizationName { get; set; }
		public object CustomizationPublishedDateInfo { get; set; }
		public object CustomizationPackageVersion { get; set; }
		public string CustomizationPackageSdkVersion { get; set; }
		public string CustomizationFileId { get; set; }
		public bool ShowCustomizationPackageDetails { get; set; }
		public bool IsCustomizationInstalled { get; set; }
		public string Region { get; set; }
		public string LastActivityId { get; set; }
		public string LastActivityInformation { get; set; }
		public string ScaleUnitId { get; set; }
		public bool IsBroadcastUpdateEnabled { get; set; }
		public int LastActivityUserProfileId { get; set; }
		public string CloudPosEndpoint { get; set; }
		public string RetailServerEndpoint { get; set; }
		public ServicingInfo ServicingInfo { get; set; }
    }
}