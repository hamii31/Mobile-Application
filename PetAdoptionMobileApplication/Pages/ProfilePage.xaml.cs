namespace PetAdoptionMobileApplication.Pages;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel viewModel;

    public ProfilePage(ProfileViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }
}