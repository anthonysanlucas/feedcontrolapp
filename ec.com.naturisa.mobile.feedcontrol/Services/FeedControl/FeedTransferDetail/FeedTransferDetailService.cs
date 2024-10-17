namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetail
{
    public class FeedTransferDetailService : BaseHttpService
    {
        private static class FeedTransferDetailsEndpoints
        {
            public const string FeedTransferDetails =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_details";

            public const string FeedTransferDetailPools =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_detail_pools";
        }

        public FeedTransferDetailService()
            : base(ApiConstants.API_FEED_CONTROL) { }
    }
}
