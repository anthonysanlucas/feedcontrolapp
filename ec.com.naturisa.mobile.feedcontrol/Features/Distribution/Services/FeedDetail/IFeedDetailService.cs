namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.FeedDetail
{
    public interface IFeedDetailService
    {
        Task<ApiResponse<PagedApiResponse<FeedDetailResponse>>> GetFeedDetails(FeedDetailQuery feedDetailQuery);
    }
}
