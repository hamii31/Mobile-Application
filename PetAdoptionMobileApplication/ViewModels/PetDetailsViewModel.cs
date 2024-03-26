namespace PetAdoptionMobileApplication.ViewModels
{
    [QueryProperty(nameof(PetId), nameof(PetId))]
    public partial class PetDetailsViewModel : BaseViewModel
    {
        private readonly IPetAPI petAPI;
        public PetDetailsViewModel(IPetAPI petAPI)
        {
            this.petAPI = petAPI;
        }

        [ObservableProperty]
        private string petId;

        [ObservableProperty]
        private PetInfoDTO petInfo = new();

        async partial void OnPetIdChanging(string value)
        {
            IsBusy = true;
            try
            {
                
                var APIResponse = await this.petAPI.GetPetInformationAsync(value);

                if (APIResponse.IsSuccess)
                {
                    PetInfo = APIResponse.Data;
                }
                else
                {
                    await ShowAlertAsync("Error", APIResponse.Message, "Ok");
                }

            }
            catch (Exception ex)
            {
                await ShowAlertAsync("An error occured while fetching pet info!", ex.Message, "Ok");
            }
            finally 
            { 
                IsBusy = false;
            }
        }
    }
}
