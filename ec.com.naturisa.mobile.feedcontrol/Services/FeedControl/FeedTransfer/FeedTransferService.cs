namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer
{
    public class FeedTransferService : BaseHttpService, IFeedTransferService
    {
        private static class FeedTransferEndpoints
        {
            public const string FeedTransfer = $"{ApiConstants.API_FEED_CONTROL}/feed_transfers";

            public static string FeedTransferById(int id) => $"{FeedTransfer}/{id}/change_status";
        }

        public FeedTransferService()
            : base(ApiConstants.API_FEED_CONTROL) { }

        public async Task<ApiResponse<PagedApiResponse<FeedTransferModel>>> GetFeedTransfers()
        {
            var response = await SendRequestAsync(
                HttpMethod.Get,
                FeedTransferEndpoints.FeedTransfer
            );

            return await ProcessResponse<PagedApiResponse<FeedTransferModel>>(response);
        }

        public async Task<ApiResponse<FeedTransferModel>> PostFeedTransfer(
            FeedTransferModel feedTransferModel
        )
        {
            var jsonContent = JsonSerializer.Serialize(feedTransferModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await SendRequestAsync(
                HttpMethod.Post,
                FeedTransferEndpoints.FeedTransfer,
                content
            );

            return await ProcessResponse<FeedTransferModel>(response);
        }

        public async Task<ApiResponse<FeedTransferModel>> PatchFeedTransferStatus(
            int id,
            string nextStatus
        )
        {
            var jsonContent = JsonSerializer.Serialize(new { nextStatus });
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await SendRequestAsync(
                HttpMethod.Patch,
                FeedTransferEndpoints.FeedTransferById(id),
                content
            );

            return await ProcessResponse<FeedTransferModel>(response);
        }
    }
}
