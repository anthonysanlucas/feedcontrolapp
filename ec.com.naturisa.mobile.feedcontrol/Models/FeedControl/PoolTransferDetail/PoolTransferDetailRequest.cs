namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.PoolTransferDetail
{
    public class PoolTransferDetailRequest
    {
        public long? PoolTransferId { get; set; }                
        public string DestinationPoolCode { get; set; } = null!;        
        public long ProductId { get; set; }        
        public int Quantity { get; set; }
    }
}
