namespace ec.com.naturisa.mobile.feedcontrol.Services.FeedControl.FeedTransferDetailPool
{
    public interface IFeedTransferDetailPoolService
    {
        Task<ApiResponse<FeedTransferDetailPoolModel>> ChangeStatus(int id, string nextStatus);
    }
}
