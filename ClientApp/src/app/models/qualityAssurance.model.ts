import { User } from "./user.model";

export class QualityAssurance {
  constructor(
    public qualityAssuranceId: number,
    public title: string,
    public description: string,
    public performedBy: User,
    public verifiedBy: User,
    public isPassed: boolean,
    public documentationLink: string,
    public documentationLocation: string,
    public remarks: string
  ) { }
}

