using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class PrintServer
    {
        public long PrintServerId { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public long Port { get; set; }
        public bool isSMTP { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
