using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMobileApplication.Common.DTOs
{
	public class RegisterRequestDTO : LoginRequestDTO
	{
		[Required]
		public string Name { get; set; }
	}
}
