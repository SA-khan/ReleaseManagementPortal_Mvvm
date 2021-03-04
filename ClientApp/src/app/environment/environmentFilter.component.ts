import { Component } from "@angular/core";
import { Repository } from '../models/repository';

@Component({
  selector: "environment-filter",
  templateUrl: "environmentFilter.component.html"
})

export class EnvironmentFilterComponent {
  constructor(private repo: Repository) {

  }
}
