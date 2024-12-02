namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.PoolTransfer
{
    public class PoolTransferRequest
    {
        public long WarehouseId { get; set; }    
        public string OriginPoolCode { get; set; } = null!;        
        public long FreightTransporterId { get; set; }       
        public long TransportId { get; set; }
        public List<PoolTransferDetailRequest>? PoolTransferDetails { get; set; }
    }
}
