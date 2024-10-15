namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferModel
    {
        [JsonPropertyName("idFeedTransfer")]
        public int IdFeedTransfer { get; set; }

        [JsonPropertyName("originSubsidiaryId")]
        public int OriginSubsidiaryId { get; set; }

        [JsonPropertyName("originSubsidiaryName")]
        public string OriginSubsidiaryName { get; set; }

        [JsonPropertyName("destinationSubsidiaryId")]
        public int DestinationSubsidiaryId { get; set; }

        [JsonPropertyName("destinationSubsidiaryName")]
        public string DestinationSubsidiaryName { get; set; }

        [JsonPropertyName("assignedVehicleId")]
        public int AssignedVehicleId { get; set; }

        [JsonPropertyName("assignedVehiclePlate")]
        public string AssignedVehiclePlate { get; set; }

        [JsonPropertyName("assignedCarrierId")]
        public int AssignedCarrierId { get; set; }

        [JsonPropertyName("assignedCarrierName")]
        public string AssignedCarrierName { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("transferCode")]
        public string TransferCode { get; set; }

        [JsonPropertyName("totalSacks")]
        public int TotalSacks { get; set; }

        [JsonPropertyName("totalWeight")]
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
