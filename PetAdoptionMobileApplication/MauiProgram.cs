using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace PetAdoptionMobileApplication
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
		builder.Logging.AddDebug();
#endif

			AddToDependencyContainer(builder.Services);

			return builder.Build();
		}

		static void AddToDependencyContainer(IServiceCollection services)
		{
			// Add all services, pages, models, viewmodels here:
			services.AddTransient<LoginViewModel>()
					.AddTransient<LoginPage>();
		}
	}
}