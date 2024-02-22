using Microsoft.AspNetCore.Mvc;
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


    }
}
