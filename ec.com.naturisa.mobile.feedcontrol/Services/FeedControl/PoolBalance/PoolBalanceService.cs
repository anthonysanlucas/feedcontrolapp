namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.PoolBalance
{
    public partial class PoolBalanceService : BaseHttpService, IPoolBalanceService
    {
        private static class PoolBalanceEndpoints
        {
            public const string PoolBalance = $"{ApiConstants.API_FEED_CONTROL}/pool_balances";
            public static string PoolBalanceById(long id) => $"{PoolBalance}/{id}";  
        }

        public PoolBalanceService() : base(ApiConstants.API_FEED_CONTROL)
        {
        }

        public async Task<ApiResponse<PagedApiResponse<PoolBalanceResponse>>> Get(PoolBalanceQuery poolBalanceQuery)
        {
            string query = StringExtensions.BuildQueryString(poolBalanceQuery);
            var response = await SendRequestAsync(HttpMethod.Get, PoolBalanceEndpoints.PoolBalance + query);

            return await ProcessResponse<PagedApiResponse<PoolBalanceResponse>>(response);
        }

        public async Task<ApiResponse<PoolBalanceResponse>> GetById(long id)
        {
            var response = await SendRequestAsync(HttpMethod.Get, PoolBalanceEndpoints.PoolBalanceById(id));

            return await ProcessResponse<PoolBalanceResponse>(response);
        }
    }
}
