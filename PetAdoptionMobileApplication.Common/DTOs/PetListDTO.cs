namespace PetAdoptionMobileApplication.Common.DTOs
{
	public class PetListDTO
	{
		public Guid Id {  get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
		public double Price { get; set; }
		public string Breed { get; set; }
	}
}
