namespace ec.com.naturisa.mobile.feedcontrol.Models.WarehouseTransfer;

public class WarehouseTransferRequest
{
    public long? IdWarehouseTransfer { get; set; }

    public long OriginWarehouseId { get; set; }

    public long DestinationWarehouseId { get; set; }

    public long FreightTransporterId { get; set; }

    public long TransportId { get; set; }

    public List<WarehouseTransferDetailRequest>? WarehouseTransferDetails { get; set; }
}
