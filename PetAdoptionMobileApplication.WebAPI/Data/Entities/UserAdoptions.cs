using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoptionMobileApplication.WebAPI.Data.Entities
{
	public class UserAdoptions
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid PetId { get; set; }
		public DateTime AdoptedOn { get; set; }
		public virtual User User { get; set; }
		public virtual Pet Pet { get; set; }
	}
}
