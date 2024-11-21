namespace ec.com.naturisa.mobile.feedcontrol.Models.WarehouseTransferDetail;

public record WarehouseTransferDetailRequest
{
    public long? IdWarehouseTransferDetail { get; set; }

    public long WarehouseTransferId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }
}
