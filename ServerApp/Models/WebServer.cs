using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class WebServer
    {
        public long WebServerId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }
}
