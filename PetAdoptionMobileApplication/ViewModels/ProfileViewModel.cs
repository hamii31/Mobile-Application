using PetAdoptionMobileApplication.Services;

namespace PetAdoptionMobileApplication.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly AuthService authService;
        private readonly CommonService commonService;
        private readonly IUserAPI userAPI;

        public ProfileViewModel(AuthService authService,CommonService commonService, IUserAPI userAPI)
        {
            this.authService = authService;
            this.commonService = commonService;
            this.userAPI = userAPI;
            this.commonService.LoginStatusChanged += OnLoginStatusChanged;
            SetUserInfo();
        }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Initials))] // Notify the computed property Initials that the observable property UserName has changed
        private string userName = "Anon_User";

        [ObservableProperty]
        private bool isLoggedIn;

        public string Initials
        {
            get
            {
                var splitted = UserName.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                if (splitted.Length == 1) // single word username (e.g. Name)
                {
                    return UserName.Length == 1
                        ? UserName // If the single word username is comprised of one letter (e.g. N)
                        : UserName[..2]; // If the single word username has multiple characters (e.g. Name), take the two characters from the start
                }

                return $"{splitted[0][0]}{splitted[1][0]}"; // multiple word username (e.g. Cool Name), take the two characters from the start
            }
        }

        private void OnLoginStatusChanged(object sender, EventArgs e) => SetUserInfo(); 

        private void SetUserInfo()
        {
            if (this.authService.IsLoggedIn)
            {
                var userInfo = this.authService.GetUser();
                UserName = userInfo.Name;
                IsLoggedIn = true;
                this.commonService.SetToken(userInfo.Token);
            }
            else
            {
                UserName = "Anon_User";
                IsLoggedIn = false;
            }
        }

        [RelayCommand]
        private async Task LoginLogoutAsync()
        {
            if(!IsLoggedIn)
            {
                await GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                authService.Logout();
                await GoToAsync($"//{nameof(HomePage)}");
            }
        }

        [RelayCommand]
        private async Task GoToAdoptionsPage()
        {
            await GoToAsync($"//{nameof(AdoptionsPage)}");
        }

        [RelayCommand]
        private async Task ChangePassAsync()
        {
            if (!this.authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in!");
                return;
            }

            var newPassword = await App.Current.MainPage.DisplayPromptAsync("Action", "Change Password", placeholder: "Enter new password");
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                IsBusy = true;
                try
                {
                    await this.userAPI.ChangePasswordAsync(new SingleValueDTO<string>(newPassword));
                }
                catch (Exception ex)
                {
                    await ShowAlertAsync("Something went wrong!", ex.Message, "Ok");
                    IsBusy = false;
                    return;
                }
                finally
                {
                    await ShowToastAsync("Password changed successfully!");
                    IsBusy = false;
                }
            }
        }
    }
}
