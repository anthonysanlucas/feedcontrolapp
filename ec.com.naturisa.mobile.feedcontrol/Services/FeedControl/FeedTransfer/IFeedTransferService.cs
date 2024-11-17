namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer
{
    public interface IFeedTransferService
    {
        Task<ApiResponse<PagedApiResponse<FeedTransferModel>>> GetFeedTransfers(FeedTransferQuery query);

        Task<ApiResponse<FeedTransferModel>> PostFeedTransfer(FeedTransferModel feedTransferModel);

        Task<ApiResponse<FeedTransferModel>> PatchFeedTransferStatus(
            int feedTransferId,
            string nextStatus
        );
    }
}
