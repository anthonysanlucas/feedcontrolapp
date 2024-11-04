namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models.Feed
{
    public class FeedQuery
    {       
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Date { get; set; }
        public string[]? StatusCatalogueName { get; set; }          
        public bool IncludeStatusCatalogue { get; set; }               
    }
}
