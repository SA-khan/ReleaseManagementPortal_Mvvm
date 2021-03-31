import { Supplier } from "./supplier.model";
import { ProductType } from './productType.model';
import { ParentProduct } from './parentProduct.model';
import { Prerequisite } from './prerequisite.model';
import { OperatingSystemSupport } from './operatingSystemSupport.model';
import { Rating } from './rating.model';
import { ClientBrowserSupport } from './clientBrowserSupport.model';

export class Product {
  constructor(
    public productId?: number,
    public name?: string,
    public logo?: string,
    public type?: ProductType,
    public category?: string,
    public description?: string,
    public parentProduct?: ParentProduct,
    public prerequisites?: Prerequisite[],
    public operatingSystemSupports?: OperatingSystemSupport[],
    public clientBrowserSupports?: ClientBrowserSupport[],
    public supplier?: Supplier,
    public ratings?: Rating[],
    public updated?: boolean,
    public masterReleaseLink?: string,
    public masterReleaseWorkingDirecotory?: string,
    public releaseNotes?: string,
  ) { }
}
