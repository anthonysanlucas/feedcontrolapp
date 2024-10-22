namespace ec.com.naturisa.mobile.feedcontrol.Features.Distribution.Models
{
    public class Destination
    {
        [JsonPropertyName("destination_type")]
        public required string DestinationType { get; set; } // Puede ser "BODEGA" o "PISCINA"

        [JsonPropertyName("destination_name")]
        public required string DestinationName { get; set; }

        [JsonPropertyName("destination_id")]
        public required int DestinationId { get; set; }
    }
}
