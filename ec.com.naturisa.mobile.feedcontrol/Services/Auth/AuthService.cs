using System.Text.Json;

namespace ec.com.naturisa.mobile.feedcontrol.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _authHttpClient;

        public AuthService()
        {
            _authHttpClient = new HttpClient { BaseAddress = new Uri(ApiConstants.AUTH_URL) };
        }

        public async Task<LoginResponse> Auth(LoginByUserRequest loginByUserRequest)
        {
            try
            {
                var jsonRequest = JsonSerializer.Serialize(loginByUserRequest);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _authHttpClient.PostAsync(
                    $"{ApiConstants.AUTH_URL}/api/auth",
                    content
                );

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    LoginResponse data = JsonSerializer.Deserialize<LoginResponse>(jsonResponse);

                    return data;
                }
                else
                {
                    throw new Exception(
                        $"Error de autenticación: {response.StatusCode} - {response.ReasonPhrase}"
                    );
                }
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"Error de red: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error al conectar con el servicio de autenticación: {ex.Message}"
                );
            }
        }
    }
}
