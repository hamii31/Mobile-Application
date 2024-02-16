namespace PetAdoptionMobileApplication.WebAPI.Data.Entities
{
	public class UserFavs
	{
		public int UserId { get; set; }
		public int PetId { get; set; }
		public virtual User User { get; set; }
		public virtual Pet Pet { get; set; }
	}
}
