namespace LcsApi.Model
{
	public class ServiceAccessState
    {
		public bool CanAccessProject { get; set; }
		public string? TfsProjectName { get; set; }
		public Guid TfsProjectId { get; set; }
    }
}