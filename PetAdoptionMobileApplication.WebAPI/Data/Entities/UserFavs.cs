using System.ComponentModel.DataAnnotations;

namespace PetAdoptionMobileApplication.WebAPI.Data.Entities
{
    public class UserFavs
	{
		[Key]
		public int Id { get; set; }
        public Guid UserId { get; set; }
		public Guid PetId { get; set; }
		public virtual User User { get; set; }
		public virtual Pet Pet { get; set; }
	}
}
