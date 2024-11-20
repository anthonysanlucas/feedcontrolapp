namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.Transport;

public partial class TransportService : BaseHttpService, ITransportService
{
    private static class TransportEndpoints
    {
        public const string Transpor = $"{ApiConstants.API_FEED_CONTROL}/transports";        
    }

    public TransportService()
        : base(ApiConstants.API_FEED_CONTROL) { }

    public async Task<ApiResponse<PagedApiResponse<TransportResponse>>> GetTransports(TransportQuery transportQuery)

    {
        string query = StringExtensions.BuildQueryString(transportQuery);
        var response = await SendRequestAsync(
            HttpMethod.Get,
            TransportEndpoints.Transpor + query);

        return await ProcessResponse<PagedApiResponse<TransportResponse>>(response);
    }
}
