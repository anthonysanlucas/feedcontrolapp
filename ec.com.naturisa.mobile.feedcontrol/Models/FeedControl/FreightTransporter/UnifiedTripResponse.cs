namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.FreightTransporter
{
    public partial class UnifiedTripResponse
    {
        public PagedApiResponse<SupplierTransferResponse> supplierTransfers { get; set; }
        public PagedApiResponse<FeedTransferModel> feedTransfers { get; set; }
        public PagedApiResponse<PoolTransferResponse> poolTransfers { get; set; }
        public PagedApiResponse<WarehouseTransferResponse> warehouseTransfers { get; set; }

    }
}
