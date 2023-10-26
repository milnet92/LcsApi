namespace LcsApi.Model
{
	public class ProjectUser
    {
		public int ProjectUserId { get; set; }
		public int ProjectId { get; set; }
		public int UserProfileId { get; set; }
		public bool IsOwner { get; set; }
		public int? FunctionalRole { get; set; }
		public bool? AllowContactByMicrosoft { get; set; }
		public int? SystemRoleId { get; set; }
		public UserProfile? UserProfile { get; set; }
		public InvitedBy? InvitedBy { get; set; }
		public DateTime? UserLastAccess { get; set; }
		public string? InvitationEmail { get; set; }
		public int InvitationStatus { get; set; }
		public int UserRole { get; set; }
		public string? UserRoleDisplayText { get; set; }
		public string? InvitationStatusDisplayText { get; set; }
		public string? FunctionalRoleDisplayText { get; set; }
		public object? UserRoleTypeDisplayText { get; set; }
		public int? CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string? LocalCreatedDate { get; set; }
		public string? LocalModifiedDate { get; set; }
    }
}