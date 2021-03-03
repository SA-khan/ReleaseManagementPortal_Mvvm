import { ClientBrowser } from "./clientBrowser.model";
export class ClientBrowserSupport {
  constructor(
    public clientBrowserSupportId?: number,
    public browser?: ClientBrowser
  ) { }
}
