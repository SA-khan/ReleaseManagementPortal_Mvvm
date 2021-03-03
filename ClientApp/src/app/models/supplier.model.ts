import { Product } from "./product.model";

export class Supplier {
  constructor(
    public supplierId?: number,
    public name?: string,
    public shortName?: string,
    public logo?: string,
    public website?: string,
    public email?: string,
    public phone?: string,
    public fax?: string,
    public city?: string,
    public state?: string,
    public products?: Product[] ) { }
}
