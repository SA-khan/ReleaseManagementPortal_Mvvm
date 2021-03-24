using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.BindingTargets
{
    public class ServerData
    {
        public long? ServerType {
            get => Server.ServerType?.ServerTypeId ?? null;
            set
            {
                if (!value.HasValue) {
                    Server.ServerType.ServerTypeId = 0;
                }
                else
                {
                    if(Server.ServerType == null)
                    {
                        Server.ServerType = new ServerType();
                    }
                    Server.ServerType.ServerTypeId = value.Value;
                }
            }
        }
        [Required]
        public string Name
        {
            get => Server.Name;
            set => Server.Name = value;
        }
        [Required]
        public string Ip { 
            get => Server.Ip;
            set => Server.Ip = value; 
        }
        public long Port { 
            get => Server.Port; 
            set => Server.Port = value;
        }
        public string Domain { 
            get => Server.Domain; 
            set => Server.Domain = value; 
        }
        public string UserId { 
            get => Server.UserId; 
            set => Server.UserId = value;
        }
        public string Password { 
            get => Server.Password; 
            set => Server.Password = value; 
        }
        public bool RemoteEnabled { 
            get => Server.RemoteEnabled; 
            set => Server.RemoteEnabled = value; 
        }
        public bool HostMachine { 
            get => Server.HostMachine; 
            set => Server.HostMachine = value; 
        }
        public bool isVirtualized { 
            get => Server.isVirtualized; 
            set => Server.isVirtualized = value; 
        }
        public bool isCloudBased { 
            get => Server.isCloudBased; 
            set => Server.isCloudBased = value; 
        }
        public long? operatingSystem { 
            get => Server.operatingSystem?.OperatingSystemId ?? null;
            set {
                if (!value.HasValue)
                {
                    Server.operatingSystem = null;
                }
                else
                {
                    if(Server.operatingSystem == null)
                    {
                        Server.operatingSystem = new OperatingSystem();
                    }
                    Server.operatingSystem.OperatingSystemId = value.Value; 
                }
            }
        }
        public string Processor { 
            get => Server.Processor; 
            set => Server.Processor = value; 
        }
        public string Memory { 
            get => Server.Memory; 
            set => Server.Memory = value;
        }
        public string Description { 
            get => Server.Description;
            set => Server.Description = value;
        }
        public string Dependency { 
            get => Server.Dependency; 
            set => Server.Dependency = value; 
        }
        public bool isAppServer { 
            get => Server.isAppServer; 
            set => Server.isAppServer = value;
        }
        public bool isWebServer { 
            get => Server.isWebServer; 
            set => Server.isWebServer = value;
        }
        public bool isDNSServer { 
            get => Server.isDNSServer; 
            set => Server.isDNSServer = value;
        }
        public bool isProxyServer { 
            get => Server.isProxyServer; 
            set => Server.isProxyServer = value; 
        }
        public bool isDatabaseServer { 
            get => Server.isDatabaseServer; 
            set => Server.isDatabaseServer = value;
        }
        public bool isMailServer { 
            get => Server.isMailServer; 
            set => Server.isMailServer = value; 
        }
        public bool isFileServer { 
            get => Server.isFileServer; 
            set => Server.isFileServer = value; 
        }
        public bool isPrintServer { 
            get => Server.isPrintServer; 
            set => Server.isPrintServer = value; 
        }
        public bool isMonitoringServer { 
            get => Server.isMonitoringServer; 
            set => Server.isMonitoringServer = value;
        }
        public bool isHybridServer { 
            get => Server.isHybridServer; 
            set => Server.isHybridServer = value; 
        }
        public long? WebServerSupport { 
            get => Server.WebServerSupport?.WebServerId ?? null; 
            set
            {
                if (!value.HasValue)
                {
                    Server.WebServerSupport = null;
                }
                else
                {
                    if(Server.WebServerSupport == null)
                    {
                        Server.WebServerSupport = new WebServer();
                    }
                    Server.WebServerSupport.WebServerId = value.Value;
                }
            } 
        }
        public long? DatabaseServerSupport { 
            get => Server.DatabaseServerSupport?.DatabaseServerId ?? null; 
            set {
                if (!value.HasValue)
                {
                    Server.DatabaseServerSupport = null;
                }
                else
                {
                    if(Server.DatabaseServerSupport == null)
                    {
                        Server.DatabaseServerSupport = new DatabaseServer();
                    }
                    Server.DatabaseServerSupport.DatabaseServerId = value.Value;
                }
            }    
        }
        public long? MailServerSupport { 
            get => Server.MailServerSupport?.MailServerId ?? null;
            set {
                if (!value.HasValue)
                {
                    Server.MailServerSupport = null;
                }
                else
                {
                    if(Server.MailServerSupport == null)
                    {
                        Server.MailServerSupport = new MailServer();
                    }
                    Server.MailServerSupport.MailServerId = value.Value;
                }
            }
        }
        public long? PrintServerSupport { 
            get => Server.PrintServerSupport?.PrintServerId ?? null; 
            set
            {
                if (!value.HasValue)
                {
                    Server.PrintServerSupport = null;
                }
                else
                {
                    if( Server.PrintServerSupport == null )
                    {
                        Server.PrintServerSupport = new PrintServer();
                    }
                    Server.PrintServerSupport.PrintServerId = value.Value;
                }
            }
        }
        public long? HybridServerSupport { 
            get => Server.HybridServerSupport?.HybridServerId ?? null; 
            set
            {
                if (!value.HasValue)
                {
                    Server.HybridServerSupport = null;
                }
                else
                {
                    if( Server.HybridServerSupport == null )
                    {
                        Server.HybridServerSupport = new HybridServer();
                    }
                    Server.HybridServerSupport.HybridServerId = value.Value;
                }
            } 
        }

        public Server Server { get; set; } = new Server();
    }

}
