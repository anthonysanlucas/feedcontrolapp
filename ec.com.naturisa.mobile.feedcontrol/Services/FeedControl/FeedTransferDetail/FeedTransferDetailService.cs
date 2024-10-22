namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetail
{
    public class FeedTransferDetailService : BaseHttpService, IFeedTransferDetailService
    {
        private static class FeedTransferDetailsEndpoints
        {
            public const string FeedTransferDetails =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_details";

            public const string FeedTransferDetailsConsolidated =
                $"{FeedTransferDetails}/consolidated/";
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

        public async Task<
            ApiResponse<FeedTransferDetailCustomResponseModel>
        > GetFeedTransferDetailsConsolidated(int feedReceptionId)
        {
            var endpoint =
                $"{FeedTransferDetailsEndpoints.FeedTransferDetailsConsolidated}{feedReceptionId}";

            var response = await SendRequestAsync(HttpMethod.Get, endpoint);

            return await ProcessResponse<FeedTransferDetailCustomResponseModel>(response);
        }
    }
}
