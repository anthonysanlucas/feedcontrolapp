namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferDetailCustomResponseModel
    {
        public long IdFeedTransferDetail { get; set; }
        public long FeedTransferId { get; set; }
        public int TotalSacks { get; set; }
        public int TotalPallets { get; set; }
        public string Status { get; set; } = null!;
        public List<FeedTransferPoolDetailCustomResponse> FeedTransferPoolsDetail { get; set; } =
            new();
    }
}
