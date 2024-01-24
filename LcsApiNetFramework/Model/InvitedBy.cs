namespace LcsApi.Model
{
	public class InvitedBy
    {
		public object ADOauthCode { get; set; }
		public string ADUserId { get; set; }
		public string[] AllEmails { get; set; }
		public string AlternateEmails { get; set; }
		public int CreatedBy { get; set; }
		public string CreatedDate { get; set; }//Todo
		public string DisplayName { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public bool HasPscs { get; set; }
		public bool IsDefaultProfile { get; set; }
		public int LanguagePreference { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public Organization Organization { get; set; }
		public string Puid { get; set; }
		public int Role { get; set; }
		public object RoleDisplayText { get; set; }
		public int UserId { get; set; }
		public int UserProfileId { get; set; }
    }
}