namespace ec.com.naturisa.mobile.feedcontrol.Services.Ap1.Pools;

public class PoolsService : BaseHttpService, IPoolsService
{
    private static class PoolsEndpoints
    {
        public const string Pools = $"{ApiConstants.AP1_API_URL}/pools";
    }

    public PoolsService()
            : base(ApiConstants.API_FEED_CONTROL) { }

    public async Task<ApiResponse<PagedApiResponse<PoolsResponse>>> GetPools(PoolsQuery poolsQuery)
    {
        try
        {
            string query = StringExtensions.BuildQueryString(poolsQuery);
            var response = await SendRequestAsync(
                HttpMethod.Get,
                PoolsEndpoints.Pools + query
            );

            return await ProcessResponse<PagedApiResponse<PoolsResponse>>(response);
        }
        catch (Exception e)
        {
            throw;
        }
    }
}






