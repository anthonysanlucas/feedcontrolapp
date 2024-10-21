using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer
{
    public class SupplierTransferDetailResponse
    {
        public long IdSupplierTransferDetail { get; set; }
        public long SupplierTransferId { get; set; }
        public long ProductId { get; set; }
        public string ProductSupplierCode { get; set; }
        public string ProductSystemCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string UnitMeasurement { get; set; }
        public int EquivalenceKilograms { get; set; }
        public int EquivalenceSacks { get; set; }
        public int EquivalencePallets { get; set; }
        public string PurchaseOrderCode { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsChecked { get; set; }
    }
}
