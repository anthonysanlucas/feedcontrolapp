using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ec.com.naturisa.mobile.feedcontrol.Models.SupplierTransfer
{
    public class SupplierTransferStatusResponse
    {
        public long SupplierTransferId { get; set; }
        public DateTime Date { get; set; }
        public string Observation { get; set; }
        public string StatusName { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
