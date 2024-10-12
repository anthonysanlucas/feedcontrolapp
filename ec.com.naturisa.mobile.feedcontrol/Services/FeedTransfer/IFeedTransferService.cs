namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer
{
    public interface IFeedTransferService
    {
        Task<HttpResponseMessage> GetFeedTransfers();
    }
}
