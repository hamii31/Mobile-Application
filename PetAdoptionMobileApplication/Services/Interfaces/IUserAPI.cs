using PetAdoptionMobileApplication.Common.DTOs;
using Refit;

namespace PetAdoptionMobileApplication.Services.Interfaces
{
    [Headers("Authorization: Bearer")]
    public interface IUserAPI
    {
        [Post("/api/user/favourites/{petId}")] // api/user/favourites/petId
        Task<APIResponse> AddOrRemoveFromFavPetsAsync(Guid petId);

        [Get("/api/user/favourites")] // api/user/favourites
        Task<APIResponse<PetListDTO[]>> GetAllFavPetsAsync();

        [Get("/api/user/adoptions")] // api/user/adoptions
        Task<APIResponse<PetListDTO[]>> GetUserAdoptionsAsync();

        [Post("/api/user/adopt/{petId}")] // api/user/adopt/petId
        Task<APIResponse> AdoptPetAsync(Guid petId);
    }
}
