namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FreightTransporter
{
    public interface IFreightTransporterService
    {
        Task<ApiResponse<PagedApiResponse<FreightTransporterResponse>>> GetFreightTransporters(FreightTransporterQuery freightTransporterQuery);

        Task<List<UnifiedTransfer>> GetTrips(UnifiedTripQuery unifiedTripQuery);
    }
}
