namespace PetAdoptionMobileApplication.Pages;

public partial class PetDetailsPage : ContentPage
{
    private readonly PetDetailsViewModel viewModel;

    public PetDetailsPage(PetDetailsViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }
}