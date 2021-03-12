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
    return this.repo.environments;
  }

  environmentoverview(environment: Environment) {
    this.router.navigateByUrl("/environmentdetail/" + environment.environmentId);
  }

}
