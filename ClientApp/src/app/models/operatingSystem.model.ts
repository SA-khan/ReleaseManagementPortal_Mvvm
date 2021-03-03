export class OperatingSystem {
  constructor (
    public operatingSystemId?: number,
    public name?: string,
    public logo?: string,
    public version?: string,
    public compatibilityMode?: string,
    public build?: string,
    public description?: string,
    public comments?: string ) { }
}
