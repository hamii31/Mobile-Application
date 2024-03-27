using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PetAdoptionMobileApplication.Services;
using Refit;

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
                    fonts.AddFont("Lobster-Regular.ttf", "Lobster");
                });

#if DEBUG
			builder.Logging.AddDebug();
#endif

#if ANDROID && DEBUG
            Platforms.Android.DangerousAndroidMessageHandlerEmitter.Register();
            Platforms.Android.DangerousTrustProvider.Register();
#endif


            AddToDependencyContainer(builder.Services);
			ConfigureRefit(builder.Services);

			return builder.Build();
		}

		static void AddToDependencyContainer(IServiceCollection services)
		{
			// Add all services, pages, models, viewmodels here:
			services.AddTransient<LoginViewModel>()
					.AddTransient<LoginPage>();

			services.AddTransient<AuthService>();

			services.AddSingleton<CommonService>();

			services.AddSingleton<HomeViewModel>()
					.AddSingleton<HomePage>();

			services.AddSingleton<AllPetsViewModel>()
					.AddTransient<AllPetsPage>();

			// adding routing for the pet details page using communitytoolkit
			services.AddTransientWithShellRoute<PetDetailsPage, PetDetailsViewModel>(nameof(PetDetailsPage));
		}

		static void ConfigureRefit(IServiceCollection services)
		{
			services.AddRefitClient<IAuthAPI>()
				.ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IPetAPI>()
                .ConfigureHttpClient(SetHttpClient);

			services.AddRefitClient<IUserAPI>(serviceProvider =>
			{
                // Getting Token

                var cS = serviceProvider.GetRequiredService<CommonService>();
				return new RefitSettings()
				{
					AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(cS.Token ?? string.Empty)
				};
			})
				.ConfigureHttpClient(SetHttpClient);


			static void SetHttpClient(HttpClient httpClient)
			{
                //httpClient.BaseAddress = new Uri(AppConstants.BaseAPIUrl);
                var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
							 ? "https://10.0.2.2:1234"
							 : "https://localhost:1234";

				httpClient.BaseAddress = new Uri(baseUrl);


			}


        }

	}
}