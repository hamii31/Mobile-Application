namespace PetAdoptionMobileApplication.Pages;

public partial class FavsPage : ContentPage
{
    private readonly UserFavouritesViewModel viewModel;

    public FavsPage(UserFavouritesViewModel viewModel)
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