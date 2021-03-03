using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class DatabaseServer
    {
        public long DatabaseServerId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Ip { get; set; }
        public long Port { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool isRemote { get; set; }
        public bool onCloud { get; set; }

    }
}
