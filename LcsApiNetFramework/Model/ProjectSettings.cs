using LcsApi.Model.Common;

namespace LcsApi.Model
{
    public class ProjectSettings
    {
		public bool IsOnPremTfsEnabled { get; set; }
		public IssueStorage IssueStorageType { get; set; }
		public string SharepointSite { get; set; }
		public System.Guid TfsProjectId { get; set; }
		public string TfsProjectName { get; set; }
		public string TfsServerSite { get; set; }
    }
}