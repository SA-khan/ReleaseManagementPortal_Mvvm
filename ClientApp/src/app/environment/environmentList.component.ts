import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Environment } from '../models/environment.model';
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "environments-list",
  templateUrl: "environmentList.component.html"
})

export class EnvironmentListComponent {
  constructor(private repo: Repository, private router: Router, private activateRoute: ActivatedRoute) {

  }

  get environment(): Environment {
    return this.repo.environment;
  }

  get environments(): Environment[] {
    if (this.repo.environments != null && this.repo.environments.length > 0) {
      let pageIndex = (this.repo.paginationObject.currentPage - 1) * this.repo.paginationObject.environmentsPerPage;
      return this.repo.environments.slice(pageIndex, pageIndex + this.repo.paginationObject.environmentsPerPage);
    }
    //return this.repo.environments;
  }

  environmentoverview(environment: Environment) {
    this.router.navigateByUrl("/environmentdetail/" + environment.environmentId);
  }

}
