using Microsoft.AspNetCore.Mvc;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Services.Interfaces;

namespace PetAdoptionMobileApplication.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService authService;

		public AuthController(IAuthService authService)
        {
			this.authService = authService;
		}

		[HttpPost("login")] // api/auth/login
		public async Task<APIResponse<AuthenticationResponseDTO>> Login(LoginRequestDTO LRDTO) => await this.authService.LoginAsync(LRDTO);

		[HttpPost("register")] // api/auth/register
		public async Task<APIResponse<AuthenticationResponseDTO>> Register(RegisterRequestDTO RRDTO) => await this.authService.RegisterAsync(RRDTO);
	}
}
