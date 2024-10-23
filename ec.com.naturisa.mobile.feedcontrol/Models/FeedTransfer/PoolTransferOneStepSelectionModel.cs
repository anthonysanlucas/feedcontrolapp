namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedTransfer
{
    public class PoolTransferOneStepSelection
    {
        public required string OriginBranch { get; set; }
        public required WarehouseModel SelectedWarehouse { get; set; }
        public required CarrierModel SelectedCarrier { get; set; }
        public required TransportModel SelectedTransport { get; set; }
    }
}
