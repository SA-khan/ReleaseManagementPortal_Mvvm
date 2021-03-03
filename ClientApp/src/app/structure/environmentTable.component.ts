import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Environment } from '../models/environment.model';

@Component({
  selector: "environment-list",
  templateUrl: "./environmentTable.component.html"
})

export class EnvironmentTableComponent {
  constructor(private repo: Repository) {

  }

  get environment(): Environment {
    return this.repo.environment;
  }

  get environments(): Environment[] {
    return this.repo.environments;
  } 

}
