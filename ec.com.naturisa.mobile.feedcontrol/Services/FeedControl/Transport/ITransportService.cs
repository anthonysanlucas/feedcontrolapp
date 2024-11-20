namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.Transport
{
    public interface ITransportService
    {
        Task<ApiResponse<PagedApiResponse<TransportResponse>>> GetTransports(TransportQuery transportQuery);
    }
}
