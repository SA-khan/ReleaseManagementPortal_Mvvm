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
        public bool isPassed { get; set; }
        public string DocumentationLink { get; set; }
        public string DocumentLocation { get; set; }
        public string Remarks { get; set; }
        public QualityAssurance QualityAssurance { get; set; } = new QualityAssurance();

    }
}
