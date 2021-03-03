import { Component } from "@angular/core";
import { Repository } from "../models/repository";
@Component({
  selector: "config-company",
  templateUrl: "configCompany.component.html"
  })
export class ConfigCompanyComponent {
  public chessGame = "asset";
  constructor(private repo: Repository) {
    
  }
  selectIndustry(industry: string) {
    if (industry) {
      this.repo.filter.industry = industry;
      this.repo.filter.related = false;
      this.repo.getCompanies();
      this.repo.companies;
    } else {
      this.repo.filter.related = true;
      this.repo.getCompanies();
      this.repo.companies;
    }
    
  }

}
