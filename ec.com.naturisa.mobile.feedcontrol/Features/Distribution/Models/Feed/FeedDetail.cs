namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models.Feed
{
    public class FeedDetail
    {
        public long IdFeedDetail { get; set; }

        public long FeedId { get; set; }

        public long ProductId { get; set; }

        public string? ProductName { get; set; }

        public int? SacksFoundWall { get; set; }

        public int? SacksRemainingHoppers { get; set; }

        public int? LoadedHoppers { get; set; }

        public string? AutomaticFeeding { get; set; }

        public string? ThrowFeeding { get; set; }

        public int? SacksRemainingWallAfterFeeding { get; set; }

        public long StatusCatalogueId { get; set; }
        public string? StatusCatalogueName { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
