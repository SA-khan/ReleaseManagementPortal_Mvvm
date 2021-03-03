using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class HybridServer
    {
        public long HybridServerId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string WebServerName { get; set; }
        public string WebServerVersion { get; set; }
        public string WebServerDescription { get; set; }
        public string DatabaseServerName { get; set; }
        public string DatabaseServerIp { get; set; }
        public string DatabaseServerPort { get; set; }
        public string DatabaseServerInstance { get; set; }
        public string DatabaseServerInitialCatalog { get; set; }
        public string DatabaseServerUserId { get; set; }
        public string DatabaseServerPassword { get; set; }
        public DataLogFile DatabaseServerMdfInformation { get; set; }
        public DataLogFile DatabaseServerLdfInformation { get; set; }
        public DateTime DatabaseServerLastBackUpDate { get; set; }
        public string DatabaseServerBackUpFileName { get; set; }
        public string DatabaseServerBackUpFileLocation { get; set; }
        public User DatabaseServerBackupTakenPOC { get; set; }
        public DateTime DatabaseServerLastRestoredDate { get; set; }
        public string DatabaseServerRestoredFileName { get; set; }
        public User DatabaseServerRestoredPOC { get; set; }
        public string DatabaseServerComments { get; set; }
        public string MailServerName { get; set; }
        public string MailServerIp { get; set; }
        public long MailServerPort { get; set; }
        public bool MailServerisSMTP { get; set; }
        public string MailServerAddress { get; set; }
        public string MailServerEmailId { get; set; }
        public string MailServerPassword { get; set; }

    }
}
