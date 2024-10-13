namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferModel
    {
        [JsonPropertyName("id_feed_transfer")]
        public int IdFeedTransfer { get; set; }

        [JsonPropertyName("origin_subsidiary_id")]
        public int OriginSubsidiaryId { get; set; }

        [JsonPropertyName("origin_subsidiary_name")]
        public string OriginSubsidiaryName { get; set; }

        [JsonPropertyName("destination_subsidiary_id")]
        public int DestinationSubsidiaryId { get; set; }

        [JsonPropertyName("destination_subsidiary_name")]
        public string DestinationSubsidiaryName { get; set; }

        [JsonPropertyName("assigned_vehicle_id")]
        public int AssignedVehicleId { get; set; }

        [JsonPropertyName("assigned_vehicle_plate")]
        public string AssignedVehiclePlate { get; set; }

        [JsonPropertyName("assigned_carrier_id")]
        public int AssignedCarrierId { get; set; }

        [JsonPropertyName("assigned_carrier_name")]
        public string AssignedCarrierName { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("transfer_code")]
        public string TransferCode { get; set; }

        [JsonPropertyName("total_sacks")]
        public int TotalSacks { get; set; }

        [JsonPropertyName("total_weight")]
        public decimal TotalWeight { get; set; }

        [JsonPropertyName("approximate_pallets")]
        public int ApproximatePallets { get; set; }

        [JsonPropertyName("assigned_date")]
        public DateTime AssignedDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        //[JsonPropertyName("feed_transfer_details")]
        //public List<FeedTransferDetail> FeedTransferDetails { get; set; }
    }
}
