using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetAdoptionMobileApplication.Common.Enums;

namespace PetAdoptionMobileApplication.WebAPI.Data.Entities
{
	public class Pet
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required, MaxLength(100)]
		public string PetName { get; set; }
		[Required, MaxLength(255)]
		public string Image {  get; set; }
		[Required, MaxLength(100)]
		public string? Breed { get; set; }
		[Required]
		public Gender Gender { get; set; }
		[Required, Range(0, double.MaxValue)]
		public double Price { get; set; }

		public DateTime BirthDate { get; set; }

		[Required]
		public string Description {  get; set; }
		public int View {  get; set; }

		public AdoptionStatus AdoptionStatus { get; set; } = AdoptionStatus.Available;
		public bool IsActive { get; set; } // for soft delete

	}
}
