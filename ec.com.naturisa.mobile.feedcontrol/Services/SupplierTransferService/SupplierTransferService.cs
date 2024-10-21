using ec.com.naturisa.mobile.feedcontrol.Helpers;
using ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Services.SupplierTransferService
{
    public class SupplierTransferService : BaseHttpService, ISupplierTransferService
    {
        private static class SupplierTransferEndpoints
        {
            public const string SupplierTransfer = $"{ApiConstants.API_FEED_CONTROL_LOCAL}/supplier_transfers";
            public const string SupplierTransferDetails =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_details";
            public const string SupplierTransferDetailPools =
                $"{ApiConstants.API_FEED_CONTROL}/feed_transfer_detail_pools";
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
    }
}
