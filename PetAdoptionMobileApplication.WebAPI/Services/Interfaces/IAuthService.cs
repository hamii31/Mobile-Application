using PetAdoptionMobileApplication.Common.DTOs;

namespace PetAdoptionMobileApplication.WebAPI.Services.Interfaces
{
	public interface IAuthService
	{
		Task<APIResponse<AuthenticationResponseDTO>> LoginAsync(LoginRequestDTO LRDTO);
		Task<APIResponse<AuthenticationResponseDTO>> RegisterAsync(RegisterRequestDTO RRDTO);

		Task<APIResponse> ChangePasswordAsync(Guid userId, string password);
	}
}
