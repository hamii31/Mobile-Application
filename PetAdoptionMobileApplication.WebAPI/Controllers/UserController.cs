using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Services.Interfaces;
using System.Security.Claims;

namespace PetAdoptionMobileApplication.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserController : ControllerBase
	{
		private readonly IUserPetService userPetService;
        private readonly IPetService petService;

        public UserController(IUserPetService userPetService, IPetService petService)
        {
			this.userPetService = userPetService;
            this.petService = petService;
        }

        private Guid UserId => Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        [HttpPost("favourites/{petId}")] // api/user/favourites/petId
		public async Task<APIResponse> AddOrRemoveFromFavPetsAsync(string petId) 
			=> await this.userPetService.AddOrRemoveFromFavPetsAsync(UserId, petId);

		[HttpGet("favourites")] // api/user/favourites
		public async Task<APIResponse<PetListDTO[]>> GetAllFavPetsAsync() 
			=> await this.userPetService.GetAllFavPetsAsync(UserId);

		[HttpGet("adoptions")] // api/user/adoptions
		public async Task<APIResponse<PetListDTO[]>> GetUserAdoptionsAsync()
			=> await this.userPetService.GetUserAdoptionsAsync(UserId);

		[HttpPost("adopt/{petId}")] // api/user/adopt/petId
		public async Task<APIResponse> AdoptPetAsync(string petId)
			=> await this.userPetService.AdoptPetAsync(UserId, petId);

        [HttpGet("pet-info/{petId}")] // api/user/pet-info/petId
        public async Task<APIResponse<PetInfoDTO>> GetPetInformationAsync(string petId)
            => await this.petService.GetPetInformationAsync(petId, UserId);
    }
}
