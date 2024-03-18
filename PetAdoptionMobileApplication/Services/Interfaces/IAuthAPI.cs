using PetAdoptionMobileApplication.Common.DTOs;
using Refit;

namespace PetAdoptionMobileApplication.Services.Interfaces
{
    public interface IAuthAPI
    {
        [Post("api/auth/login")]
        Task<APIResponse<AuthenticationResponseDTO>> LoginAsync(LoginRequestDTO LRDTO);

        [Post("api/auth/register")]
        Task<APIResponse<AuthenticationResponseDTO>> RegisterAsync(RegisterRequestDTO RRDTO);
    }
}
