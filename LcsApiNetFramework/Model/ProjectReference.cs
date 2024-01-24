using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class ProjectReference
    {
		public string CreatedByUserName { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string OrganizationName { get; set; }
		public ProductId ProductId { get; set; }
		public ProductVersionId ProductVersionId { get; set; }
		public ProjectType ProjectTypeId { get; set; }
		public string RequestEmailInvited { get; set; }
		public bool RequestPending { get; set; }
		public bool RequestSentToAlternativeEmail { get; set; }
		public SolutionRequestStatus SolutionRequestStatus { get; set; }
		public bool Favorite { get; set; }
		public string SharepointSite { get; set; }
		public string TfsProjectName { get; set; }
		public string TfsServerSite { get; set; }
    }
}