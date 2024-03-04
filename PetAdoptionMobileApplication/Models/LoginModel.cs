namespace PetAdoptionMobileApplication.Models
{
	public partial class LoginModel : ObservableObject
	{
		[ObservableProperty]
		private string _userName;
		[ObservableProperty]
		private string _email;
		[ObservableProperty]
		private string _password;

		public bool NewUser => !string.IsNullOrWhiteSpace(UserName);
		public bool IsValidState(bool IsRegistering)
		{
			// check if user has entered email and pass
			if(string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
			{
				return false;
			}

			// check if user is registering for the first time
			if(IsRegistering && string.IsNullOrWhiteSpace(UserName))
			{
				return false;
			}

			return true;
		}
	}
}
