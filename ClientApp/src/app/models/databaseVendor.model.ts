import { Corporation } from "./corporation.model";
export class DatabaseVendor {
  constructor(
    public databaseVendorId?: number,
    public logo?: string,
    public corporation?: Corporation,
    public edition?: string,
    public version?: string,
    public runtime?: number,
    public build?: string,
    public description?: string
  ) { }
}


