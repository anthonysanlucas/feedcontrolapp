namespace ec.com.naturisa.mobile.feedcontrol.Services.WarehouseTransferDetail
{
   public interface IWarehouseTransferDetailService
    {
        Task<ApiResponse<PagedApiResponse<WarehouseTransferDetailResponse>>> GetWarehouseTransfers(WarehouseTransferDetailQuery query);
    }
}
