namespace PetAdoptionMobileApplication.Pages;

public partial class AllPetsPage : ContentPage
{
    private readonly AllPetsViewModel viewModel;

    public AllPetsPage(AllPetsViewModel viewModel)
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