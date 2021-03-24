import { Server } from "./server.model";
import { Company } from "./company.model";
import { Product } from "./product.model";
import { EnvironmentType } from "./environmentType.model";
import { HealthCheck } from "./healthCheck.model";
import { WebServer } from "./webServer.model";
import { OperatingSystem } from "./operatingSystem.model";
import { Api } from "./api.model";
import { Database } from "./database.model";

export class Environment {
  constructor(
    public environmentId: number,
    public title: string,
    public description: string,
    public server: Server,
    public webServer: WebServer,
    public applicationHyperLink: string,
    public workingDirectory: string,
    public apiDependency: Api[],
    public databaseDependency: Database[],
    public dependency: string,
    public company: Company,
    public product: Product,
    public environmentType: EnvironmentType,
    public main: boolean,
    public dockerized: boolean,
    public dockerImage: string,
    public dockerDescription: string,
    public updated: boolean,
    public lastHealthCheck: HealthCheck,
    public createdDate: string,
    public modifiedDate: string,
    public logo: string,
    public remarks: string
  ) { }
}
