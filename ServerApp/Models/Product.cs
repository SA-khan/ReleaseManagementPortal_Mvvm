using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }
        public ParentProduct ParentProduct { get; set; }
        public List<ProductPrerequisite> Prerequisites { get; set; }
        public List<OperatingSystemSupport> OperatingSystemSupport { get; set; }
        public Supplier Supplier { get; set; }
        public List<Release> Releases { get; set; }
        public List<Rating> Ratings { get; set; }
        public bool Updated { get; set; }
        public string masterReleaseLink { get; set; }
        public string masterReleaseWorkingDirecotory { get; set; }
        public QualityAssurance QualityAssurance { get; set; }
        public List<TechnicalVendorSupport> TechnicalVendorSupports { get; set; }
        public List<ClientBrowserSupport> ClientBrowserSupports { get; set; }
        public string ReleaseNotes { get; set; }
    }
}
