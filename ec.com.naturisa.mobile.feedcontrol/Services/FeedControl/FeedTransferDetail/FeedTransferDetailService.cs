namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetail
{
    public class FeedTransferDetailService : BaseHttpService, IFeedTransferDetailService
    {
        private static class FeedTransferDetailsEndpoints
        {
            public const string FeedTransferDetails =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_details";
        }

        public FeedTransferDetailService()
            : base(ApiConstants.API_FEED_CONTROL) { }

        public async Task<
            ApiResponse<PagedApiResponse<FeedTransferDetailModel>>
        > GetFeedTransferDetails(int feedReceptionId)
        {
            var endpoint =
                $"{FeedTransferDetailsEndpoints.FeedTransferDetails}?feedReceptionId={feedReceptionId}";

            var response = await SendRequestAsync(HttpMethod.Get, endpoint);

            return await ProcessResponse<PagedApiResponse<FeedTransferDetailModel>>(response);
        }
    }
}
