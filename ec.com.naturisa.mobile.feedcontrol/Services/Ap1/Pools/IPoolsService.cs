namespace ec.com.naturisa.mobile.feedcontrol.Services.Ap1.Pools
{
    public interface IPoolsService
    {
        Task<ApiResponse<PagedApiResponse<PoolsResponse>>> GetPools(PoolsQuery poolsQuery);
    }
}
