using PetAdoptionMobileApplication.Services;

namespace PetAdoptionMobileApplication.ViewModels
{
    public partial class MyAdoptionsViewModel : BaseViewModel
    {
        private readonly AuthService authService;
        private readonly IUserAPI userAPI;

        public MyAdoptionsViewModel(AuthService authService, IUserAPI userAPI)
        {
            this.authService = authService;
            this.userAPI = userAPI;
        }

        [ObservableProperty]
        private IEnumerable<PetListDTO> userAdoptions = Enumerable.Empty<PetListDTO>();

        public async Task InitializeAsync()
        {
            // Check if user is not logged in
            if (!this.authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in!");
                return;
            }

            IsBusy = true;
            try
            {
                await Task.Delay(100);
                var APIResponse = await this.userAPI.GetUserAdoptionsAsync();
                if (APIResponse.IsSuccess)
                {
                    UserAdoptions = APIResponse.Data;
                }
                else
                {
                    await ShowAlertAsync("An error occured while fetching this data!", APIResponse.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Something went wrong!", ex.Message, "OK");
                IsBusy = false;
            }
        }
    }
}
