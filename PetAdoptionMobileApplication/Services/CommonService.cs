namespace PetAdoptionMobileApplication.Services
{
    public class CommonService
    {
        public string? Token { get; private set; } // private set to control who sets the value

        public void SetToken(string? token) => Token = token;

        public event EventHandler LoginStatusChanged;

        public void ToggleLoginStatus() => LoginStatusChanged?.Invoke(this, EventArgs.Empty);
    }
}
