namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models.Feed
{
    public class FeedResponse
    {
        public int IdFeed { get; set; }
        public string? PoolCode { get; set; }
        public DateTime Date { get; set; }
        public string? StatusCatalogueName { get; set; }
        public string? RemainingStatusCatalogueName { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public List<FeedDetail> FeedDetails { get; set; } = [];
    }
}
