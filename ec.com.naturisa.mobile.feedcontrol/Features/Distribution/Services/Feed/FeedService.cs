namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.Feed
{
    public class FeedService : BaseHttpService, IFeedService
    {
        private static class FeedEndpoints
        {
            public const string Feed = $"{ApiConstants.API_FEED_CONTROL}/feeds";

            public static string FeedTransferById(int id) => $"{Feed}/{id}/change_status";
        }

        public FeedService() : base(ApiConstants.API_FEED_CONTROL)
        { }

        public async Task<ApiResponse<PagedApiResponse<FeedResponse>>> GetFeeds(FeedQuery feedQuery)
        {
            string queryParams = StringExtensions.BuildQueryString(feedQuery);
            var response = await SendRequestAsync(
                HttpMethod.Get,
                FeedEndpoints.Feed + queryParams
            );

            return await ProcessResponse<PagedApiResponse<FeedResponse>>(response);
        }
    }
}
