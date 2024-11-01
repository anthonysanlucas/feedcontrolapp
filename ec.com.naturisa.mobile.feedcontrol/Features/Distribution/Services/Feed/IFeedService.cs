namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.Feed
{
   public interface IFeedService
    {
        Task<ApiResponse<PagedApiResponse<FeedResponse>>> GetFeeds(FeedQuery feedQuery);
    }
}
