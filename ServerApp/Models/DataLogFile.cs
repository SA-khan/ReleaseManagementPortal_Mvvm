using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class DataLogFile
    {
        public long DataLogFileId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Location { get; set; }
    }
}
