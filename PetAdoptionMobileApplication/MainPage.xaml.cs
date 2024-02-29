using PetAdoptionMobileApplication.Pages;
using static PetAdoptionMobileApplication.UIConstants;

namespace PetAdoptionMobileApplication
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (Preferences.Default.ContainsKey(LoadingShown))
			{
				await Shell.Current.GoToAsync($"//{nameof(LoginPage)}"); // This should be HomePage but for testing's sake it's not
			}
			else // user loads for the first time
			{
				await Shell.Current.GoToAsync($"//{nameof(LoadingPage)}");
			}
		}
	}
}