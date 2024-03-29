using PetAdoptionMobileApplication.Services;

namespace PetAdoptionMobileApplication.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        private readonly AuthService authService;
        private readonly CommonService commonService;

        public ProfileViewModel(AuthService authService,CommonService commonService)
        {
            this.authService = authService;
            this.commonService = commonService;
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
                await GoToAsync($"//{nameof(BoardingPage)}");
            }
        }

        [RelayCommand]
        private async Task GoToAdoptionsPage()
        {
            await GoToAsync($"//{nameof(AdoptionsPage)}");
        }
    }
}
