using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMobileApplication.WebAPI.Data.Entities
{
	public class User
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required, MaxLength(50)]
		public string UserName { get; set; }
		[Required, MaxLength(150)]
		public string Email { get; set; }

		[Required, MaxLength(50)]
		public string Pass {  get; set; } // for production purpose implement hash and salt (below)

		//[Required, MaxLength(80)]
		//public string Hash { get; set; }
		//[Required, MaxLength(10)]
		//public string Salt { get; set; }
	}
}
