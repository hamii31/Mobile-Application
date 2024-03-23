using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Data;
using PetAdoptionMobileApplication.WebAPI.Extensions;
using PetAdoptionMobileApplication.WebAPI.Services.Interfaces;

namespace PetAdoptionMobileApplication.WebAPI.Services
{
	public class PetService : IPetService
	{
		private readonly PetAppDbContext dbContext;

		public PetService(PetAppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<APIResponse<PetListDTO[]>> GetTheMostAffordablePetsAsync(int count)
		{
			try
			{
				var pets = await this.dbContext.Pets.Select(Mappers.PetEntityToPetListDTO).OrderBy(p => p.Price).Take(count).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetPopularPetsAsync(int count)
		{
			try
			{
				var pets = await this.dbContext.Pets.OrderByDescending(p => p.View).Take(count).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetLeastPopularPetsAsync(int count)
		{
			try
			{
				var pets = await this.dbContext.Pets.OrderBy(p => p.View).Take(count).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetRandomPetsAsync(int count)
		{
			try
			{
				var pets = await this.dbContext.Pets.OrderBy(p => Guid.NewGuid()).Where(p => p.PetName != "Ioana").Take(count).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetAllPetsAsync()
		{
			try
			{
				var pets = await this.dbContext.Pets.Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetInfoDTO>> GetPetInformationAsync(Guid Id)
		{
			try
			{
				var pet = await this.dbContext.Pets.AsTracking() // to increase view count for the pet
											   .FirstOrDefaultAsync(p => p.Id == Id);

				if (pet == null)
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
			catch (Exception e)
			{
				return APIResponse<PetInfoDTO>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetYoungestPetsAsync(int count)
		{
			try
			{
				var pets = await this.dbContext.Pets.OrderByDescending(p => p.BirthDate).Take(count).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetOldestPetsAsync(int count)
		{
			try
			{
				var pets = await this.dbContext.Pets.OrderBy(p => p.BirthDate).Take(count).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetPetsByGender(string gender)
		{
			try
			{
				var pets = await this.dbContext.Pets.Where(p => p.Gender.ToString() == gender.ToLower()).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!pets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("There was an error while processing this task!");
				}

				return APIResponse<PetListDTO[]>.Success(pets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		
	}
}
