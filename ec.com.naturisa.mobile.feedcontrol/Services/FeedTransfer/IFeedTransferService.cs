using ec.com.naturisa.mobile.feedcontrol.Models.Api;
using ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer;

namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedTransfer
{
    public interface IFeedTransferService
    {
        Task<ApiResponse<PagedApiResponse<FeedTransferModel>>> GetFeedTransfers();
    }
}
