namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.PoolBalance
{
    public class PoolBalanceResponse
    {
        public long IdPoolBalance { get; set; }
        public string PoolName { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
