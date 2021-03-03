using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{

    public enum os
    {
        Windows,
        Mac,
        Linux,
        Ubuntu
    }
    public class OperatingSystem
    {
        public long OperatingSystemId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Version { get; set; }
        public string CompatibilityMode { get; set; }
        public string Build { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
    }
}
