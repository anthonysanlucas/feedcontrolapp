namespace ec.com.naturisa.mobile.feedcontrol.Models.MasterData.Product
{
    public class ProductResponse
    {
        public long IdProduct { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? SupplierCodeRef { get; set; }

        public string? ProductIdRef { get; set; }

        public string? ProductNameRef { get; set; }

        public string SystemOrigin { get; set; } = null!;

        public string Status { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
