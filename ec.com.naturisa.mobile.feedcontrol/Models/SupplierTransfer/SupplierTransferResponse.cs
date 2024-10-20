using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer
{
    public class SupplierTransferResponse
    {
        public long IdSupplierTransfer { get; set; }
        public string Code { get; set; }
        public long OriginSupplierId { get; set; }
        public string OriginSupplierName { get; set; }
        public long DestinationWarehouseId { get; set; }
        public string DestinationWarehouseName { get; set; }
        public long FreightTransporterId { get; set; }
        public string FreightTransporterName { get; set; }
        public long TransportId { get; set; }
        public string TransportName { get; set; }
        public int TotalEquivalenceKilograms { get; set; }
        public int TotalEquivalenceSacks { get; set; }
        public int TotalEquivalencePallets { get; set; }
        public long LastStatusCatalogueId { get; set; }
        public string LastStatusCatalogueName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

        public IList<SupplierTransferStatusResponse> SupplierTransferStatuses { get; set; }
        public IList<SupplierTransferDetailResponse> SupplierTransferDetails { get; set; }
    }
}
