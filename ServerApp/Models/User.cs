using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
	public class User
	{
		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Logo { get; set; }
		public string LoginName { get; set; }
		public string Email { get; set; }
		public long PhoneExtension { get; set; }
		public string Mobile { get; set; }
		public bool ClientPoc { get; set; }
		public bool Processed { get; set; }
		public bool Enabled { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime ModifiedOn { get; set; }
		public bool LoggedIn { get; set; }
		public DateTime LastLoginDate { get; set; }
		public string CurrentPassword { get; set; }
		public int WrongAttemptCount { get; set; }
		public string LastPassword1 { get; set; }
		public string LastPassword2 { get; set; }
		public string LastPassword3 { get; set; }
		public string LastPassword4 { get; set; }
		public PasswordPolicy PasswordPolicy { get; set; }
		public Question Question1 { get; set; }
		public string Answer1 { get; set; }
		public Question Question2 { get; set; }
		public string Answer2 { get; set; }
		public Question Question3 { get; set; }
		public string Answer3 { get; set; }
		public DateTime ChangePasswordDate { get; set; }
		public Language Language { get; set; }
		public Theme Theme { get; set; }
		public Region Region { get; set; }
		public bool TermsAgreeed { get; set; }
	}
}
