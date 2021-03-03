import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Company } from "../models/company.model";
import { Router } from "@angular/router";

@Component({
  selector: "company-table",
  templateUrl: "./companyTable.component.html"
})

export class CompanyTableComponent {
  constructor(private repo: Repository, private router: Router) {

  }
  get companies(): Company[] {
    return this.repo.companies;
  }

  selectCompany(id: number) {
    this.repo.getCompany(id);
    this.router.navigateByUrl("/detail")
  }

}
