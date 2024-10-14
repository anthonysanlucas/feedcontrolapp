namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferDetailModel
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public required string ProductName { get; set; }

        [JsonPropertyName("quantitySacks")]
        public int QuantitySacks { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("status")]
        public bool? Status { get; set; }
    }
}
