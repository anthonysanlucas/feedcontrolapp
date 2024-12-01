namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.PoolTransfer
{
    public class PoolTransferResponse
    {
        public long IdPoolTransfer { get; set; }
        public string? Code { get; set; }
        public long WarehouseId { get; set; }
        public string WarehouseName { get; set; } = null!;
        public string OriginPoolCode { get; set; } = null!;
        public string DestinationPoolCode { get; set; } = null!;
        public long FreightTransporterId { get; set; }
        public string FreightTransporterName { get; set; } = null!;
        public long TransportId { get; set; }
        public string TransportName { get; set; } = null!;
        public int TotalEquivalenceSacks { get; set; }
        public int TotalEquivalenceKilograms { get; set; }
        public int TotalEquivalencePallets { get; set; }
        public string Status { get; set; } = null!;
        public string TransferType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; } = null!;
    }
}
