namespace ec.com.naturisa.mobile.feedcontrol.Services.WarehouseTransfer
{
    public interface IWarehouseTransferService
    {
        Task<ApiResponse<WarehouseTransferResponse>> PostWarehouseTransfer(WarehouseTransferRequest warehouseTransferRequest);
        Task<ApiResponse<PagedApiResponse<WarehouseTransferResponse>>> GetWarehouseTransfers(WarehouseTransferQuery query);
        Task<ApiResponse<WarehouseTransferResponse>> ChangeStatus(long id, string nextStatus);
    }
}
