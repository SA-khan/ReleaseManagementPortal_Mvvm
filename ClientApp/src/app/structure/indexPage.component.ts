import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Router } from "@angular/router";

@Component({
  selector: "index-page",
  templateUrl: "./indexPage.component.html"
})

export class IndexPageComponent {
  constructor(private repo: Repository, private router: Router) {

  }

}
