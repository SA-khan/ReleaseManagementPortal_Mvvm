import { Component } from '@angular/core';
import { Repository } from "./models/repository";
import { Company } from "./models/company.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Release Management Portal';

  constructor(private repo: Repository) {

  }

  get company(): Company {
    return this.repo.company;
  }

  get companies(): Company[] {
    return this.repo.companies;
  }
  

}
