namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.PoolBalance
{
    public interface IPoolBalanceService
    {
        Task<ApiResponse<PagedApiResponse<PoolBalanceResponse>>> Get(PoolBalanceQuery poolBalanceQuery);
        Task<ApiResponse<PoolBalanceResponse>> GetById(long id);
    }
}
