using Refit;

namespace PetAdoptionMobileApplication.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IPetAPI petAPI;
        public HomeViewModel(IPetAPI petAPI)
        {
            this.petAPI = petAPI;
        }

        [ObservableProperty]
        private IEnumerable<PetListDTO> mostAffordable = Enumerable.Empty<PetListDTO>();

        [ObservableProperty]
        private IEnumerable<PetListDTO> popular = Enumerable.Empty<PetListDTO>();

        [ObservableProperty]
        private IEnumerable<PetListDTO> random = Enumerable.Empty<PetListDTO>();

        private bool isInitialized;

        [ObservableProperty]
        private string userName = "User";

        public async Task InitializeAsync()
        {
            if (isInitialized)
            {
                return; // don't load the collections again
            }

            // Operation begins
            IsBusy = true;
            try
            {
                await Task.Delay(100);
                var mostAffordablePetsTask = this.petAPI.GetTheMostAffordablePetsAsync(3);
                var mostPopularPetsTask = this.petAPI.GetPopularPetsAsync(4);
                var randomPetsTask = this.petAPI.GetRandomPetsAsync(3);

                MostAffordable = (await mostAffordablePetsTask).Data;
                Popular = (await mostPopularPetsTask).Data;
                Random = (await randomPetsTask).Data;


                isInitialized = true; 
            }
            catch (ApiException ex)
            {
                await ShowAlertAsync("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToDetailsPage(string PetId)
        {
           await GoToAsync($"{nameof(PetDetailsPage)}?{nameof(PetDetailsViewModel.PetId)}={PetId}");
        }

    }
}
