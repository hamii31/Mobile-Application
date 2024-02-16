using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.WebAPI.Data.Entities;
using PetAdoptionMobileApplication.Common.Enums;

namespace PetAdoptionMobileApplication.WebAPI.Data
{
	public class PetAppDbContext : DbContext
	{
		public PetAppDbContext(DbContextOptions<PetAppDbContext> options) : base(options)
		{
		}

		public DbSet<Pet> Pets { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserFavs> Favs { get; set; }
		public DbSet<UserAdoptions> Adoptions { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // performance boosting
#if DEBUG
			optionsBuilder.LogTo(Console.WriteLine);
#endif
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserFavs>()
						.HasKey(f => new { f.UserId, f.PetId });

			modelBuilder.Entity<Pet>().HasData(InitialPetData());
		}

		private static List<Pet> InitialPetData()
		{
			var pets = new List<Pet>()
			{
				new Pet
				{
					Id = Guid.NewGuid(),
					PetName = "Bushu",
					Breed = "Dog - Alaskan Klee Kai",
					Price = 250,
					Description = "loyal, intelligent, vigilant",
					Gender = Gender.Male,
					Image = "alaskan_klee_kai.jpg",
					BirthDate = new DateTime(2015, 09, 24),
					IsActive = true
				},
				new Pet
				{
					Id = Guid.NewGuid(),
					PetName = "Ioana",
					Breed = "Cat - Siamese",
					Price = 5000,
					Description = "judgemental, loving, intelligent, fighter",
					Gender = Gender.Female,
					Image = "ioana.png",
					BirthDate = new DateTime(2007, 05, 15),
					IsActive = true
				},
				new Pet
				{
					Id = Guid.NewGuid(),
					PetName = "Jack",
					Breed = "Dog - Belgian Malinois",
					Price = 500,
					Description = "confident, smart, hardworking",
					Gender = Gender.Male,
					Image = "jack.jpg",
					BirthDate = new DateTime(2020, 02, 03),
					IsActive = true
				},
				new Pet
				{
					Id = Guid.NewGuid(),
					PetName = "Pearl",
					Breed = "Cat - Snowshoe",
					Price = 500,
					Description = "Loving, curious, family-oriented, vocal",
					Gender = Gender.Female,
					Image = "pearl.jpg",
					BirthDate = new DateTime(2017, 12, 20),
					IsActive = true
				}
			};

			return pets;
		}
	}
}
