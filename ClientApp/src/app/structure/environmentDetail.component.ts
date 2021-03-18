import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Repository } from "../models/repository";
import { Environment } from '../models/environment.model';
import { Database } from '../models/database.model';

@Component({
  selector: "environment-detail",
  templateUrl: "environmentDetail.component.html"
})

export class EnvironmentDetailComponent {

  public databaseUpdateStatus: boolean;

  constructor(private repo: Repository, private router: Router, activateRoute: ActivatedRoute) {
    let id = Number.parseInt(activateRoute.snapshot.params["id"]);
    if (id) {
      this.repo.getEnvironment(id);
    }
    else {
      router.navigateByUrl("/");
    }
  }

  get environment(): Environment {
    return this.repo.environment;
  }

  databaseupdate(database: Database) {
    console.log('Database ID: ' + database.databaseId);
    this.databaseUpdateStatus = this.repo.setEnvironment(database);
  }

}
