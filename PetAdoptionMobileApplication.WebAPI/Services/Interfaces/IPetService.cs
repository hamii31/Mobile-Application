using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.Common.Enums;

namespace PetAdoptionMobileApplication.WebAPI.Services.Interfaces
{
	public interface IPetService
	{
		Task<APIResponse<PetListDTO[]>> GetTheMostAffordablePetsAsync(int count);
		Task<APIResponse<PetListDTO[]>> GetPopularPetsAsync(int count);
		Task<APIResponse<PetListDTO[]>> GetLeastPopularPetsAsync(int count);
		Task<APIResponse<PetListDTO[]>> GetRandomPetsAsync(int count);
		Task<APIResponse<PetListDTO[]>> GetAllPetsAsync();
		Task<APIResponse<PetInfoDTO>> GetPetInformationAsync(Guid Id);
		Task<APIResponse<PetListDTO[]>> GetYoungestPetsAsync(int count);
		Task<APIResponse<PetListDTO[]>> GetOldestPetsAsync(int count);
		Task<APIResponse<PetListDTO[]>> GetPetsByGender(Gender gender);
	}
}
