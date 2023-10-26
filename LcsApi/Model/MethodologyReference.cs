namespace LcsApi.Model
{
	public class MethodologyReference
    {
		public int MethodologyId { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public MethodologyPhase[]? Phases { get; set; }
    }
}