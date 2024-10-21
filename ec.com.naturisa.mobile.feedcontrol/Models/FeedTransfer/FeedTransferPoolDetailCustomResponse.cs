namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferPoolDetailCustomResponse
    {
        public long IdFeedTransferDetailPool { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public long PoolId { get; set; }
        public string PoolCode { get; set; } = null!;
        public int QuantitySacks { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; } = null!;
    }
}
