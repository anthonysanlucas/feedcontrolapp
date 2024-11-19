namespace ec.com.naturisa.mobile.feedcontrol.Services.WarehouseTransferDetail
{
   public class WarehouseTransferDetailService : BaseHttpService, IWarehouseTransferDetailService
    {
        private static class WarehouseTransferEndpoints
        {
            public const string WarehouseTransferDetails = $"{ApiConstants.API_FEED_CONTROL}/warehouse_transfer_details";
        }

        public WarehouseTransferDetailService() : base(ApiConstants.API_FEED_CONTROL)
        {
            
        }

        public async Task<ApiResponse<PagedApiResponse<WarehouseTransferResponse>>> GetWarehouseTransfers(WarehouseTransferDetailQuery query)
        {
            string queryParams = StringExtensions.BuildQueryString(query);
            var response = await SendRequestAsync(
                HttpMethod.Get,
                WarehouseTransferEndpoints.WarehouseTransferDetails + queryParams
            );

            return await ProcessResponse<PagedApiResponse<WarehouseTransferResponse>>(response);
        }
    }
}
