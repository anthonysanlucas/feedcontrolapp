﻿using System.Net.Http.Headers;

namespace ec.com.naturisa.mobile.feedcontrol.Services.BaseHttp
{
    public class BaseHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public BaseHttpService(string baseAddress)
        {
            _httpClient = new HttpClient
            { 
                BaseAddress = new Uri(baseAddress),                
            };
          
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
            request.Headers.Add("ngrok-skip-browser-warning", "1");
            request.Headers.UserAgent.ParseAdd("feedControl/1.0");

            try
            {
                return await _httpClient.SendAsync(request);
            }
            catch (TaskCanceledException)
            {               
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.RequestTimeout,
                    ReasonPhrase = "Tiempo de espera alcanzado"
                };
            }
            catch (Exception ex)
            {               
                throw new Exception($"Error en la solicitud: {ex.Message}", ex);
            }
        }

        protected async Task<ApiResponse<T>> ProcessResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();

                try
                {                   
                    var isPagedResponse =
                        typeof(T).IsGenericType
                        && typeof(T).GetGenericTypeDefinition() == typeof(PagedApiResponse<>);
                 
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(responseData, _jsonSerializerOptions);

                    return apiResponse ?? new ApiResponse<T>
                    {
                        Code = (int)response.StatusCode,
                        Message = "Error en la deserialización",
                        Data = default
                    };
                }
                catch (JsonException ex)
                {
                    throw new Exception("Error al deserializar la respuesta JSON", ex);
                }
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
