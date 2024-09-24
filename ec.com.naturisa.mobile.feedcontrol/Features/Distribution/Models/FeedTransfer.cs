namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models
{
    public class FeedTransfer
    {
        [JsonPropertyName("id_transfer")]
        public int IdTransfer { get; set; }

        [JsonPropertyName("transfer_code")]
        public string TransferCode { get; set; }

        [JsonPropertyName("assigned_date")]
        public string AssignedDate { get; set; }

        [JsonPropertyName("total_sacks")]
        public int TotalSacks { get; set; }

        [JsonPropertyName("total_weight")]
        public double TotalWeight { get; set; }

        [JsonPropertyName("approximate_pallets")]
        public double ApproximatePallets { get; set; }

        [JsonPropertyName("destination_subsidiary_id")]
        public int DestinationSubsidiaryId { get; set; }

        [JsonPropertyName("origin_subsidiary_name")]
        public required string DestinationSubsidiaryName { get; set; }

        [JsonPropertyName("origin_subsidiary_id")]
        public int OriginSubsidiaryId { get; set; }

        [JsonPropertyName("origin_subsidiary_name")]
        public required string OriginSubsidiaryName { get; set; }

        [JsonPropertyName("reception_date")]
        public DateTime ReceptionDate { get; set; }

        [JsonPropertyName("status")]
        public required string Status { get; set; }

        [JsonPropertyName("assigned_carrier_id")]
        public required string AssignedCarrierId { get; set; }

        [JsonPropertyName("assigned_carrier_name")]
        public required string AssignedCarrierName { get; set; }

        [JsonPropertyName("assigned_vehicle_id")]
        public required string AssignedVehicleId { get; set; }

        [JsonPropertyName("assigned_vehicle_plate")]
        public required string AssignedVehiclePlate { get; set; }

        [JsonPropertyName("route")]
        public Route Route { get; set; }
    }
}
