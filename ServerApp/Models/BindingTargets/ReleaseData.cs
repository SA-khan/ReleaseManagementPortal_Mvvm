using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class ReleaseData
    {
		public string Title { 
			get => Release.Title; 
			set {
				Release.Title = value;
			} 
		}
		public string Description { 
			get => Release.Description;
			set {
				Release.Description = value;
			} 
		}
		[Required]
		public string PatchNumber { 
			get => Release.PatchNumber;
			set => Release.PatchNumber = value;
		}
		public long? DevelopedBy { 
			get => Release.DevelopedBy?.UserId ?? null; 
			set
            {
                if (!value.HasValue)
                {
					Release.DevelopedBy = null;
                }
				else
                {
					if(Release.DevelopedBy == null)
                    {
						Release.DevelopedBy = new User();
                    }
					Release.DevelopedBy.UserId = value.Value;
                }
            } 
		}
		public long? DeployedBy {
			get => Release.DeployedBy?.UserId ?? null;
			set
			{
				if (!value.HasValue)
				{
					Release.DeployedBy = null;
				}
				else
				{
					if (Release.DeployedBy == null)
					{
						Release.DeployedBy = new User();
					}
					Release.DeployedBy.UserId = value.Value;
				}
			}
		}
		public DateTime CreatedDate { 
			get => Release.CreatedDate; 
			set => Release.CreatedDate = value; 
		}
		public DateTime DeployedDate {
			get => Release.DeployedDate;
			set => Release.DeployedDate = value;
		}
		public long? QualityAssurance { 
			get => Release.QualityAssurance?.QualityAssuranceId ?? null; 
			set
            {
                if ( !value.HasValue )
                {
					Release.QualityAssurance = null;
                }
				else
                {
					if(Release.QualityAssurance == null)
                    {
						Release.QualityAssurance = new QualityAssurance();
                    }
					Release.QualityAssurance.QualityAssuranceId = value.Value;
                }
            } 
		}
		[Required]
		public long? Company { 
			get => Release.Company?.CompanyId ?? null; 
			set
            {
                if (!value.HasValue)
                {
					Release.Company = null;
                }
				else
                {
					if(Release.Company == null)
                    {
						Release.Company = new Company();
                    }
					Release.Company.CompanyId = value.Value;
					
                }
            } 
		}
		[Required]
		public long? Product { 
			get => Release.Product?.ProductId ?? null; 
			set
            {
                if (!value.HasValue)
                {
					Release.Product = null;
                }
				else
                {
					if(Release.Product == null)
                    {
						Release.Product = new Product();
                    }
					Release.Product.ProductId = value.Value;
                }
            } 
		}
		//[Required]
		public long? Environment
		{
			get => Release.Environment?.EnvironmentId;
			set
			{
				if (!value.HasValue)
				{
					Release.Environment = null;
				}
				else
				{
					if (Release.Environment == null)
					{
						Release.Environment = new Environment();
					}
					Release.Environment.EnvironmentId = value.Value;
				}
			}
		}
		public long? EnvironmentType { 
			get => Release.EnvironmentType?.EnvironmentTypeId; 
			set
            {
                if (!value.HasValue)
                {
					Release.EnvironmentType = null;
                }
				else
                {
					if(Release.EnvironmentType == null)
                    {
						Release.EnvironmentType = new EnvironmentType();
                    }
					Release.EnvironmentType.EnvironmentTypeId = value.Value;
                }
            } 
		}
		public string Remarks { 
			get => Release.Remarks; 
			set => Release.Remarks = value; 
		}

		public Release Release { get; set; } = new Release();

	}
}
