import { Component } from "@angular/core";
import { Repository } from "../models/repository";


@Component({
  selector: "environment-pagination",
  templateUrl: "environmentPagination.component.html"
})

export class EnvironmentPaginationComponent {
  constructor() {

  }

  //get pages(): number[] {
  //  if (this.navigation.environmentsCount > 0) {
  //    return Array(Math.ceil(this.navigation.environmentsCount / this.navigation.environmentsPerPage))
  //      .fill(0).map((x, i) => i + 1);
  //  }
  //  else {
  //    return [];
  //  }
  //}

}
