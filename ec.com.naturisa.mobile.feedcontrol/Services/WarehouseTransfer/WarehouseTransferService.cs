namespace ec.com.naturisa.mobile.feedcontrol.Services.WarehouseTransfer;

public class WarehouseTransferService : BaseHttpService, IWarehouseTransferService
{
    private static class WarehouseTransferEndpoints
    {
        public const string WarehouseTransfer = $"{ApiConstants.API_FEED_CONTROL}/warehouse_transfers";        
        public static string ChangeStatus(long id) => $"{WarehouseTransfer}/{id}/change_status";
    }

    public WarehouseTransferService() : base(ApiConstants.API_FEED_CONTROL)
    {
    }

    public async Task<ApiResponse<WarehouseTransferResponse>> PostWarehouseTransfer(WarehouseTransferRequest warehouseTransferRequest)
    {
        var jsonContent = JsonSerializer.Serialize(warehouseTransferRequest);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await SendRequestAsync(
            HttpMethod.Post,
            WarehouseTransferEndpoints.WarehouseTransfer,
            content
        );

        return await ProcessResponse<WarehouseTransferResponse>(response);
    }

    public async Task<ApiResponse<PagedApiResponse<WarehouseTransferResponse>>> GetWarehouseTransfers(WarehouseTransferQuery query)
    {
        string queryParams = StringExtensions.BuildQueryString(query);
        var response = await SendRequestAsync(
            HttpMethod.Get,
            WarehouseTransferEndpoints.WarehouseTransfer + queryParams
        );

        return await ProcessResponse<PagedApiResponse<WarehouseTransferResponse>>(response);
    }

    public async Task<ApiResponse<WarehouseTransferResponse>> ChangeStatus(long id, string status)
    {
        var jsonContent = JsonSerializer.Serialize(new { status });
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await SendRequestAsync(
            HttpMethod.Patch,
            WarehouseTransferEndpoints.ChangeStatus(id),
            content
        );

        return await ProcessResponse<WarehouseTransferResponse>(response);
    }
}
