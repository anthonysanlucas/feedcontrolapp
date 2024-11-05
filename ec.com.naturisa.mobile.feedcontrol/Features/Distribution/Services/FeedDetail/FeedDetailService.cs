namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Services.FeedDetail
{
    public class FeedDetailService : BaseHttpService, IFeedDetailService
    {
        private static class FeedDetailEndpoints
        {
            public const string FeedDetail = $"{ApiConstants.API_FEED_CONTROL}/feed_details/";

            public const string GetGroupedFeedDetails = $"{FeedDetail}grouped";

            public static string FeedDetailTransferById(int id) => $"{FeedDetail}/{id}/change_status";
        }

        public FeedDetailService() : base(ApiConstants.API_FEED_CONTROL)
        {}

        public async Task<ApiResponse<PagedApiResponse<FeedDetailResponse>>> GetFeedDetails(FeedDetailQuery feedDetailQuery)
        {
            string queryParams = StringExtensions.BuildQueryString(feedDetailQuery);
            var response = await SendRequestAsync(
                HttpMethod.Get,
                FeedDetailEndpoints.GetGroupedFeedDetails + queryParams
            );

            return await ProcessResponse<PagedApiResponse<FeedDetailResponse>>(response);
        }       

    }
}
