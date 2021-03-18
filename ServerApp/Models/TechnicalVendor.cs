using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class TechnicalVendor
    {
        public long TechnicalVendorId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public Corporation Corporation { get; set; }
        public string Description { get; set; }
    }
}
