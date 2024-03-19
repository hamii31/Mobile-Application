using PetAdoptionMobileApplication.Common.DTOs;

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
            APIResponse<AuthenticationResponseDTO> APIResponse;

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
            

            if (!APIResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", APIResponse.Message, "Ok");
                return APIResponse.IsSuccess; // return false
            }

            SetUserAndToken(APIResponse);
            return APIResponse.IsSuccess;
        }

        public async Task Logout()
        {
            this.commonService.SetToken(null);
            Preferences.Default.Remove(UIConstants.UserInfo);
        }

        public LoggedInUserRecord GetUser()
        {
            var userJSON = Preferences.Default.Get(UIConstants.UserInfo, string.Empty);
            return LoggedInUserRecord.FromJSON(userJSON);
        }

        public bool IsLoggedIn => Preferences.Default.ContainsKey(UIConstants.UserInfo);
    }
}
