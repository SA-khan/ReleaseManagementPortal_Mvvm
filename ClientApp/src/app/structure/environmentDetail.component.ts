import { Component, ElementRef } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Repository } from "../models/repository";
import { Environment } from '../models/environment.model';
import { Database } from '../models/database.model';
import { Server } from '../models/server.model';

@Component({
  selector: "environment-detail",
  templateUrl: "environmentDetail.component.html"
})

export class EnvironmentDetailComponent {

  public databaseUpdateStatus: boolean;
  public serverUpdateStatus: boolean;

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

  databaseupdate(envId: number, databaseId: number, serverId: number, databaseName: string, serverName: string, userId: string, password: string) {
    console.log('Database ID: ' + databaseId);
    
    var server = serverName.split("\\", 2);
    console.log('server: ' + server);

    let changes = new Map<string, any>();
    changes.set("name", databaseName);
    changes.set("instance", server[1]);
    //changes.set("server", 1);
    this.databaseUpdateStatus = this.repo.updateDatabase(databaseId, changes);
    

    let schanges = new Map<string, any>();
    schanges.set("ip", server[0]);
    schanges.set("userId", userId);
    schanges.set("password", password);
    this.serverUpdateStatus = this.repo.updateServer(serverId, schanges);

    this.router.navigateByUrl('environmentdetail/'+envId);

  }

}
