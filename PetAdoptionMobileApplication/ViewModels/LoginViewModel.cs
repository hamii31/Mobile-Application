using PetAdoptionMobileApplication.Services;

namespace PetAdoptionMobileApplication.ViewModels
{
	[QueryProperty(nameof(FirstTimeUser), nameof(FirstTimeUser))]
	public partial class LoginViewModel : BaseViewModel
    {
        private readonly AuthService authService;
        public LoginViewModel(AuthService authService)
        {
            this.authService = authService;
        }
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
		private async Task SkipForNow() => await GoToAsync($"//{nameof(HomePage)}");

		[RelayCommand]
		private async Task Login()
		{
			if(!Model.IsValidState(IsRegistering))
			{
				await ShowToastAsync("All fields are required!");
				return;
			}

			IsBusy = true;

			// Make API call to login/register user, but for now just Skip when Logging in

			var status = await this.authService.LoginOrRegisterAsync(Model);

			if (status) // if there was an error, it would have been shown to the user
			{
                await SkipForNow();
            }

			IsBusy = false;
		}
	}
}
