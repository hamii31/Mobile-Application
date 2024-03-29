namespace PetAdoptionMobileApplication.ViewModels
{
    public partial class AllPetsViewModel : BaseViewModel
    {
        private readonly IPetAPI petAPI;

        public AllPetsViewModel(IPetAPI petAPI)
        {
            this.petAPI = petAPI;
        }

        [ObservableProperty]
        private IEnumerable<PetListDTO> pets = Enumerable.Empty<PetListDTO>();

        private bool isInitialized;

        // First time loading the page
        public async Task InitializeAsync()
        {
            if (isInitialized)
            {
                return;
            }

            isInitialized = true;
            await LoadAllPetsAsync(true); // initial loading

        }

        //OP for the Refresh Functionality
        [ObservableProperty]
        private bool isRefreshing;

        // Common method between the main and refresh functionality
        private async Task LoadAllPetsAsync(bool initialLoad)
        {
            if (initialLoad)
                IsBusy = true;
            else
                IsRefreshing = true;
            try
            {
                await Task.Delay(100);
                var APIResponse = await this.petAPI.GetAllPetsAsync();

                if (APIResponse.IsSuccess)
                {
                    Pets = APIResponse.Data;
                }
                else
                {
                    await ShowAlertAsync("Error", APIResponse.Message, "Ok");
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = IsRefreshing = false;
            }
        }

        // Refresh functionality
        [RelayCommand]
        private async Task RefreshAllPets() => await LoadAllPetsAsync(false); // non-initial loading
    }
}
