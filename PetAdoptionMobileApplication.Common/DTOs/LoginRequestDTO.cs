using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMobileApplication.Common.DTOs
{
	public class LoginRequestDTO
	{
		[Required, EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
