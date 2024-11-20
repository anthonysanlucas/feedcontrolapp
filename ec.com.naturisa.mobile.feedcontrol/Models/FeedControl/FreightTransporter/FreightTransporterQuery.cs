namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.FreightTransporter
{
    public class FreightTransporterQuery
    {
        public long? IdFreightTransporter { get; set; }

        public long? TypeTripId { get; set; }

        public string? Identification { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? TypeLicense { get; set; }

        public bool? IsEmployee { get; set; }

        public string? Status { get; set; }

        public bool IncludeTypeTrip { get; set; }
    }
}
