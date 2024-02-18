using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Data;
using PetAdoptionMobileApplication.WebAPI.Extensions;

namespace PetAdoptionMobileApplication.WebAPI.Services
{
	public class PetService
	{
		private readonly PetAppDbContext dbContext;

		public PetService(PetAppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		public async Task<APIResponse<PetListDTO[]>> GetTheMostAffordablePetsAsync (int count)
		{
			var pets = await this.dbContext.Pets.Select(Mappers.PetEntityToPetListDTO).OrderByDescending(p => p.Price).Take(count).ToArrayAsync();

			if (!pets.Any())
			{
				return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
			}

			return APIResponse<PetListDTO[]>.Success(pets);
		}

		public async Task<APIResponse<PetListDTO[]>> GetPopularPetsAsync (int count)
		{
			var pets = await this.dbContext.Pets.OrderByDescending(p => p.View).Take(count).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

			if (!pets.Any())
			{
				return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
			}

			return APIResponse<PetListDTO[]>.Success(pets);
		}

		public async Task<APIResponse<PetListDTO[]>> GetRandomPetsAsync(int count)
		{
			var pets = await this.dbContext.Pets.OrderBy(p => Guid.NewGuid()).Take(count).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

			if (!pets.Any())
			{
				return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
			}

			return APIResponse<PetListDTO[]>.Success(pets);
		}

		public async Task<APIResponse<PetListDTO[]>> GetAllPets()
		{
			var pets = await this.dbContext.Pets.Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

			if (!pets.Any())
			{
				return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
			}

			return APIResponse<PetListDTO[]>.Success(pets);
		}
		public async Task<APIResponse<PetInfoDTO>> GetPetInformationAsync(Guid Id)
		{
			var pet = await this.dbContext.Pets.AsTracking() // to increase view count for the pet
											   .FirstOrDefaultAsync(p => p.Id == Id);

			if(pet == null)
			{
				return APIResponse<PetInfoDTO>.Fail("Pet doesn't exist in the database!");
			}

			if (pet != null)
			{
				pet.View++;
				await this.dbContext.SaveChangesAsync();
			}

			var petDTO = pet!.MapToPetInfoDTO();

			return APIResponse<PetInfoDTO>.Success(petDTO);
		}

		// Add GetByAge and GetByLeastPopular
	}
}
