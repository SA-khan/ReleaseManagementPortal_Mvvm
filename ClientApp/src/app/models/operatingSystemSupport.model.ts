import { OperatingSystem } from "./operatingSystem.model";

export class OperatingSystemSupport {
  constructor(
    public clientBrowserSupportId?: number,
    public operatingSystem?: OperatingSystem
  ) { }
}
