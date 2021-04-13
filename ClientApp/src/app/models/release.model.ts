import { Company } from "./company.model";
import { Product } from "./product.model";

import { Environment } from "./environment.model";
import { EnvironmentType } from "./environmentType.model";
import { ProductType } from "./productType.model";
import { Supplier } from "./supplier.model";
import { User } from "./user.model";
import { QualityAssurance } from './qualityAssurance.model';

export class Release {
  constructor(
    public releaseId?: number,
    public title?: string,
    public description?: string,
    public patchNumber?: string,
    public developedBy?: User,
    public deployedBy?: User,
    public createdDate?: string,
    public deployedDate?: string,
    public qualityAssurance?: QualityAssurance,
    public company?: Company,
    public product?: Product,
    public environment?: Environment,
    public environmentType?: EnvironmentType,
    public hyperLink?: string,
    public remarks?: string
  ) { }
}
