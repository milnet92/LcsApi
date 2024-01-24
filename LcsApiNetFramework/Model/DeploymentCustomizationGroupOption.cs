namespace LcsApi.Model
{
	public class DeploymentCustomizationGroupOption
    {
		public string FieldName { get; set; }
		public string DisplayName { get; set; }
		public string DisplayDescription { get; set; }
		public string TargetItem { get; set; }
		public object[] CredentialCustomizations { get; set; }
		public FieldValueCustomization[] FieldValueCustomizations { get; set; }
		public ComboBoxCustomization[] ComboBoxCustomizations { get; set; }
		public CheckBoxCustomization[] CheckBoxCustomizations { get; set; }
		public object[] ButtonCustomizations { get; set; }
		public object[] LabelCustomizations { get; set; }
		public string AdditionalJsonData { get; set; }
		public bool IsSelected { get; set; }
    }
}