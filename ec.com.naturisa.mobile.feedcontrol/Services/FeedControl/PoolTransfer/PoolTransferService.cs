namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.PoolTransfer
{
    public partial class PoolTransferService : BaseHttpService, IPoolTransferService
    {
        private static class PoolTransferEndpoints
        {
            public const string PoolTransfer = $"{ApiConstants.API_FEED_CONTROL}/pool_transfers";
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
    }
}
