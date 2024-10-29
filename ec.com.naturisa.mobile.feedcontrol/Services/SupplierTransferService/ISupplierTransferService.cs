namespace ec.com.naturisa.mobile.feedcontrol.Services.SupplierTransferService
{
    public interface ISupplierTransferService
    {
        Task<ApiResponse<PagedApiResponse<SupplierTransferResponse>>> GetSupplierTransfers(SupplierTransferQuery query);

        Task<ApiResponse<dynamic>> ChangeStatus(long id, string nextStatus, string observation, List<ReceivedDetails> receivedDetails);
    }
}
