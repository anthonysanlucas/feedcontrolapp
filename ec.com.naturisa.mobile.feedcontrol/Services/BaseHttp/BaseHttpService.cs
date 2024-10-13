using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ec.com.naturisa.mobile.feedcontrol.Models.Api;

namespace ec.com.naturisa.mobile.feedcontrol.Services.BaseHttp
{
    public class BaseHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public BaseHttpService(string baseAddress)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        protected async Task<HttpResponseMessage> SendRequestAsync(
            HttpMethod method,
            string endpoint,
            HttpContent content = null
        )
        {
            var token = await SecureStorage.GetAsync("auth_token");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Bearer",
                    token
                );
            }

            var request = new HttpRequestMessage(method, endpoint) { Content = content };

            return await _httpClient.SendAsync(request);
        }

        protected async Task<ApiResponse<T>> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(
                    responseData,
                    _jsonSerializerOptions
                );
                return apiResponse
                    ?? new ApiResponse<T>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error en la deserialización",
                        Data = default
                    };
            }

            return new ApiResponse<T>
            {
                Code = (int)response.StatusCode,
                Message = "Error en la solicitud",
                Data = default
            };
        }
    }
}
