namespace ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer
{
    public class SupplierTransferDetailReceivedRequest
    {        
        public long? IdSupplierTransferDetail { get; set; }               
        public int QuantityReceivedSacks { get; set; }
        public List<SupplierTransferDetailReceivedGuideRequest>? Guides { get; set; }
    }
}
