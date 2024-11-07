namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.Feed
{
   public interface IFeedService
    {
        Task<ApiResponse<PagedApiResponse<FeedResponse>>> GetFeeds(FeedQuery feedQuery);

        Task<ApiResponse<object>> ChangeFeedStatusOneStep(long feedId, List<FeedOneStep> feedOneSteps);

        Task<ApiResponse<object>> ChangeFeedStatusTwoStep(long idFeed, List<FeedTwoStep> feedTwoSteps);
    }
}
