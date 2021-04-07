import { Component } from "@angular/core";
import { Environment } from "../models/environment.model";
import { Router } from "@angular/router";

@Component({
  selector: "environmentSupplier",
  templateUrl: "environmentSupplier.component.html"
})

export class EnvironmentSupplierComponent {
  constructor(private router: Router) { }
  environmentoverview(environment: Environment) {
    this.router.navigateByUrl("/environments/" + environment.environmentId);
  }
}
