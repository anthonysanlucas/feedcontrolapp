namespace ec.com.naturisa.mobile.feedcontrol.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthenticationData> Auth(LoginByUserRequest loginByUserRequest);
    }
}
