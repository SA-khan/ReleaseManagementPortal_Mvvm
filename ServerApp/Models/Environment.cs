using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Environment
    {
        public long EnvironmentId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Models.Server Server { get; set; }
		public Models.OperatingSystem OperatingSystem { get; set; }
		public Models.WebServer WebServer { get; set; }
		public List<Api> ApiDependency { get; set; }
		public List<Database> DatabaseDependency { get; set; }
		//public AppArchitype AppType { get; set; }
		public string ApplicationHyperLink { get; set; }
		public string WorkingDirectory { get; set; }
		public string Dependency { get; set; }
		public Company Company { get; set; }
		public Product Product { get; set; }
		public EnvironmentType EnvironmentType { get; set; }
		public bool Main { get; set; }
		public bool Dockerized { get; set; }
		public string DockerImage { get; set; }
		public string DockerDescription { get; set; }
		public bool Updated { get; set; }
		public HealthCheck LastHealthCheck { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Logo { get; set; }
		public string Remarks { get; set; }

	}
}
