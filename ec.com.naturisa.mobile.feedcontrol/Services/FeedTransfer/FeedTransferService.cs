namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer
{
    public class FeedTransferService : BaseHttpService, IFeedTransferService
    {
        private static class FeedTransferEndpoints
        {
            public const string FeedTransfer = $"{ApiConstants.API_FEED_CONTROL}/feed_transfers";
            public const string FeedTransferDetails =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_details";
            public const string FeedTransferDetailPools =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_detail_pools";
        }

        public FeedTransferService()
            : base(ApiConstants.API_FEED_CONTROL) { }

        public async Task<ApiResponse<PagedApiResponse<FeedTransferModel>>> GetFeedTransfers()
        {
            var response = await SendRequestAsync(
                HttpMethod.Get,
                FeedTransferEndpoints.FeedTransfer
            );

            return await ProcessResponse<PagedApiResponse<FeedTransferModel>>(response);
        }
    }
}
