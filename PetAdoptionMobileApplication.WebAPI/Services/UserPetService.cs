using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.Common.Enums;
using PetAdoptionMobileApplication.WebAPI.Data;
using PetAdoptionMobileApplication.WebAPI.Data.Entities;
using PetAdoptionMobileApplication.WebAPI.Extensions;

namespace PetAdoptionMobileApplication.WebAPI.Services
{
	public class UserPetService
	{
		private static readonly SemaphoreSlim semaphoreSlim = new (1, 1);
		private readonly PetAppDbContext dbContext;

		public UserPetService(PetAppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
		public async Task<APIResponse> AddOrRemoveFromFavPetsAsync(Guid userId, Guid petId)
		{
			try
			{
				var userFavourite = await this.dbContext.Favs.FirstOrDefaultAsync(uf => uf.UserId == userId && uf.PetId == petId);

				if (userFavourite != null) // we remove it in this case
				{
					this.dbContext.Favs.Remove(userFavourite);
				}
				else
				{
					userFavourite = new UserFavs()
					{
						UserId = userId,
						PetId = petId
					};

					await this.dbContext.Favs.AddAsync(userFavourite);
				}

				await this.dbContext.SaveChangesAsync();
				return APIResponse.Success();
			}
			catch (Exception e)
			{
				return APIResponse.Fail("An error occured while executing this task! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetAllFavPetsAsync(Guid userId)
		{
			try
			{
				var favPets = await this.dbContext.Favs.Where(fp => fp.UserId == userId).Select(fp => fp.Pet).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!favPets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("This user has no favourite pets!");
				}

				return APIResponse<PetListDTO[]>.Success(favPets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while fetching this data! " + e.Message);
			}
		}
		public async Task<APIResponse<PetListDTO[]>> GetUserAdoptionsAsync(Guid userId)
		{
			try
			{
				var favPets = await this.dbContext.Adoptions.Where(fp => fp.UserId == userId).Select(fp => fp.Pet).Select(Mappers.PetEntityToPetListDTO).ToArrayAsync();

				if (!favPets.Any())
				{
					return APIResponse<PetListDTO[]>.Fail("User has no favourite pets. Add some!");
				}

				return APIResponse<PetListDTO[]>.Success(favPets);
			}
			catch (Exception e)
			{
				return APIResponse<PetListDTO[]>.Fail("An error occured while fetching this data! " + e.Message);
			}
		}
		public async Task<APIResponse> AdoptPetAsync(Guid userId, Guid petId)
		{
			try
			{
				await semaphoreSlim.WaitAsync(); // adopting a specific pet should be available to one user at a time,
												 // hence using semaphore to bottleneck the requests.
												 //
												 // Example: Two requests are made for adopting one pet, the first one to reach this method will be forwarded, while the second will wait for the first one to finish.

				var pet = await this.dbContext.Pets.AsTracking().FirstOrDefaultAsync(p => p.Id == petId);

				if (pet == null)
				{
					return APIResponse.Fail("Invalid request.");
				}

				if (pet.AdoptionStatus == AdoptionStatus.Unavailable)
				{
					return APIResponse.Fail($"{pet.PetName} is already adopted!");
				}

				pet.AdoptionStatus = AdoptionStatus.Unavailable; // the pet is now adopted

				var adoption = new UserAdoptions
				{
					UserId = userId,
					PetId = petId,
					AdoptedOn = DateTime.UtcNow
				};

				await this.dbContext.Adoptions.AddAsync(adoption);
				await this.dbContext.SaveChangesAsync();

				return APIResponse.Success();
			}
			catch (Exception e)
			{
				return APIResponse.Fail("An error occured while adopting this pet. " + e.Message);
			}
			finally
			{
				semaphoreSlim.Release(); // release after either the task succeeds or fails
			}

		}
	}
}
