using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class Project
    {
		public ProjectUserCapabilities Capabilities { get; set; }
		public string CreatedDate { get; set; }//Todo
		public object CurrentPhase { get; set; }
		public int CurrentPhaseId { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public Industry IndustryId { get; set; }
		public string IndustryName { get; set; }
		public int MethodologyId { get; set; }
		public object MethodologyName { get; set; }
		public int MethodologyStatus { get; set; }
		public string Name { get; set; }
		public string OrganizationName { get; set; }
		public OrganizationType OrgType { get; set; }
		public ProjectProduct Product { get; set; }
		public ProjectType ProjectTypeId { get; set; }
		public bool RequestPending { get; set; }
		public ProjectSettings Settings { get; set; }
    }
}