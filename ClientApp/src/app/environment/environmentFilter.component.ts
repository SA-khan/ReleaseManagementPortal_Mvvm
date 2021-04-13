import { Component } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Repository } from '../models/repository';
import { NavigationService } from "../models/navigation.service";

@Component({
  selector: "environment-filter",
  templateUrl: "environmentFilter.component.html"
})

export class EnvironmentFilterComponent {
  constructor(public service: NavigationService, private router: Router, private activated: ActivatedRoute) {

  }

  onEnvironmentTypeChange($event) {
    console.log($event);
    this.router.navigateByUrl('/environments/', $event);
  }

  onCompanyChange($event) {
    console.log($event);
    this.router.navigateByUrl('/environments/', $event);
  }

  onProductChange($event) {
    console.log($event);
    this.router.navigateByUrl('/environments/', $event);
  }

  onBtnGoClick(environmentType: string, company: string, product: string) {
    //let search = '';
    //let page = 1;
    console.log('Environment Type: ' + environmentType + 'company: ' + company + ', product: ' + product);
    this.service.currentEnvironmentType = environmentType;
    //this.service.currentCompany = company;
    //this.service.currentProduct = product;
    //this.router.navigateByUrl('/environments/' + environmentType + '/' + company + '/' + product +'/'+ search +'/'+page+'');
    //this.router.navigateByUrl('/environments/' + environmentType + '/' + company + '/' + product + '/' + search + '/' + page + '');
  }
}
