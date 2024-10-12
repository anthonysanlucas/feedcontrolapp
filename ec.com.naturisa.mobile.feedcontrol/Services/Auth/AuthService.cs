namespace ec.com.naturisa.mobile.feedcontrol.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _authHttpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public AuthService()
        {
            _authHttpClient = new HttpClient { BaseAddress = new Uri(ApiConstants.AUTH_URL) };
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<AuthenticationData> Auth(LoginByUserRequest loginByUserRequest)
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

                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<AuthenticationData>>(
                        jsonResponse,
                        _jsonSerializerOptions
                    );

                    if (apiResponse != null && apiResponse.Code == 200 && apiResponse.Data != null)
                    {
                        return apiResponse.Data;
                    }
                    else
                    {
                        throw new Exception(
                            $"Error de autenticación: Código {apiResponse?.Code} - {apiResponse?.Message}"
                        );
                    }
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
                throw new Exception($"Error de red: {httpEx.Message}", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Error al conectar con el servicio de autenticación: {ex.Message}",
                    ex
                );
            }
        }
    }
}
