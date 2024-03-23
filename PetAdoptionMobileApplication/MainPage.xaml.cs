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
				await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
			}
			else // first time user is redirected to BoardingPage
			{
				await Shell.Current.GoToAsync($"//{nameof(BoardingPage)}");
			}
		}
	}
}