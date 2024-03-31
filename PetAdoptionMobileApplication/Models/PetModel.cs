namespace PetAdoptionMobileApplication.Models
{
    public partial class PetModel : ObservableObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Breed { get; set; }
        public Gender Gender {  get; set; }
        public string Description { get; set; }
        public string GenderDisplay { get; set; }
        public string GenderImage { get; set; }
        public string Age {  get; set; }

        [ObservableProperty]
        private bool isFav;

        [ObservableProperty]
        private AdoptionStatus adoptionStatus;
    }
}
