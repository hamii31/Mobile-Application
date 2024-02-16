namespace PetAdoptionMobileApplication.Common.DTOs
{
	public record AuthenticationResponseDTO(Guid UserId, string Name, string Token);
}
