namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.Transport
{
    public class TransportQuery
    {
        public long? IdTransport { get; set; }

        public long? TypeTripId { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

       
        public string? NumberPlate { get; set; }
       
        public string? Brand { get; set; }

        public string? Model { get; set; }

        public string? Status { get; set; }

        public bool IncludeTypeTrip { get; set; }
        public bool IncludeTypeTripCategory { get; set; }
        public bool IncludeOwnershipCatalogue { get; set; }
    }
}
