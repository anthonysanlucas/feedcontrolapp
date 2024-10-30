namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.Feed
{
   public class FeedService : BaseHttpService
    {
        private static class FeedEndpoints
        {
            public const string Feed = $"{ApiConstants.API_FEED_CONTROL}/feed";

            public static string FeedTransferById(int id) => $"{Feed}/{id}/change_status";
        }

        public FeedService() : base(ApiConstants.API_FEED_CONTROL)
        {            
        }

    }
}
