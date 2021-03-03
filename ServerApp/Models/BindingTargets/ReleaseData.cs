using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class ReleaseData
    {
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		public string PatchNumber { get; set; }
		public User DevelopedBy { get; set; }
		public User DeployedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime DeployedDate { get; set; }
		public QualityAssurance QualityAssurance { get; set; }
		[Required]
		public Company Company { get; set; }
		[Required]
		public Product Product { get; set; }
		[Required]
		public EnvironmentType EnvironmentType { get; set; }
		public string Remarks { get; set; }

		public Release Release => new Release { 
			Title = Title, Description = Description, PatchNumber = PatchNumber,
			DevelopedBy = DevelopedBy, DeployedBy = DeployedBy, CreatedDate = CreatedDate,
			DeployedDate = DeployedDate, QualityAssurance = QualityAssurance, Company = Company,
			Product = Product, EnvironmentType = EnvironmentType, Remarks = Remarks
		};

	}
}
