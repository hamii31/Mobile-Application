
using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.WebAPI.Data;

namespace PetAdoptionMobileApplication.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var connectionString = builder.Configuration.GetConnectionString("Pet");
			builder.Services.AddDbContext<PetAppDbContext>(options => 
			options.UseSqlServer(connectionString), ServiceLifetime.Transient);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				ApplyMigrations(app.Services); // Automatically run migration ONLY in development!
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();

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