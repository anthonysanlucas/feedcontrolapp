namespace ec.com.naturisa.mobile.feedcontrol.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? _userName;

        [ObservableProperty]
        private string? _password;

        [ObservableProperty]
        private bool _isPassword = true;

        [ObservableProperty]
        private bool _isVisibleBtn = true;

        [ObservableProperty]
        private string? _imgBtnPassword = "icon_visibility_on.svg";

        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService, IToastService toastService)
            : base(toastService)
        {
            _authService = authService;
        }

        #region Commands

        [RelayCommand]
        async Task Login()
        {           
            if (IsBusy)
                return;

            await SecureStorage.Default.SetAsync("auth_token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYnR1ZmlubyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiMjAwNTEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9naXZlbm5hbWUiOiJCcnlhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJUdWZpw7FvIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiYnR1Zmlub0BuYXR1cmlzYS5jb20uZWMiLCJjb2RlQXBwbGljYWNpb24iOiJmZTFkNWI0ZC04MGViLTQ5NzgtYWM4MS1mZGEyMzRiOTEyNzUiLCJleHAiOjE3MzIwNjY0MzYsImlzcyI6Im5hdHVyaXNhLmNvbS5lYyIsImF1ZCI6ImFwaS1jb3JlIn0.Nui2eVT89fpe9OdFimiK7QJGhRSuPyFtsYABtFk1is4");

            await Shell.Current.GoToAsync($"//{nameof(FeedingPoolView)}");

            return;

            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                await ShowToastAsync("Usuario o contraseña no pueden estar vacíos.");
                return;
            }

            LoginByUserRequest loginByUserRequest =
                new()
                {
                    UserName = UserName.Trim(),
                    Password = Password.Trim(),
                    CodeApplication = Guid.Parse("FE1D5B4D-80EB-4978-AC81-FDA234B91275"),
                    IncludeUserInfo = true,
                    CodeTwoFactorAuthenticator = null
                };

            try
            {
                IsBusy = true;
                IsVisibleBtn = false;

                AuthenticationData loginResponse = await _authService.Auth(loginByUserRequest);               

                await SecureStorage.Default.SetAsync("auth_token", loginResponse.Token);                
               
                Preferences.Set(nameof(App.UserData), JsonSerializer.Serialize(loginResponse.User));

                // User data that remains persistent throughout the application's lifecycle
                App.UserData = loginResponse.User;

                if (loginResponse != null)
                {
                    UserName = string.Empty;
                    Password = string.Empty;

                    await Shell.Current.GoToAsync($"//{nameof(FeedingPoolView)}");
                }
                else
                {
                    await ShowToastAsync("Usuario o contraseña incorrectos.");
                }                
            }
            catch (Exception)
            {
                await ShowToastAsync("Error al iniciar sesión: Intente nuevamente.");
            }
            finally
            {
                IsBusy = false;
                IsVisibleBtn = true;
            }
        }

        [RelayCommand]
        Task ShowPasswordEntry()
        {
            IsPassword = !IsPassword;
            ImgBtnPassword = IsPassword ? "icon_visibility_on.svg" : "icon_visibility_off.svg";

            return Task.CompletedTask;
        }
        #endregion
    }
}
