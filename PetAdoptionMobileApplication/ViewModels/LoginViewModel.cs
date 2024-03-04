namespace PetAdoptionMobileApplication.ViewModels
{
	[QueryProperty(nameof(FirstTimeUser), nameof(FirstTimeUser))]
	public partial class LoginViewModel : ObservableObject
	{
		[ObservableProperty]
		private bool _isBusy;

		[ObservableProperty]
		private bool _isRegistering;

		[ObservableProperty]
		private LoginModel _model = new(); // on default this is null

		[ObservableProperty]
		private bool _firstTimeUser;

		partial void OnFirstTimeUserChanging(bool value)
		{
			bool firstTimeUser = value;

			// Check if it's a first time user
			if (firstTimeUser)
			{
				IsRegistering = true;
			}
		}

		[RelayCommand]
		private void SwitchModes() => IsRegistering = !IsRegistering; // (if registering, switch to logging in, if logging in, switch to registering)

		[RelayCommand]
		private async Task SkipForNow() => await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

		[RelayCommand]
		private async Task Login()
		{
			if(!Model.IsValidState(IsRegistering))
			{
				await Toast.Make("All fields are required!").Show();
				return;
			}

			IsBusy = true;

			// Make API call to login/register user, but for now just Skip when Logging in
			await Task.Delay(1000);
			await SkipForNow();

			IsBusy = false;
		}
	}
}
