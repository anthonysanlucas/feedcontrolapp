namespace ec.com.naturisa.mobile.feedcontrol.Models.WarehouseTransfer;
public class WarehouseTransferQuery
{

    public long? IdWarehouseTransfer { get; set; }


    public string? Code { get; set; } = null!;


    public long? OriginWarehouseId { get; set; }


    public long? DestinationWarehouseId { get; set; }


    public long? FreightTransporterId { get; set; }


    public long? TransportId { get; set; }

    public DateTime? AssignmentDate { get; set; }


    public long? LastStatusCatalogueId { get; set; }

    public string[]? StatusCatalogueName { get; set; }


    public string? Status { get; set; } = null!;


    public long? DestinationOperatorWarehouseUserId { get; set; }

    public bool IncludeOriginWarehouse { get; set; }
    public bool IncludeDestinationWarehouse { get; set; }
    public bool IncludeFreightTransporter { get; set; }
    public bool IncludeTransport { get; set; }
    public bool IncludeStatusCatalogue { get; set; }
}

