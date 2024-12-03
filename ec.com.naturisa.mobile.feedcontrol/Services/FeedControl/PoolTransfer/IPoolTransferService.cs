namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.PoolTransfer
{
    public interface IPoolTransferService
    {
        Task<ApiResponse<PoolTransferResponse>> PostPoolTransfer(PoolTransferRequest poolTransferRequest);
        Task<ApiResponse<PoolTransferResponse>> Get(PoolTransferQuery poolTransferQuery);
        Task<ApiResponse<PoolTransferResponse>> GetById(long id);
    }
}
