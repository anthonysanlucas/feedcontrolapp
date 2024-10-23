namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferDetailPoolModel
    {
        [JsonPropertyName("poolId")]
        public int PoolId { get; set; }

        [JsonPropertyName("poolCode")]
        public required string PoolCode { get; set; }

        [JsonPropertyName("quantitySacks")]
        public int QuantitySacks { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }
}
