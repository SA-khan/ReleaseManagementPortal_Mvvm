export class Prerequisite {
  constructor(
    public productPrerequisiteId?: number,
    public operatingSystem?: string,
    public number?: number,
    public name?: string,
    public logo?: string,
    public description?: string,
    public details?: string,
    public createdOn?: string,
    public dependency?: string ) { }
}
