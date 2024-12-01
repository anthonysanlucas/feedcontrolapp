namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FreightTransporter;

public partial class FreightTransporterService : BaseHttpService, IFreightTransporterService
{
    private static class FreightTransporterEndpoints
    {
        public const string FreightTransporter = $"{ApiConstants.API_FEED_CONTROL}/freight_transporters";
        public const string UnifiedTrip = $"{ApiConstants.API_FEED_CONTROL}/freight_transporters/GetTrips";
    }

    public FreightTransporterService() : base(ApiConstants.API_FEED_CONTROL)
    {
    }

    public async Task<ApiResponse<PagedApiResponse<FreightTransporterResponse>>> GetFreightTransporters(FreightTransporterQuery freightTransporterQuery)
    {
        string query = StringExtensions.BuildQueryString(freightTransporterQuery);
        var response = await SendRequestAsync(
            HttpMethod.Get,
            FreightTransporterEndpoints.FreightTransporter + query
        );

        return await ProcessResponse<PagedApiResponse<FreightTransporterResponse>>(response);
    }

    public async Task<List<UnifiedTransfer>> GetTrips(UnifiedTripQuery unifiedTripQuery) {
        string query = StringExtensions.BuildQueryString(unifiedTripQuery);
        var response = await SendRequestAsync(
            HttpMethod.Get,
            FreightTransporterEndpoints.UnifiedTrip + query
        );

        var apiResponse = await ProcessResponse<UnifiedTripResponse>(response);        
        
        var unifiedTransfers = new List<UnifiedTransfer>();

        if (apiResponse.Data.supplierTransfers?.Data != null)
        {
            unifiedTransfers.AddRange(apiResponse.Data.supplierTransfers.Data.Select(UnifiedTransferMapper.MapToUnifiedTransfer));
        }
        
        if (apiResponse.Data.feedTransfers?.Data != null)
        {
            unifiedTransfers.AddRange(apiResponse.Data.feedTransfers.Data.Select(UnifiedTransferMapper.MapToUnifiedTransfer));
        }

        if (apiResponse.Data.poolTransfers?.Data != null)
        {
            unifiedTransfers.AddRange(apiResponse.Data.poolTransfers.Data.Select(UnifiedTransferMapper.MapToUnifiedTransfer));
        }

        if (apiResponse.Data.warehouseTransfers?.Data != null)
        {
            unifiedTransfers.AddRange(apiResponse.Data.warehouseTransfers.Data.Select(UnifiedTransferMapper.MapToUnifiedTransfer));
        }

        return unifiedTransfers;
    }
}
