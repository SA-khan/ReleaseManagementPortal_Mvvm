using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public class Server
    {
        public long ServerId { get; set; }
        public ServerType ServerType { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public long Port { get; set; }
        public string Domain { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool isRemoteBased { get; set; }
        public bool isVirtualized { get; set; }
        public bool isCloudBased { get; set; }
        public OperatingSystem operatingSystem { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string Description { get; set; }
        public string Dependency { get; set; }
        public bool isAppServer { get; set; }
        public bool isWebServer { get; set; }
        public bool isDNSServer { get; set; }
        public bool isProxyServer { get; set; }
        public bool isDatabaseServer { get; set; }
        public bool isMailServer { get; set; }
        public bool isFileServer { get; set; }
        public bool isPrintServer { get; set; }
        public bool isMonitoringServer { get; set; }
        public bool isHybridServer { get; set; }
        public WebServer WebServerSupport { get; set; }
        public DatabaseServer DatabaseServerSupport { get; set; }
        public MailServer MailServerSupport { get; set; }
        public PrintServer PrintServerSupport { get; set; }
        public HybridServer HybridServerSupport { get; set; }

    }
}

