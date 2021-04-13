import { Component, ElementRef } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Repository } from "../models/repository";
import { Environment } from '../models/environment.model';
import { Database } from '../models/database.model';
import { Api } from '../models/api.model';
import { Server } from '../models/server.model';

@Component({
  selector: "environment-detail",
  templateUrl: "environmentDetail.component.html"
})

export class EnvironmentDetailComponent {

  public databaseUpdateStatus: boolean;
  public serverUpdateStatus: boolean;

  //databases: Database[];
  databaseServerWithInstance: string[] = [];
  databaseName: string[] = [];
  databaseUserId: string[] = [];
  databasePassword: string[] = [];

  //apis: Api[];
  apiServerwithInstance: string[] = [];
  apiDatabaseName: string[] = [];
  apiUserId: string[] = [];
  apiPassword: string[] = [];

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
    console.log("db id: " + databaseId + ", server Id: " + serverId + ", Database Name: " + databaseName + ", Server: " + server + ", User ID: " + userId + ", Password: " + password);
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

    this.router.navigateByUrl('environments/');

  }

  apidatabaseupdate(envId: number, serverId: number, databaseId: number, databaseName: string, server: string, userId: string, password: string) {
    console.log("env id: " + envId + ", server Id: " + serverId + ", Database Name: " + databaseName + ", Server: " + server + ", User ID: " + userId + ", Password: " + password);
    console.log('Database ID: ' + databaseId);

    var serverName = server.split("\\", 2);
    console.log('server: ' + serverName);

    let changes = new Map<string, any>();
    changes.set("name", databaseName);
    changes.set("instance", serverName[1]);
    //let databaseId = this.repo.getDatabase(8);
    this.databaseUpdateStatus = this.repo.updateDatabase(databaseId, changes);
    this.repo.getDatabase(databaseId);


    let schanges = new Map<string, any>();
    schanges.set("ip", serverName[0]);
    schanges.set("userId", userId);
    schanges.set("password", password);
    this.serverUpdateStatus = this.repo.updateServer(serverId, schanges);

    this.router.navigateByUrl('environments/');
  }


}
