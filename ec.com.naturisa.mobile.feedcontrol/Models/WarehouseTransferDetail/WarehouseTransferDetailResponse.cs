namespace ec.com.naturisa.mobile.feedcontrol.Models.WarehouseTransferDetail
{
    public class WarehouseTransferDetailResponse
    {
        public long IdWarehouseTransferDetail { get; set; }
        public long WarehouseTransferId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string UnitMeasurement { get; set; }
        public int EquivalenceKilograms { get; set; }
        public int EquivalenceSacks { get; set; }
        public int EquivalencePallets { get; set; }
        public string PurchaseOrderCode { get; set; }
        public int? QuantityReceived { get; set; }
        public int? EquivalenceReceivedKilograms { get; set; }
        public int? EquivalenceReceivedSacks { get; set; }
        public int? EquivalenceReceivedPallets { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }


        public bool? IsSelected { get; set; }
    }
}
