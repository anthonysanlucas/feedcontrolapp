
namespace ec.com.naturisa.mobile.feedcontrol.Models.WarehouseTransfer;

public class WarehouseTransferResponse
{
    public long IdWarehouseTransfer { get; set; }
    public string Code { get; set; }
    public long OriginWarehouseId { get; set; }
    public string OriginWarehouseName { get; set; }
    public long DestinationWarehouseId { get; set; }
    public string DestinationWarehouseName { get; set; }
    public long FreightTransporterId { get; set; }
    public string FreightTransporterName { get; set; }
    public long TransportId { get; set; }
    public string TransportName { get; set; }
    public int TotalEquivalenceKilograms { get; set; }
    public int TotalEquivalenceSacks { get; set; }
    public int TotalEquivalencePallets { get; set; }
    public int? TotalEquivalenceReceivedSacks { get; set; }
    public int? TotalEquivalenceReceivedKilograms { get; set; }
    public int? TotalEquivalenceReceivedPallets { get; set; }
    public long LastStatusCatalogueId { get; set; }
    public string LastStatusCatalogueName { get; set; }
    public string Status { get; set; }
    public string TransferType { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }

    public DateTime AssignmentDate { get; set; }
}
