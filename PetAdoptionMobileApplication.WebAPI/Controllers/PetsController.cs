using Microsoft.AspNetCore.Mvc;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Services.Interfaces;

namespace PetAdoptionMobileApplication.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PetsController : ControllerBase
	{
		private readonly IPetService petService;

		public PetsController(IPetService petService)
        {
			this.petService = petService;
		}

		[HttpGet("affordable/{count:int}")] // api/pets/affordable/5
		public async Task<APIResponse<PetListDTO[]>> GetTheMostAffordablePetsAsync(int count) 
			=> await this.petService.GetTheMostAffordablePetsAsync(count);

		[HttpGet("popular/{count:int}")] // api/pets/popular/5
		public async Task<APIResponse<PetListDTO[]>> GetPopularPetsAsync(int count) 
			=> await this.petService.GetPopularPetsAsync(count);

		[HttpGet("unpopular/{count:int}")] // api/pets/unpopular/5
		public async Task<APIResponse<PetListDTO[]>> GetLeastPopularPetsAsync(int count) 
			=> await this.petService.GetLeastPopularPetsAsync(count);

		[HttpGet("random/{count:int}")] // api/pets/random/5
		public async Task<APIResponse<PetListDTO[]>> GetRandomPetsAsync(int count) 
			=> await this.petService.GetRandomPetsAsync(count);

		[HttpGet("")] // api/pets
		public async Task<APIResponse<PetListDTO[]>> GetAllPetsAsync() 
			=> await this.petService.GetAllPetsAsync();

		[HttpGet("info/{id}")] // api/pets/info/Id
		public async Task<APIResponse<PetInfoDTO>> GetPetInformationAsync(string Id) 
			=> await this.petService.GetPetInformationAsync(Id);

		[HttpGet("youngest/{count:int}")] // api/pets/youngest/5
		public async Task<APIResponse<PetListDTO[]>> GetYoungestPetsAsync(int count) 
			=> await this.petService.GetYoungestPetsAsync(count);

		[HttpGet("oldest/{count:int}")] // api/pets/oldest/5
		public async Task<APIResponse<PetListDTO[]>> GetOldestPetsAsync(int count) 
			=> await this.petService.GetOldestPetsAsync(count);

		[HttpGet("{gender}")] // api/pets/gender
		public async Task<APIResponse<PetListDTO[]>> GetPetsByGender(string gender) 
			=> await this.petService.GetPetsByGender(gender);

	}
}
