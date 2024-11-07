namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models.Feed
{
    public class FeedRemainingRequest
    {        
        public long IdFeed { get; set; }     
        public int? SacksRemainingHoppers { get; set; }
        public int? FailedHoppers { get; set; }
        public string? Observation { get; set; }
    }
}
