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
            await Shell.Current.GoToAsync($"//{nameof(FeedingPoolView)}");

            return;

            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                IsVisibleBtn = false;

                LoginByUserRequest loginByUserRequest =
                    new()
                    {
                        UserName = UserName.Trim(),
                        Password = Password.Trim(),
                        CodeApplication = Guid.Parse("FE1D5B4D-80EB-4978-AC81-FDA234B91275"),
                        IncludeUserInfo = true,
                        CodeTwoFactorAuthenticator = null
                    };

                LoginResponse loginResponse = await _authService.Auth(loginByUserRequest);

                if (loginResponse != null)
                {
                    //await Shell.Current.GoToAsync("///FeedingPool");
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
