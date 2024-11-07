namespace ec.com.naturisa.mobile.feedcontrol.Services.SupplierTransferService
{
    public class SupplierTransferService : BaseHttpService, ISupplierTransferService
    {
        private static class SupplierTransferEndpoints
        {
            public const string SupplierTransfer = $"{ApiConstants.API_FEED_CONTROL}/supplier_transfers";
            public const string SupplierTransferDetails =
                $"{ApiConstants.API_FEED_CONTROL}/supplier_transfer_details";            
        }

        public SupplierTransferService()
            : base(ApiConstants.API_FEED_CONTROL) { }

        public async Task<ApiResponse<PagedApiResponse<SupplierTransferResponse>>> GetSupplierTransfers(SupplierTransferQuery query)
        {
            try
            {
                string queryParams = StringExtensions.BuildQueryString(query);
                var response = await SendRequestAsync(
                    HttpMethod.Get,
                    SupplierTransferEndpoints.SupplierTransfer + queryParams
                );

                return await ProcessResponse<PagedApiResponse<SupplierTransferResponse>>(response);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<ApiResponse<dynamic>> ChangeStatus(long id, string nextStatus, string observation, List<ReceivedDetails> receivedDetails)
        {            
            var jsonContent = JsonSerializer.Serialize(new { nextStatus, observation, receivedDetails });

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await SendRequestAsync(
                HttpMethod.Patch,
                $"{SupplierTransferEndpoints.SupplierTransfer}/{id}/change_status",
                content
            );

            return await ProcessResponse<dynamic>(response);
        }

        public async Task<ApiResponse<PagedApiResponse<SupplierTransferDetailResponse>>> GetSupplierTransfersDetail(long IdSupplierTranfer)
        {
            try
            {
                //tring queryParams = StringExtensions.BuildQueryString(query);
                var response = await SendRequestAsync(
                    HttpMethod.Get,
                    SupplierTransferEndpoints.SupplierTransferDetails + $"?IdSupplierTransfer={IdSupplierTranfer}&IncludeProduct=true"
                );

                return await ProcessResponse<PagedApiResponse<SupplierTransferDetailResponse>>(response);

            }
            catch (Exception e)
            {

                throw;
            }
        }


    }
}
