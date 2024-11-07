namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.Feed
{
   public interface IFeedService
    {
        Task<ApiResponse<PagedApiResponse<FeedResponse>>> GetFeeds(FeedQuery feedQuery);

        Task<ApiResponse<PagedApiResponse<FeedResponse>>> GetFeedRemainings(FeedRemaningQuery feedQuery);

        Task<ApiResponse<object>> ChangeFeedStatusOneStep(long feedId, List<FeedOneStep> feedOneSteps);

        Task<ApiResponse<object>> ChangeFeedStatusTwoStep(long idFeed, List<FeedTwoStep> feedTwoSteps);

        Task<ApiResponse<object>> ChangeFeedRemainingStatus(long idFeed, FeedRemainingRequest feedRemainingRequest);
    }
}
