using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Data;
using PetAdoptionMobileApplication.WebAPI.Data.Entities;

namespace PetAdoptionMobileApplication.WebAPI.Services
{
	public class UserPetService
	{
		private readonly PetAppDbContext dbContext;

		public UserPetService(PetAppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		public async Task<APIResponse> AddOrRemoveFromFavPetsAsync(Guid userId, Guid petId)
		{
			var userFavourite = await this.dbContext.Favs.FirstOrDefaultAsync(uf => uf.UserId == userId && uf.PetId == petId);

			if(userFavourite != null) // we remove it in this case
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
    }
}
