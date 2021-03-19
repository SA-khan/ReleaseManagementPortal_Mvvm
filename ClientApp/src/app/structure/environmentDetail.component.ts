import { Component, ElementRef } from "@angular/core";
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

  databaseupdate(envId: number, databaseId: number, databaseName: string, serverName: string, userId: string, password: string) {
    console.log('Database ID: ' + databaseId);
    let changes = new Map<string, any>();
    changes.set("name", databaseName);
    //changes.set("server", 1);
    this.databaseUpdateStatus = this.repo.updateDatabase(databaseId, changes);
    this.router.navigateByUrl('/environmentoverview/');
  }

}
