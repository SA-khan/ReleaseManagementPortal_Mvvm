import { Company } from "./company.model";
import { Product } from "./product.model";
import { EnvironmentType } from "./environmentType.model";
import { Server } from "./server.model";
import { User } from "./user.model";
import { DataLogFile } from './dataLogFile.model';

export class Database {
  constructor(
    public databaseId?: number,
    public name?: string,
    public company?: Company,
    public product?: Product,
    public environmentType?: EnvironmentType,
    public main?: boolean,
    public server?: Server,
    public instance?: string,
    public hash?: string,
    public mdfInformation?: DataLogFile,
    public ldfInformation?: DataLogFile,
    public lastBackupDate?: string,
    public backUpFileName?: string,
    public backUpFileLocation?: string,
    public backUpTakenPOC?: User,
    public lastRestoredDate?: string,
    public restoredFileName?: string,
    public restoredPOC?: User,
    public comments?: string
  ) { }
}


