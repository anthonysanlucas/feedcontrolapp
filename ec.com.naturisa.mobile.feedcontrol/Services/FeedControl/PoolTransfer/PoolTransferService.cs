namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.PoolTransfer
{
    public partial class PoolTransferService : BaseHttpService, IPoolTransferService
    {
        private static class PoolTransferEndpoints
        {
            public const string PoolTransfer = $"{ApiConstants.API_FEED_CONTROL}/pool_transfers";
            public static string PoolTransferById(long id) => $"{ApiConstants.API_FEED_CONTROL}/pool_transfers{id}"; 
        }

        public PoolTransferService() : base(ApiConstants.API_FEED_CONTROL)
        {
        }

        public async Task<ApiResponse<PoolTransferResponse>> PostPoolTransfer(PoolTransferRequest poolTransferRequest)
        {
            var jsonContent = JsonSerializer.Serialize(poolTransferRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await SendRequestAsync(
                HttpMethod.Post,
                PoolTransferEndpoints.PoolTransfer,
                content
            );

            return await ProcessResponse<PoolTransferResponse>(response);
        }

        public async Task<ApiResponse<PoolTransferResponse>> Get(PoolTransferQuery poolTransferQuery)
        {
            string query = StringExtensions.BuildQueryString(poolTransferQuery);
            var response = await SendRequestAsync(
                HttpMethod.Get,
                PoolTransferEndpoints.PoolTransfer + query
            );

            return await ProcessResponse<PoolTransferResponse>(response);
        }

        public async Task<ApiResponse<PoolTransferResponse>> GetById(long id)
        {
            var response = await SendRequestAsync(
                HttpMethod.Get,
                PoolTransferEndpoints.PoolTransferById(id));

            return await ProcessResponse<PoolTransferResponse>(response);
       }
    }
}
