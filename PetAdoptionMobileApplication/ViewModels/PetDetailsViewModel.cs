using PetAdoptionMobileApplication.Services;

namespace PetAdoptionMobileApplication.ViewModels
{
    [QueryProperty(nameof(PetId), nameof(PetId))]
    public partial class PetDetailsViewModel : BaseViewModel
    {
        private readonly IPetAPI petAPI;
        private readonly AuthService authService;
        private readonly IUserAPI userAPI;

        public PetDetailsViewModel(IPetAPI petAPI, AuthService authService, IUserAPI userAPI)
        {
            this.petAPI = petAPI;
            this.authService = authService;
            this.userAPI = userAPI;
        }

        [ObservableProperty]
        private string petId;

        [ObservableProperty]
        private PetModel petInfo = new();

        async partial void OnPetIdChanging(string value)
        {
            IsBusy = true;
            try
            {
                await Task.Delay(100); // To see activity indicator
                var APIResponse = this.authService.IsLoggedIn ? await this.userAPI.GetPetInformationAsync(value)
                                                              : await this.petAPI.GetPetInformationAsync(value);

                if (APIResponse.IsSuccess)
                {
                    var petDTO = APIResponse.Data;
                    PetInfo = new PetModel()
                    {
                        Id = petDTO.Id,
                        Name = petDTO.Name,
                        Image = petDTO.Image,
                        Price = petDTO.Price,
                        Breed = petDTO.Breed,
                        Description = petDTO.Description,
                        GenderDisplay = petDTO.GenderDisplay,
                        GenderImage = petDTO.GenderImage,
                        Age = petDTO.Age,
                        AdoptionStatus = petDTO.AdoptionStatus,
                        IsFav = petDTO.IsFav,
                        Gender = petDTO.Gender 
                    };
                }
                else
                {
                    await ShowAlertAsync("An error occured while fetching pet info!", APIResponse.Message, "Ok");
                }

            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Something went wrong!", ex.Message, "Ok");
            }
            finally 
            { 
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoBack() => await GoToAsync(".."); // When using Shell, .. means go back to the previous page.

        [RelayCommand]
        private async Task ToggleIsFav()
        {
            // Check if user is not logged in
            if(!this.authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in!");
                return;
            }

            // Toggle IsFav to the opposite of it
            PetInfo.IsFav = !PetInfo.IsFav;

            try
            {
                IsBusy = true;

                // Add to user favorites
                await this.userAPI.AddOrRemoveFromFavPetsAsync(PetId);
            }
            catch (Exception ex)
            {
                IsBusy = false;

                // Toggle IsFav back to its previous value if there was an error
                PetInfo.IsFav = !PetInfo.IsFav;

                await ShowAlertAsync("Something went wrong!", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task AdoptAsync()
        {
            // Uncomment to design the Adoption Successfull Page without adopting.
            //await GoToAsync(nameof(AdoptionSuccessfulPage));
            //return;

            if (!this.authService.IsLoggedIn)
            {
                await ShowToastAsync("You need to be logged in!");
                return;
            }

            IsBusy = true;
            try
            {
                var APIResponse = await this.userAPI.AdoptPetAsync(PetId);

                if (APIResponse.IsSuccess)
                {
                    PetInfo.AdoptionStatus = AdoptionStatus.Unavailable; // so the "Adopt" button changes immediately.
                    await GoToAsync(nameof(AdoptionSuccessfulPage));
                }
                else
                {
                    await ShowAlertAsync("An error occured while adopting this pet!", APIResponse.Message, "OK");
                }
            }
            catch (Exception ex)
            {
                await ShowAlertAsync("Something went wrong!", ex.Message, "OK");
                IsBusy = false;
            }
            finally
            {
                IsBusy = false;
            }
        }   
    }
}
