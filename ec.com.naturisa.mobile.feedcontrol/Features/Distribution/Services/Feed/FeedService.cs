using System.Net.Http.Json;

namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.Feed
{
    public class FeedService : BaseHttpService, IFeedService
    {
        private static class FeedEndpoints
        {
            public const string Feed = $"{ApiConstants.API_FEED_CONTROL}/feeds";

            public static string FeedStatusOneStep(long id) => $"{Feed}/{id}/step_one";

            public static string FeedStatusTwoStep(long id) => $"{Feed}/{id}/step_two";
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

        public async Task<ApiResponse<object>> ChangeFeedStatusOneStep(long idFeed, List<FeedOneStep> feedOneSteps)
        {
            var content = JsonContent.Create(feedOneSteps);
            var response = await SendRequestAsync(
                HttpMethod.Patch,
                FeedEndpoints.FeedStatusOneStep(idFeed),
                content
            );

            return await ProcessResponse<object>(response);            
        }

        public async Task<ApiResponse<object>> ChangeFeedStatusTwoStep(long idFeed, List<FeedTwoStep> feedTwoSteps)
        {
            var content = JsonContent.Create(feedTwoSteps);
            var response = await SendRequestAsync(
                HttpMethod.Patch,
                FeedEndpoints.FeedStatusTwoStep(idFeed),
                content
            );

            return await ProcessResponse<object>(response);
        }
    }
}
