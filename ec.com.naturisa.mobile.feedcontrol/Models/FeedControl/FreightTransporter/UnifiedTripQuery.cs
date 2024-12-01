namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.FreightTransporter
{
    public class UnifiedTripQuery
    {
        public long? FreightTransporterUserId { get; set; }     
        public DateTime? AssignmentDate { get; set; }
        public string[]? StatusCatalogueName { get; set; }
        public string Status { get; set; } = "ACTIVO";       
        public bool IncludeTransport { get; set; }
        public bool IncludeWarehouse { get; set; }
        public bool IncludeFreightTransporter { get; set; }
        public bool IncludeStatusCatalogue { get; set; }
        public bool IncludeStatusCatalogueList { get; set; }
        public bool IncludeSupplier { get; set; }
        public bool IncludeSupplierTransferDetails { get; set; }
    }
}
