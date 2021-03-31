import { Industry } from "./industry.model";
import { Rating } from "./rating.model";
import { User } from "./user.model";

export class Company {
  constructor(
    public companyId?: number,
    public name?: string,
    public tagline?: string,
    public industry?: Industry,
    public logo?: string,
    public ntn?: string,
    public phone?: string,
    public email?: string,
    public fax?: string,
    public website?: string,
    public ratings?: Rating[],
    public still?: boolean,
    public projectPoc?: User,
    public operationalPoc?: User,
    public technicalPoc?: User,
    public financialPoc?: User,
    public comments?: string ) { }
}
