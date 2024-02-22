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

		public UserController(IUserPetService userPetService)
        {
			this.userPetService = userPetService;
		}

		private Guid UserId => Guid.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

		[HttpPost("favourites/{petId:Guid}")] // api/user/favourites/petId
		public async Task<APIResponse> AddOrRemoveFromFavPetsAsync(Guid petId) 
			=> await this.userPetService.AddOrRemoveFromFavPetsAsync(UserId, petId);

		[HttpGet("favourites")] // api/user/favourites
		public async Task<APIResponse<PetListDTO[]>> GetAllFavPetsAsync() 
			=> await this.userPetService.GetAllFavPetsAsync(UserId);

		[HttpGet("adoptions")] // api/user/adoptions
		public async Task<APIResponse<PetListDTO[]>> GetUserAdoptionsAsync()
			=> await this.userPetService.GetUserAdoptionsAsync(UserId);

		[HttpPost("adopt/{petId:Guid}")] // api/user/adopt/petId
		public async Task<APIResponse> AdoptPetAsync(Guid petId)
			=> await this.userPetService.AdoptPetAsync(UserId, petId);
	}
}
