import { Component } from "@angular/core";
import { Repository } from "../models/repository";
import { Release } from "../models/release.model";
import { Router, ActivatedRoute } from "@angular/router";
import { User } from '../models/user.model';
import { QualityAssurance } from '../models/qualityAssurance.model';
import { EnvironmentType } from '../models/environmentType.model';
import { Product } from '../models/product.model';
import { Company } from '../models/company.model';
import { NavigationService } from '../models/navigation.service';

@Component({
  selector: "application-detail",
  templateUrl: "applicationDetail.component.html"
})

export class ApplicationDetailComponent {
  constructor(private repo: Repository, private router: Router, private activateRoute: ActivatedRoute, public service: NavigationService) {
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

  updateRelease(id: number, title: string, description: string, developedBy: User, deployedBy: User, createdDate: string, deployedDate: string, qualityAssurance: QualityAssurance, patchNumber: string, company: Company, product: Product, environmentType: EnvironmentType, remarks: string) {
    console.log('Release ID: ' + id);
    let changes = new Map<string, any>();
    changes.set("title", title);
    changes.set("description", description);
    changes.set("patchNumber", patchNumber);
    changes.set("developedBy", developedBy);
    changes.set("deployedBy", deployedBy);
    changes.set("createdDate", createdDate);
    changes.set("deployedDate", deployedDate);
    changes.set("qualityAssurance", qualityAssurance);
    changes.set("company", company);
    changes.set("product", product);
    changes.set("environmentType", environmentType);
    changes.set("remarks", remarks);
    let status = this.repo.updateRelease(id, changes);
  }

  updatePatchNumber(id: number, patchNumber: string) {
    console.log('Release ID: '+ id +', Release Patch Number: ' + patchNumber);
    let changes = new Map<string, any>();
    changes.set("patchNumber", patchNumber);
    this.repo.updateRelease(id, changes);
    this.repo.getRelease(id);
  }

  updateTitle(id: number, title: string) {
    console.log('Release ID: ' + id + ', Release Title: ' + title);
    let changes = new Map<string, any>();
    changes.set("title", title);
    this.repo.updateRelease(id, changes);
    this.router.navigateByUrl("releasedetail/"+ id);
  }

  updateDescription(id: number, description: string) {
    console.log('Release ID: ' + id + ', Release Description: ' + description);
    let changes = new Map<string, any>();
    changes.set("description", description);
    this.repo.updateRelease(id, changes);
    this.router.navigateByUrl("releasedetail/" + id);
  }

  updateRemarks(id: number, remarks: string) {
    console.log('Release ID: ' + id + ', Release Remarks: ' + remarks);
    let changes = new Map<string, any>();
    changes.set("remarks", remarks);
    this.repo.updateRelease(id, changes);
    this.router.navigateByUrl("releasedetail/" + id);
  }

  updateEnvironmentType(id: number, environmentTypeName: string) {
    console.log('Release ID: ' + id + ', Release Environment Type: ' + environmentTypeName);
    //let changes = new Map<string, any>();
    //changes.set("name", environmentTypeName);
    //this.repo.updateEnvironmentType(id, changes);
    //this.router.navigateByUrl("releasedetail/" + id);
  }

}
