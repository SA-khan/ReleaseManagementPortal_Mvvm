import { User } from './user.model';


export class ParentProduct {
  constructor(
    public parentProductId?: number,
    public code?: string,
    public name?: string,
    public logo?: string,
    public tagline?: string,
    public description?: string,
    public userManualLink?: string,
    public mainPoc?: User,
    public teamName?: string,
    public teamQuantity?: number,
    public createdOn?: string,
    public comments?: string
  ) { }
}
