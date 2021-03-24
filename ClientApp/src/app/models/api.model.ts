import { Environment } from "./environment.model";
export class Api {
  constructor(
    public apiId?: number,
    public name?: string,
    public folderHash?: string,
    public url?: string,
    public directoryLocation?: string,
    public tagLine?: string,
    public description?: string,
    public environment?: Environment,
    public main?: boolean,
    public comments?: string
  ) { }
}

