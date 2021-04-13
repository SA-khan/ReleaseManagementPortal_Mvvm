import { Injectable } from "@angular/core";
import { Router, ActivatedRoute, NavigationEnd } from "@angular/router";
import { Repository } from "../models/repository";
import { filter } from "rxjs/operators";

@Injectable()
export class NavigationService {
  constructor(private repository: Repository, private router: Router, private active: ActivatedRoute) {
    router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(ev => this.handleNavigationChange());
  }

  private handleNavigationChange() {
    let active = this.active.firstChild.snapshot;
    if (active.url.length > 0 && active.url[0].path === "environments") {
      //if (active.params["EnvironmentTypOrCompanyOrProductOrSearchOrPage"] !== undefined) {
      if (active.params["categoryOrPage"] !== undefined) {
        //let value = Number.parseInt(active.params["EnvironmentTypeOrCompanyOrProductOrSearchOrPage"]);
        let value = Number.parseInt(active.params["categoryOrPage"]);
        if (!Number.isNaN(value)) {
          this.repository.envFilter.environmentType = "";
          //this.repository.envFilter.company = "";
          //this.repository.envFilter.product = "";
          //this.repository.envFilter.search = "";
          this.repository.paginationObject.currentPage = value;
        }
        else {
          this.repository.envFilter.environmentType = active.params["categoryOrPage"];
          //this.repository.envFilter.environmentType = active.params["EnvironmentTypeOrCompanyOrProductOrSearchOrPage"];
          this.repository.paginationObject.currentPage = Number.parseInt(active.params["Page"]);
        }
      }
      else {
        let envType = active.params["category"];
        //let envType = active.params["EnvironmentType"];
        //let company = active.params["Company"];
        //let product = active.params["Product"];
        //let search = active.params["Search"];
        this.repository.envFilter.environmentType = envType || "";
        //this.repository.envFilter.company = company || "";
        //this.repository.envFilter.product = product || "";
        //this.repository.envFilter.search = search || "";
        this.repository.paginationObject.currentPage = Number.parseInt(active.params["Page"]) || 1;
      }
      //let envType = active.params["environmenttype"];
      //this.repository.envFilter.environmentType = envType || "";
      //console.log('=>' + this.repository.environments.length.toLocaleString());
      this.repository.getEnvironments();
      //console.log('=>' + this.repository.environments.length.toLocaleString());
    }
  }

  get environmenttypes(): string[] {
    return this.repository.distinctEnvironmentTypes;
  }

  get companies(): string[] {
    return this.repository.distinctCompanies;
  }

  get products(): string[] {
    return this.repository.distinctProducts;
  }

  get currentEnvironmentType(): string {
    return this.repository.envFilter.environmentType;
  }

  get currentCompany(): string {
    return this.repository.envFilter.company;
  }

  get currentProduct(): string {
    return this.repository.envFilter.product;
  }

  get currentSearch(): string {
    return this.repository.envFilter.search;
  }

  set currentEnvironmentType(newEnvironmentType: string) {
    this.router.navigateByUrl(`/environments/${(newEnvironmentType || "").toLowerCase()}`);
  }

  get currentPage(): Number {
    return this.repository.paginationObject.currentPage;
  }

  set currentPage(newPage: Number) {
    // && this.currentCompany === "" && this.currentProduct === ""
    if (this.currentEnvironmentType === "") {
      this.router.navigateByUrl(`/environments/${newPage}`);
    }
    //else if (this.currentCompany != "") {
    //  this.router.navigateByUrl(`/environments/${this.currentEnvironmentType}/${this.currentCompany}/${newPage}`);
    //}
    //else if (this.currentProduct != "") {
    //  this.router.navigateByUrl(`/environments/${this.currentEnvironmentType}/${this.currentCompany}/${this.currentProduct}/${newPage}`);
    //}
    else {
      this.router.navigateByUrl(`/environments/${this.currentEnvironmentType}/${newPage}`);
    }
  }

  get environmentsPerPage(): number {
    return this.repository.paginationObject.environmentsPerPage;
  }

  get environmentsCount(): number {
    return (this.repository.environments || []).length;
  }

}
