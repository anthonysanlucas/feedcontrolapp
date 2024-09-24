using ec.com.naturisa.mobile.feedcontrol.Models.Auth;

namespace ec.com.naturisa.mobile.feedcontrol.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> Auth(LoginByUserRequest loginByUserRequest);
    }
}
