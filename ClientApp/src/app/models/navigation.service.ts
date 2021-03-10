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
    if (active.url.length > 0 && active.url[0].path == "environmentoverview") {
      if (active.params["categoryOrPage"] !== undefined) {
        let value = Number.parseInt(active.params["categoryOrPage"]);
        if (!Number.isNaN(value)) {
          this.repository.envFilter.environmentType = "";
          this.repository.paginationObject.currentPage = value;
        }
        else {
          this.repository.envFilter.environmentType = active.params["categoryOrPage"];
          this.repository.paginationObject.currentPage = Number.parseInt(active.params["page"]);
        }
      }
      else {
        let category = active.params["category"];
        this.repository.envFilter.environmentType = category || "";
        this.repository.paginationObject.currentPage = Number.parseInt(active.params["page"]) || 1;
      }
      this.repository.getEnvironments();
    }
  }

  get environmentTypes(): string[] {
    return this.repository.environmentTypes;
  }

  get currentEnvironment(): string {
    return this.repository.envFilter.environmentType;
  }

  set currentEnvironment(newCategory: string) {
    this.router.navigateByUrl(`/environmentoverview/${(newCategory || "").toLowerCase()}`);
  }

  get currentPage(): Number {
    return this.repository.paginationObject.currentPage;
  }

  set currentPage(newPage: Number) {
    if (this.currentEnvironment === "") {
      this.router.navigateByUrl(`/environmentoverview/${newPage}`);
    }
    else {
      this.router.navigateByUrl(`/environmentoverview/${this.currentEnvironment}/${newPage}`);
    }
  }

  get environmentsPerPage(): number {
    return this.repository.paginationObject.environmentsPerPage;
  }

  get environmentsCount(): number {
    return (this.repository.environments || []).length;
  }

}
