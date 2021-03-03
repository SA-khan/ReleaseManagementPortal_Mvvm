using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class ProductPrerequisite
    {
        public long ProductPrerequisiteId { get; set; }
        public List<OperatingSystemSupport> OperatingSystemSupport { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Dependency { get; set; }
    }
}
