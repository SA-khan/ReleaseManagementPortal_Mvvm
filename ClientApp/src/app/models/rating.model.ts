import { Company } from "./company.model";
import { Product } from "./product.model";

export class Rating {
  constructor(
    public ratingId?: number,
    public isCompany?: boolean,
    public isProduct?: boolean,
    public stars?: number,
    public company?: Company,
    public product?: Product
  ) { }
}
