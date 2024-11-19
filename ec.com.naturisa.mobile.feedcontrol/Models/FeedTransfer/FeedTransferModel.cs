namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferModel
    {
        public int? IdFeedTransfer { get; set; }

        public int OriginSubsidiaryId { get; set; }

        public string OriginSubsidiaryName { get; set; }

        public int DestinationSubsidiaryId { get; set; }
        
        public string DestinationSubsidiaryName { get; set; }

        public long? DestinationWarehouseId { get; set; }

        public string? DestinationWarehouseName { get; set; }
     
        public int AssignedVehicleId { get; set; }

        public string AssignedVehiclePlate { get; set; }

        public int AssignedCarrierId { get; set; }

        public string AssignedCarrierName { get; set; }

        public string Type { get; set; }

        public string TransferCode { get; set; }

        public int TotalSacks { get; set; }

        public decimal TotalWeight { get; set; }

        [JsonPropertyName("approximatePallets")]
        public int ApproximatePallets { get; set; }

        [JsonPropertyName("assignedDate")]
        public DateTime AssignedDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("feedTransferDetails")]
        public List<FeedTransferDetailModel>? FeedTransferDetails { get; set; }
    }
}
