namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.PoolTransfer
{
    public class PoolTransferQuery
    {
        public long? WarehouseId { get; set; }
        public string? OriginPoolCode { get; set; }
        public long? FreightTransporterId { get; set; }
        public long? TransportId { get; set; }
        public DateTime Date { get; set; }
        public long? FreightTransporterUserId { get; set; }
        public string[]? Status { get; set; } = null!;
        public bool IncludeFreightTransporter { get; set; } = false;
        public bool IncludeTransport { get; set; } = false;
        public bool IncludeWarehouse { get; set; } = false;
        public bool IncludeStatusCatalogue { get; set; } = false;
    }
}
