namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FreightTransporter;

public partial class FreightTransporterService : BaseHttpService, IFreightTransporterService
{
    private static class FreightTransporterEndpoints
    {
        public const string FreightTransporter = $"{ApiConstants.API_FEED_CONTROL}/freight_transporters";
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
}
