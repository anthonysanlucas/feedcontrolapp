using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer
{
    public class SupplierTransferQuery
    {
        public long? DestinationOperatorWarehouseUserId { get; set; }
        public DateTime? AssignmentDate { get; set; }
        public string[]? StatusCatalogueName { get; set; }
        public string Status { get; set; } = null!;
        public bool IncludeTransport { get; set; }
        public bool IncludeFreightTransporter { get; set; }
        public bool IncludeStatusCatalogue { get; set; }
        public bool IncludeStatusCatalogueList { get; set; }
        public bool IncludeSupplier { get; set; }
        public bool IncludeSupplierTransferDetails { get; set; }
        public bool IncludeDestinationWarehouse { get; set; }

    }
}
