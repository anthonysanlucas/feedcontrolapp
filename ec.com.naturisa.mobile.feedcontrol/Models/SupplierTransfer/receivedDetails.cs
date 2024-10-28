namespace ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer
{
   public class ReceivedDetails
    {
        [JsonPropertyName("idSupplierTransferDetail")]
        public long IdSupplierTransferDetail { get; set; }

        [JsonPropertyName("quantityReceivedSacks")]
        public int QuantityReceivedSacks { get; set; }
    }
}
