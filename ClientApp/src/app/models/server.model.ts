import { ServerType } from "./serverType.model";
import { WebServer } from "./webServer.model";
export class Server {
  constructor(
    public serverId: number,
    public serverType: ServerType,
    public name: string,
    public ip: string,
    public port: number,
    public domain: string,
    public userId: string,
    public password: string,
    public isRemoteBased: boolean,
    public isVirtualized: boolean,
    public isCloudBased: boolean,
    public processor: string,
    public memory: string,
    public description: string,
    public dependency: string,
    public isAppServer: boolean,
    public isWebServer: boolean,
    public isDNSServer: boolean,
    public isProxyServer: boolean,
    public isDatabaseServer: boolean,
    public isMailServer: boolean,
    public isFileServer: boolean,
    public isPrintServer: boolean,
    public isMonitoringServer: boolean,
    public isHybridServer: boolean,
    public webServerSupport: WebServer,
    public databaseServerSupport: string,
    public mailServerSupport: string,
    public printServerSupport: string,
    public hybridServerSupport: string
  ) { }
}

