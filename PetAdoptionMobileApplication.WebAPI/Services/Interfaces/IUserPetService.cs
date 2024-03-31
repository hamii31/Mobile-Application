using PetAdoptionMobileApplication.Common.DTOs;

namespace PetAdoptionMobileApplication.WebAPI.Services.Interfaces
{
	public interface IUserPetService
	{
		Task<APIResponse> AddOrRemoveFromFavPetsAsync(Guid userId, string petId);
		Task<APIResponse<PetListDTO[]>> GetAllFavPetsAsync(Guid userId);
		Task<APIResponse<PetListDTO[]>> GetUserAdoptionsAsync(Guid userId);
		Task<APIResponse> AdoptPetAsync(Guid userId, string petId);
    }
}
