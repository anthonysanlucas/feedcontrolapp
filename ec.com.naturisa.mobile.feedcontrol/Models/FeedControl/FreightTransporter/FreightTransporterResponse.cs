namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.FreightTransporter
{
    public class FreightTransporterResponse
    {
        public long IdFreightTransporter { get; set; }
        public long TypeTripId { get; set; }
        public string TypeTripName { get; set; }
        public string Identification { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Names { get; set; }
        public string IdentificationNames { get { return Identification + " - " + Names; } }

        public string FullName { get { return FirstName + " " + LastName; } }

        public string? Phone { get; set; }

        public string TypeLicense { get; set; }
        public bool IsEmployee { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
