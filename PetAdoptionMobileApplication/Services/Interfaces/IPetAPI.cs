using PetAdoptionMobileApplication.Common.DTOs;
using Refit;

namespace PetAdoptionMobileApplication.Services.Interfaces
{
    public interface IPetAPI
    {
        [Get("api/pets/affordable/{count:int}")] // api/pets/affordable/5
        Task<APIResponse<PetListDTO[]>> GetTheMostAffordablePetsAsync(int count);

        [Get("api/pets/popular/{count:int}")] // api/pets/popular/5
        Task<APIResponse<PetListDTO[]>> GetPopularPetsAsync(int count);

        [Get("api/pets/unpopular/{count:int}")] // api/pets/unpopular/5
        Task<APIResponse<PetListDTO[]>> GetLeastPopularPetsAsync(int count);

        [Get("api/pets/random/{count:int}")] // api/pets/random/5
        Task<APIResponse<PetListDTO[]>> GetRandomPetsAsync(int count);

        [Get("api/pets")] // api/pets
        Task<APIResponse<PetListDTO[]>> GetAllPetsAsync();

        [Get("api/pets{Id:Guid}")] // api/pets/Id
        Task<APIResponse<PetInfoDTO>> GetPetInformationAsync(Guid Id);

        [Get("api/pets/youngest/{count:int}")] // api/pets/youngest/5
        Task<APIResponse<PetListDTO[]>> GetYoungestPetsAsync(int count);

        [Get("api/pets/oldest/{count:int}")] // api/pets/oldest/5
        Task<APIResponse<PetListDTO[]>> GetOldestPetsAsync(int count);

        [Get("api/pets/{gender}")] // api/pets/gender
        Task<APIResponse<PetListDTO[]>> GetPetsByGender(string gender);

    }
}
