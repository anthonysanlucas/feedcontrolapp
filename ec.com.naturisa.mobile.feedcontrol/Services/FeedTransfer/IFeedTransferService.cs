namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer
{
    public interface IFeedTransferService
    {
        Task<ApiResponse<PagedApiResponse<FeedTransferModel>>> GetFeedTransfers();

        // Agrega el método PostFeedTransfer
        Task<ApiResponse<FeedTransferModel>> PostFeedTransfer(FeedTransferModel feedTransferModel);
    }
}
