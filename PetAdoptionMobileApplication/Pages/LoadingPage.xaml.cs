namespace PetAdoptionMobileApplication.Pages;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();

		Preferences.Default.Set(UIConstants.LoadingShown, string.Empty);
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
	}
}