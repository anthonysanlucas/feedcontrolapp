namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.Warehouse;

public partial class WarehouseService : BaseHttpService, IWarehouseService
{
    private static class WarehouseEndpoints
    {
        public const string Warehouse = $"{ApiConstants.API_FEED_CONTROL}/warehouses";
    }

    public WarehouseService()
        : base(ApiConstants.API_FEED_CONTROL) { }

    public async Task<ApiResponse<PagedApiResponse<WarehouseResponse>>> GetWarehouses(WarehouseQuery warehouseQuery)
    {
        string query = StringExtensions.BuildQueryString(warehouseQuery);
        var response = await SendRequestAsync(
            HttpMethod.Get,
            WarehouseEndpoints.Warehouse + query
        );

        return await ProcessResponse<PagedApiResponse<WarehouseResponse>>(response);
    }
}
