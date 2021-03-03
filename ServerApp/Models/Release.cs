using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Release
    {
        public long ReleaseId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string PatchNumber { get; set; }
		public User DevelopedBy { get; set; }
		public User DeployedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime DeployedDate { get; set; }
		public QualityAssurance QualityAssurance { get; set; }
		public Company Company { get; set; }
		public Product Product { get; set; }
		public Environment Environment { get; set; }
		public EnvironmentType EnvironmentType { get; set; }
		public string Remarks { get; set; }

	}
}
