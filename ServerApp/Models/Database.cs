using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Database
    {
        public long DatabaseId { get; set; }
        public DatabaseVendor DatabaseVendor { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
        public EnvironmentType EnvironmentType { get; set; }
        //public Models.OperatingSystem OperatingSystem { get; set; }
        public bool Main { get; set; }
        public Server Server { get; set; }
        public string Instance { get; set; }
        public string Hash { get; set; }
        public DataLogFile MdfInformation { get; set; }
        public DataLogFile LdfInformation { get; set; }
        public DateTime LastBackUpDate { get; set; }
        public string BackUpFileName { get; set; }
        public string BackUpFileLocation { get; set; }
        public User BackupTakenPOC { get; set; }
        public DateTime LastRestoredDate { get; set; }
        public string RestoredFileName { get; set; }
        public User RestoredPOC { get; set; }
        public string Comments { get; set; }

    }
}
