import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Environment } from '../models/environment.model';

@Component({
  selector: "environments-list",
  templateUrl: "environmentList.component.html"
})

export class EnvironmentListComponent {
  constructor(private repo: Repository) {

  }

  get environments(): Environment[] {
    return this.repo.environments;
  }

}
