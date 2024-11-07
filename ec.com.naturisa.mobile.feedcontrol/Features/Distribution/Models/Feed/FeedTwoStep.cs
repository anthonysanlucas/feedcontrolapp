namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models.Feed
{
    public class FeedTwoStep
    {
        public int ProductId { get; set; }
        public int LoadedHoppers { get; set; }
        public string? AutomaticFeeding { get; set; }
        public string? ThrowFeeding { get; set; }
        public int SacksRemainingWallAfterFeeding { get; set; }
        public string? Observation { get; set; }
    }
}
