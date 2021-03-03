import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Company } from "../models/company.model";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "company-detail",
  templateUrl: "companyDetail.component.html"
})
export class CompanyDetailComponent {
  constructor(private repo: Repository, router: Router, activeRoute: ActivatedRoute) {
    let id = Number.parseInt(activeRoute.snapshot.params["id"]);
    if (id) {
      this.repo.getCompany(id);
    }
    else {
      router.navigateByUrl("/");
    }

  }
  get company(): Company {
    return this.repo.company;
  }
}
