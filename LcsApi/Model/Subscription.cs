namespace LcsApi.Model
{
	public class Subscription
    {
		public Connector[]? Connectors { get; set; }
		public DefaultConnector? DefaultConnector { get; set; }
		public bool HasEnvironmentManagementPrivileges { get; set; }
		public OrganizationReference[]? Organizations { get; set; }
    }
}