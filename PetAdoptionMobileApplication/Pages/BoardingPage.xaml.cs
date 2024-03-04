namespace PetAdoptionMobileApplication.Pages;

public partial class BoardingPage : ContentPage
{
	public BoardingPage()
	{
		InitializeComponent();

		Preferences.Default.Set(UIConstants.LoadingShown, string.Empty);
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var parameters = new Dictionary<string, object>()
		{
			[nameof(LoginViewModel.FirstTimeUser)] = true
		};

		await Shell.Current.GoToAsync($"//{nameof(LoginPage)}", parameters); // parameters are for testing the first-time user func
	}
}