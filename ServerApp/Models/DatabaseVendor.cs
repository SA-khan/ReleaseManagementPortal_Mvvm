using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class DatabaseVendor
    {
        public long DatabaseVendorId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public Corporation Corporation { get; set; }
        public string Edition { get; set; }
        public string Version { get; set; }
        public long Runtime { get; set; }
        public string Build { get; set; }
        public string Description { get; set; }
    }
}
