using PetAdoptionMobileApplication.Services;
using System.Collections.ObjectModel;

namespace PetAdoptionMobileApplication.ViewModels
{
    public partial class UserFavouritesViewModel : BaseViewModel
    {
        private readonly IUserAPI userAPI;
        private readonly AuthService authService;
        private readonly CommonService commonService;

        public UserFavouritesViewModel(IUserAPI userAPI, AuthService authService, CommonService commonService)
        {
            this.userAPI = userAPI;
            this.authService = authService;
            this.commonService = commonService;
            this.commonService.LoginStatusChanged += OnLoginStatusChanged;
            SetUserInfo();
        }

        [ObservableProperty]
        private IEnumerable<PetListDTO> favouritePets = Enumerable.Empty<PetListDTO>();

        private void OnLoginStatusChanged(object sender, EventArgs e) => SetUserInfo();

        private void SetUserInfo()
        {
            if (this.authService.IsLoggedIn)
            {
                var userInfo = this.authService.GetUser();
                this.commonService.SetToken(userInfo.Token);
            }
        }
        public async Task InitializeAsync()
        {
            if (!this.authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in for that!");
                await GoToAsync($"//{nameof(ProfilePage)}");
                return;
            }

            try
            {
                IsBusy = true;
                var APIResponse = await this.userAPI.GetAllFavPetsAsync();

                if (APIResponse.IsSuccess)
                {
                    FavouritePets = APIResponse.Data;

                }
                else
                {
                    await ShowAlertAsync("An error occured while fetching your favourite pets!", APIResponse.Message, "Ok");
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("An error occured while fetching your favourite pets!", ex.Message, "Ok");
                return;
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
