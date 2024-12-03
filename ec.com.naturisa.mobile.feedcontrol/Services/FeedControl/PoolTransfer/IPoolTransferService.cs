namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.PoolTransfer
{
    public interface IPoolTransferService
    {
        Task<ApiResponse<PoolTransferResponse>> PostPoolTransfer(PoolTransferRequest poolTransferRequest);
    }
}
