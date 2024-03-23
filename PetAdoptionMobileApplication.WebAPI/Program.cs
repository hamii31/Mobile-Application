
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.WebAPI.Data;
using PetAdoptionMobileApplication.WebAPI.Services;
using PetAdoptionMobileApplication.WebAPI.Services.Interfaces;

namespace PetAdoptionMobileApplication.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
				//(c =>
    //        {
    //            c.SwaggerDoc("v1", new Info { Title = "API WSVAP (WebSmartView)", Version = "v1" });
    //            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
    //        });

            builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(JwtOptions => JwtOptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration));


			var connectionString = builder.Configuration.GetConnectionString("Pet");
			builder.Services.AddDbContext<PetAppDbContext>(options => 
			options.UseSqlServer(connectionString), ServiceLifetime.Transient);

			builder.Services.AddTransient<IAuthService, AuthService>()
							.AddTransient<TokenService>()
							.AddTransient<IPetService, PetService>()
							.AddTransient<IUserPetService, UserPetService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				ApplyMigrations(app.Services); // Automatically run migration ONLY in development!
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseDeveloperExceptionPage();
			}
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseStaticFiles(); // allows for content to be served from wwwroot

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run("https://localhost:1234");

			static void ApplyMigrations(IServiceProvider serviceProvider)
			{
				using var scope = serviceProvider.CreateScope();

				var dbContext = scope.ServiceProvider.GetRequiredService<PetAppDbContext>();

				if (dbContext.Database.GetPendingMigrations().Any())
				{
					// run pending migrations automatically to the DB
					dbContext.Database.Migrate();
				}
			}
		}
	}
}