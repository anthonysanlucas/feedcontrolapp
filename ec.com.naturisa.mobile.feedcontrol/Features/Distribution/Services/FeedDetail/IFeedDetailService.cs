namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.FeedDetail
{
    public interface IFeedDetailService
    {
        Task<ApiResponse<List<FeedDetailResponse>>> GetFeedDetails(FeedDetailQuery feedDetailQuery);
    }
}
