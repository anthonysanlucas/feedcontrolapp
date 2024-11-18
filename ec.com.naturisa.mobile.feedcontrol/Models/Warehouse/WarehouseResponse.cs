namespace ec.com.naturisa.mobile.feedcontrol.Models.Warehouse
{
    public class WarehouseResponse
    {
        public long IdWarehouse { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? WarehouseIdRef { get; set; }
        public string? WarehouseNameRef { get; set; }
        public string? SystemOrigin { get; set; } = null!;
        public string? Status { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; } = null!;
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }

}
