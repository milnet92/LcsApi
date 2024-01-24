namespace LcsApi.Model
{
	public class ProjectInstance
    {
		public CloudHostedInstance[] CheInstances { get; set; }
		public int LcsProjectId { get; set; }
		public CloudHostedInstance[] SaasInstances { get; set; }
    }
}