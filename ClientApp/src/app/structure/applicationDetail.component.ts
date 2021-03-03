import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Release } from "../models/release.model";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "application-detail",
  templateUrl: "applicationDetail.component.html"
})

export class ApplicationDetailComponent {
  constructor(private repo: Repository, router: Router, activateRoute: ActivatedRoute) {
    let id = Number.parseInt(activateRoute.snapshot.params["id"]);
    if (id) {
      this.repo.getRelease(id);
    }
    else {
      router.navigateByUrl("/");
    }
  }

  get release(): Release {
    return this.repo.release;
  }

}
