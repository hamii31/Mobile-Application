namespace PetAdoptionMobileApplication.Pages;

public partial class AdoptionsPage : ContentPage
{
    private readonly MyAdoptionsViewModel viewModel;

    public AdoptionsPage(MyAdoptionsViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await this.viewModel.InitializeAsync();
    }
}
