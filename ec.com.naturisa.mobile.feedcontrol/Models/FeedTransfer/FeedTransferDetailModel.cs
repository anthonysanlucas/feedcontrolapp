namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class FeedTransferDetailModel
    {
        [JsonPropertyName("idFeedTransferDetail")]
        public int IdFeedTransferDetail { get; set; }

        [JsonPropertyName("feedTransferId")]
        public int FeedTransferId { get; set; }

        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public required string ProductName { get; set; }

        [JsonPropertyName("quantitySacks")]
        public int QuantitySacks { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("feedTransferDetailPools")]
        public List<FeedTransferDetailPoolModel>? FeedTransferDetailPools { get; set; }
    }
}
