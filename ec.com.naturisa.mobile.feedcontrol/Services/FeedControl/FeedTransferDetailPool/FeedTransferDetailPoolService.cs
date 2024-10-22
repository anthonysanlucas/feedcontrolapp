namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetailPool
{
    public class FeedTransferDetailPoolService : BaseHttpService, IFeedTransferDetailPoolService
    {
        private static class FeedTransferDetailPoolEndpoints
        {
            public const string FeedTransferDetailPool =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_detail_pools";

            public static string FeedTransferDetailPoolById(int id) =>
                $"{FeedTransferDetailPool}/{id}/change_status";
        }

        public FeedTransferDetailPoolService()
            : base(ApiConstants.API_FEED_CONTROL) { }

        public async Task<ApiResponse<FeedTransferDetailPoolModel>> ChangeStatus(
            int id,
            string nextStatus
        )
        {
            var jsonContent = JsonSerializer.Serialize(new { nextStatus });
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await SendRequestAsync(
                HttpMethod.Patch,
                FeedTransferDetailPoolEndpoints.FeedTransferDetailPoolById(id),
                content
            );

            return await ProcessResponse<FeedTransferDetailPoolModel>(response);
        }
    }
}
