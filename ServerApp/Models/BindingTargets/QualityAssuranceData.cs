using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class QualityAssuranceData
    {
        public string Title { 
            get => QualityAssurance.Title; 
            set => QualityAssurance.Title = value;
        }
        public string Description { 
            get => QualityAssurance.Description; 
            set => QualityAssurance.Description = value; 
        }
        public long? PerformedBy { 
            get => QualityAssurance.PerformedBy?.UserId ?? null; 
            set
            {
                if (!value.HasValue)
                {
                    QualityAssurance.PerformedBy = null;
                }
                else
                {
                    if(QualityAssurance.PerformedBy == null)
                    {
                        QualityAssurance.PerformedBy = new User();
                    }
                    QualityAssurance.PerformedBy.UserId = value.Value;
                }
            }
        }
        public long? VerifiedBy {
            get => QualityAssurance.VerifiedBy?.UserId ?? null;
            set
            {
                if (!value.HasValue)
                {
                    QualityAssurance.VerifiedBy = null;
                }
                else
                {
                    if (QualityAssurance.VerifiedBy == null)
                    {
                        QualityAssurance.VerifiedBy = new User();
                    }
                    QualityAssurance.VerifiedBy.UserId = value.Value;
                }
            }
        }
        public bool isPassed { get => QualityAssurance.isPassed; set => QualityAssurance.isPassed = value; }
        public string DocumentationLink { get => QualityAssurance.DocumentationLink; set => QualityAssurance.DocumentationLink = value; }
        public string DocumentLocation { get => QualityAssurance.DocumentLocation; set => QualityAssurance.DocumentLocation = value; }
        public string Remarks { get => QualityAssurance.Remarks; set => QualityAssurance.Remarks = value; }
        public DateTime CreatedDate { get => QualityAssurance.CreatedDate; set => QualityAssurance.CreatedDate = value; }
        public DateTime ModifiedDate { get => QualityAssurance.ModifiedDate; set => QualityAssurance.ModifiedDate = value; }
        public QualityAssurance QualityAssurance { get; set; } = new QualityAssurance();

    }
}
