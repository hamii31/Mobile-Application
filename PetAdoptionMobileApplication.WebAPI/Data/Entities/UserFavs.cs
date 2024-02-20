namespace PetAdoptionMobileApplication.WebAPI.Data.Entities
{
	public class UserFavs
	{
		public Guid UserId { get; set; }
		public Guid PetId { get; set; }
		public virtual User User { get; set; }
		public virtual Pet Pet { get; set; }
	}
}
