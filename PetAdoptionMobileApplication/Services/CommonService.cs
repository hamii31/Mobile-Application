namespace PetAdoptionMobileApplication.Services
{
    public class CommonService
    {
        public string? Token { get; private set; } // private set to control who sets the value

        public void SetToken(string? token) => Token = token;
    }
}
