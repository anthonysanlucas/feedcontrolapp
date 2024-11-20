namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.Transport
{
    public class TransportResponse
    {
        public long IdTransport { get; set; }
        public long TypeTripId { get; set; }
        public string TypeTripName { get; set; } = null!;
        public long? TypeTripCategoryId { get; set; }
        public string? TypeTripCategoryName { get; set; }
        public long? OwnershipCatalogueId { get; set; }
        public string? OwnershipCatalogueName { get; set; }

        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public string NumberPlate { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public decimal CapacityWeightKg { get; set; }
        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
