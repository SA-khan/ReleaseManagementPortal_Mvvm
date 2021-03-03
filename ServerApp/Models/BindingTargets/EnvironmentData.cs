using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class EnvironmentData
    {
		public string Title { get; set; }
		public string Description { get; set; }
		public Models.Server Server { get; set; }
		public Models.OperatingSystem OperatingSystem { get; set; }
		public Models.WebServer WebServer { get; set; }
		public List<Api> ApiDependency { get; set; }
		public List<Database> DatabaseDependency { get; set; }
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

		public Models.Environment Environment => new Environment { 
			ApiDependency = ApiDependency, ApplicationHyperLink = ApplicationHyperLink,
			Company = Company, CreatedDate = CreatedDate, DatabaseDependency = DatabaseDependency,
			Dependency = Dependency, Description = Description, DockerDescription = DockerDescription,
			DockerImage = DockerImage, Dockerized = Dockerized, EnvironmentType = EnvironmentType,
			LastHealthCheck = LastHealthCheck, Logo = Logo, Main = Main, ModifiedDate = ModifiedDate,
			OperatingSystem = OperatingSystem, Product = Product, Remarks = Remarks,
			Server = Server, Title = Title, Updated = Updated, WebServer = WebServer,
			WorkingDirectory = WorkingDirectory
		};

	}
}
