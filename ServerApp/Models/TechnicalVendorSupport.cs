using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class TechnicalVendorSupport
    {
        public long TechnicalVendorSupportId { get; set; }
        public TechnicalVendor TechnicalVendor { get; set; }
    }
}
