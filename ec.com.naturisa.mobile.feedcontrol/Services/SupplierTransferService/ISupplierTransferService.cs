using ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Services.SupplierTransferService
{
    public interface ISupplierTransferService
    {
        Task<ApiResponse<PagedApiResponse<SupplierTransferResponse>>> GetSupplierTransfers(SupplierTransferQuery query);
    }
}
