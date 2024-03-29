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

        [ObservableProperty]
        private IEnumerable<PetListDTO> unpopular = Enumerable.Empty<PetListDTO>();

        [ObservableProperty]
        private IEnumerable<PetListDTO> oldest = Enumerable.Empty<PetListDTO>();

        [ObservableProperty]
        private IEnumerable<PetListDTO> youngest = Enumerable.Empty<PetListDTO>();

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
                var mostPopularPetsTask = this.petAPI.GetPopularPetsAsync(3);
                var randomPetsTask = this.petAPI.GetRandomPetsAsync(3);
                var mostUnpopularPetsTask = this.petAPI.GetLeastPopularPetsAsync(3);
                var oldestPetsTask = this.petAPI.GetOldestPetsAsync(3);
                var youngestPetsTask = this.petAPI.GetYoungestPetsAsync(3);

                MostAffordable = (await mostAffordablePetsTask).Data;
                Popular = (await mostPopularPetsTask).Data;
                Unpopular = (await mostUnpopularPetsTask).Data;
                Random = (await randomPetsTask).Data;
                Oldest = (await oldestPetsTask).Data;
                Youngest = (await youngestPetsTask).Data;


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

        

    }
}
