using System.Net.Http.Headers;

namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer
{
    public class FeedTransferService : IFeedTransferService
    {
        private readonly HttpClient _feedTransferHttpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        private static class FeedTransferEnpoints
        {
            public const string FeedTransfer = "/feed_transfers";
            public const string FeedTransferDetails = "/feed_transfer_details";
            public const string FeedTransferDetailPools = "/feed_transfer_detail_pools";
        }

        public FeedTransferService()
        {
            _feedTransferHttpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiConstants.API_FEED_CONTROL)
            };

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<HttpResponseMessage> GetFeedTransfers()
        {
            // Recuperar el token del Secure Storage
            var token = await SecureStorage.GetAsync("auth_token");

            // Añadir la cabecera Authorization si el token no es nulo
            if (!string.IsNullOrEmpty(token))
            {
                _feedTransferHttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            // Realizar la solicitud GET
            var response = await _feedTransferHttpClient.GetAsync(
                $"{ApiConstants.API_FEED_CONTROL}{FeedTransferEnpoints.FeedTransfer}"
            );

            // Manejar la respuesta (puedes procesarla según tus necesidades)
            return response;
        }
    }
}
