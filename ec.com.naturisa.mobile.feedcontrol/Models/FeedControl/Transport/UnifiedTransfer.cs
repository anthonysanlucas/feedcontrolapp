namespace ec.com.naturisa.mobile.feedcontrol.Models.FeedControl.Transport
{
    public class UnifiedTransfer
    {
        public long Id { get; set; }
        public string TransferType { get; set; } // Supplier, Pool, Warehouse, Feed
        public string Code { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string TransporterName { get; set; }
        public string VehicleName { get; set; }
        public int TotalSacks { get; set; }
        public int TotalPallets { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public object OriginalData { get; set; }
    }
}
