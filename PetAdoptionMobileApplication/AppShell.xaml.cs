namespace PetAdoptionMobileApplication
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(AdoptionSuccessfulPage), typeof(AdoptionSuccessfulPage));	
		}
	}
}
