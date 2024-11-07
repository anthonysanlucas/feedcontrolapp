namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models.Feed
{
    public class FeedRemaningQuery
    {
        public string Date { get; set; }

        public string[] StatusCatalogueName { get; set; } = null!;

        public bool IncludeStatusCatalogue { get; set; }

    }
}
