using PetAdoptionMobileApplication.Common.DTOs;
using PetAdoptionMobileApplication.WebAPI.Data.Entities;
using System.Linq.Expressions;

namespace PetAdoptionMobileApplication.WebAPI.Extensions
{
    public static class Mappers
	{
		public static Expression<Func<Pet, PetListDTO>> PetEntityToPetListDTO =>
			pet => new PetListDTO
			{
				Id = pet.Id,
				Name = pet.PetName,
				Price = pet.Price,
				Image = pet.Image, //$"{AppConstants.BaseAPIUrl}/images/pets/{pet.Image}" <- Doesn't work because the dev tunnel is fubar for some reason
                Breed = pet.Breed
			};

		public static PetInfoDTO MapToPetInfoDTO(this Pet pet) =>
			new PetInfoDTO
			{
				Id = pet.Id,
				Name = pet.PetName,
				Price = pet.Price,
				Image = pet.Image, //$"{AppConstants.BaseAPIUrl}/images/pets/{pet.Image}" <- Doesn't work because the dev tunnel is fubar for some reason
                Breed = pet.Breed,
				Description = pet.Description,
				Gender = pet.Gender,
				AdoptionStatus = pet.AdoptionStatus,
				BirthDate = pet.BirthDate

			};
	}
}
