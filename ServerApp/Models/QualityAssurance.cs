using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class QualityAssurance
    {
        public long QualityAssuranceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User PerformedBy { get; set; }
        public User VerifiedBy { get; set; }
        public bool isPassed { get; set; }
        public string DocumentationLink { get; set; }
        public string DocumentLocation { get; set; }
        public string Remarks { get; set; }

    }
}
