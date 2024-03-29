namespace PetAdoptionMobileApplication.ViewModels
{
	public partial class BaseViewModel : ObservableObject
	{
		[ObservableProperty]
		private bool _isBusy;

		// Navigation
		protected async Task GoToAsync(ShellNavigationState state) 
			=> await Shell.Current.GoToAsync(state);
		protected async Task GoToAsync(ShellNavigationState state, bool animate) 
			=> await Shell.Current.GoToAsync(state, animate);
		protected async Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, string> param) 
			=> await Shell.Current.GoToAsync(state, animate, (IDictionary<string, object>)param);

		// Alerts and Messages
		protected async Task ShowToastAsync(string message) 
			=> await Toast.Make(message).Show();
		protected async Task ShowAlertAsync(string title, string message, string btnText)
			=> await App.Current.MainPage.DisplayAlert(title, message, btnText);
		protected async Task ConfirmationAsync(string title, string message, string okBtnText, string cancelBtnText)
			=> await App.Current.MainPage.DisplayAlert(title, message, okBtnText, cancelBtnText);

        [RelayCommand]
        private async Task GoToDetailsPage(string PetId)
        {
            await GoToAsync($"{nameof(PetDetailsPage)}?{nameof(PetDetailsViewModel.PetId)}={PetId}");
        }
    }
}
