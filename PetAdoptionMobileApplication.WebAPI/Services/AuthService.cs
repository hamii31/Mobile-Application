using Microsoft.EntityFrameworkCore;
using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Data;

namespace PetAdoptionMobileApplication.WebAPI.Services
{
	public class AuthService
	{
		private readonly PetAppDbContext dbContext;
		private readonly TokenService tokenService;

		public AuthService(PetAppDbContext dbContext, TokenService tokenService)
        {
			this.dbContext = dbContext;
			this.tokenService = tokenService;
		}

		public async Task<APIResponse<AuthenticationResponseDTO>> LoginAsync(LoginRequestDTO LRDTO)
		{
			var user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Email == LRDTO.Email);

			if (user == null)
			{
				return APIResponse<AuthenticationResponseDTO>.Fail("User doesn't exist!");
			}
			else if(user.Pass != LRDTO.Password)
			{
				return APIResponse<AuthenticationResponseDTO>.Fail("Password is not correct!");
			}

			var token = this.tokenService.GenerateJWT(user);

			return APIResponse<AuthenticationResponseDTO>.Success(new AuthenticationResponseDTO(user.Id, user.UserName, token));
		}
    }
}
