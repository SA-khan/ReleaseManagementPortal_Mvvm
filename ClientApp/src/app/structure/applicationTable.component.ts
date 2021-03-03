import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Release } from "../models/release.model";

@Component({
  selector: "application-table",
  templateUrl: "applicationTable.component.html"
})

export class ApplicationTableComponent {
  constructor(private repo: Repository) {

  }

  get releases(): Release[] {
    return this.repo.releases;
  }

}
