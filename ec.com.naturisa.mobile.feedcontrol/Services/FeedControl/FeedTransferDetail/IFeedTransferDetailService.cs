namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetail
{
    public interface IFeedTransferDetailService
    {
        Task<ApiResponse<PagedApiResponse<FeedTransferDetailModel>>> GetFeedTransferDetails(
            int feedReceptionId
        );
    }
}
