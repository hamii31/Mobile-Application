using Refit;

namespace PetAdoptionMobileApplication.Services
{
    public class AuthService
    {
        private readonly CommonService commonService;
        private readonly IAuthAPI authAPI;

        public AuthService(CommonService commonService, IAuthAPI authAPI)
        {
            this.commonService = commonService;
            this.authAPI = authAPI;
        }

        protected void SetUserAndToken(APIResponse<AuthenticationResponseDTO> APIResponse)
        {
            // Create user record
            var user = new LoggedInUserRecord(APIResponse.Data.UserId, APIResponse.Data.Name, APIResponse.Data.Token);

            // set user
            Preferences.Default.Set(UIConstants.UserInfo, user.ToJSON());

            // set token
            this.commonService.SetToken(user.Token);
        }

        public async Task<bool> LoginOrRegisterAsync(LoginModel model)
        {
            APIResponse<AuthenticationResponseDTO> APIResponse = null; // value will be assigned immediately after this call

            try
            {
                if (model.NewUser) // check if the user is new
                {
                    APIResponse = await this.authAPI.RegisterAsync(new RegisterRequestDTO
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Name = model.UserName
                    });
                }
                else // if user is not new, do this:
                {
                    APIResponse = await this.authAPI.LoginAsync(new LoginRequestDTO
                    {
                        Email = model.Email,
                        Password = model.Password
                    });
                }
            }
            catch (ApiException ex)
            {
                var errorMessage = ex.Content;

                if (errorMessage.Contains("Email")) // check if the error is related to the email format
                {
                    errorMessage = "Email was not in the correct format!";
                }

                await App.Current.MainPage.DisplayAlert("Error", errorMessage, "Ok");
                return false;
            }
            

            if (!APIResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", APIResponse.Message, "Ok");
                return APIResponse.IsSuccess; // returns false
            }

            SetUserAndToken(APIResponse);
            this.commonService.ToggleLoginStatus();
            return APIResponse.IsSuccess;
        }

        public void Logout()
        {
            this.commonService.SetToken(null);
            Preferences.Default.Remove(UIConstants.UserInfo);
            this.commonService.ToggleLoginStatus();
        }

        public LoggedInUserRecord GetUser()
        {
            var userJSON = Preferences.Default.Get(UIConstants.UserInfo, string.Empty);
            return LoggedInUserRecord.FromJSON(userJSON);
        }

        public bool IsLoggedIn => Preferences.Default.ContainsKey(UIConstants.UserInfo);
    }
}
