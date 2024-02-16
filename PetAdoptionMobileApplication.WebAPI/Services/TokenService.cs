using Microsoft.IdentityModel.Tokens;
using PetAdoptionMobileApplication.WebAPI.Data.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetAdoptionMobileApplication.WebAPI.Services
{
	public class TokenService
	{
		private readonly IConfiguration configuration;

		public TokenService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration) =>
			new()
			{
				ValidateIssuer = true,
				ValidateAudience = false,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = configuration["Jwt:Issuer"],
				IssuerSigningKey = GetSecurityKey(configuration)
			};

		public string GenerateJWT(IEnumerable<Claim>? additionalClaims = null)
		{
			var securityKey = GetSecurityKey(this.configuration);
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var expireMinutes = Convert.ToInt32(this.configuration["Jwt:ExpireMinutes"] ?? "60");

			var claims = new List<Claim>()
			{
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			if (additionalClaims!.Any() == true)
			{
				claims.AddRange(additionalClaims!);
			}

			var token = new JwtSecurityToken(issuer: this.configuration["Jwt:Issuer"], audience: "*", claims: claims,
				expires: DateTime.Now.AddMinutes(expireMinutes), signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public string GenerateJWT(User user, IEnumerable<Claim>? additionalClaims = null)
		{
			var claims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.UserName)
				};
			if (additionalClaims?.Any() == true)
				claims.AddRange(additionalClaims!);

			return GenerateJWT(claims);
		}

		private static SymmetricSecurityKey GetSecurityKey(IConfiguration configuration) =>
		  new(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
	}
}
