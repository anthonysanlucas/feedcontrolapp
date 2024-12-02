namespace ec.com.naturisa.mobile.feedcontrol.Models.MasterData.Product
{
    public class ProductQuery
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? SupplierCodeRef { get; set; }
        public string? ProductIdRef { get; set; }
        public string? ProductNameRef { get; set; }
        public string? SystemOrigin { get; set; }
        public string? Status { get; set; } = Const.Status.Active;
    }
}
