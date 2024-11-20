namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.Warehouse
{
    public interface IWarehouseService
    {
        Task<ApiResponse<PagedApiResponse<WarehouseResponse>>> GetWarehouses(WarehouseQuery warehouseQuery);
    }
}
