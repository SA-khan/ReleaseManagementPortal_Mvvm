using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class HealthCheck
    {
        public long HealthCheckId { get; set; }
        public DateTime Date { get; set; }
        public string ReferenceLink { get; set; }
        public string Directory { get; set; }
        public bool Passed { get; set; }
        public string Description { get; set; }
    }
}
