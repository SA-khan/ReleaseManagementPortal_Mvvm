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
  myDate = new Date();
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
    this.repo.getRelease(id);
  }

  updateDescription(id: number, description: string) {
    console.log('Release ID: ' + id + ', Release Description: ' + description);
    let changes = new Map<string, any>();
    changes.set("description", description);
    this.repo.updateRelease(id, changes);
    this.repo.getRelease(id);
  }

  updateRemarks(id: number, remarks: string) {
    console.log('Release ID: ' + id + ', Release Remarks: ' + remarks);
    let changes = new Map<string, any>();
    changes.set("remarks", remarks);
    this.repo.updateRelease(id, changes);
    this.repo.getRelease(id);
  }

  updateEnvironmentType(id: number, environmentType: number) {
    console.log('Release ID: ' + id + ', Release Environment Type: ' + environmentType);
    //let changes = new Map<string, any>();
    //changes.set("environmentType", environmentType);
    //this.repo.updateRelease(id, changes);
    //this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    //this.repo.getRelease(id);
  }

  updateQualityAssuranceStatus(id: number, qaid: number, PatchQAStatusTrue: string, PatchQAStatusFalse: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Pass Status: ' + PatchQAStatusTrue.toString() + ', Release Quality Assurance Fail Status: ' + PatchQAStatusFalse.toString() );
    let changes = new Map<string, any>();
    if (PatchQAStatusTrue.toString()) {
      changes.set("isPassed", PatchQAStatusTrue.toString());
      this.repo.updateQualityAssurance(qaid, changes);
      this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    }
    else if (PatchQAStatusFalse.toString()) {
      changes.set("isPassed", PatchQAStatusFalse.toString());
      this.repo.updateQualityAssurance(qaid, changes);
      this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    }
    this.repo.getRelease(id);
    this.repo.getReleases();
    //this.router.navigateByUrl("/releasedetail/" + id);
  }

  updateQualityAssuranceRemarks(id: number, qaid: number, PatchQARemarks: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Remarks: ' + PatchQARemarks);
    let changes = new Map<string, any>();
    changes.set("remarks", PatchQARemarks);
    this.repo.updateQualityAssurance(qaid, changes);
    this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    this.repo.getRelease(id);
  }

  updateQualityAssuranceDocumentationLink(id: number, qaid: number, PatchQADocumentationLink: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Documentation Link: ' + PatchQADocumentationLink);
    let changes = new Map<string, any>();
    changes.set("documentationLink", PatchQADocumentationLink);
    this.repo.updateQualityAssurance(qaid, changes);
    this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    this.repo.getRelease(id);
  }

  updateQualityAssuranceDocumentLocation(id: number, qaid: number, PatchQADocumentLocation: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Document Location: ' + PatchQADocumentLocation);
    let changes = new Map<string, any>();
    changes.set("documentLocation", PatchQADocumentLocation);
    this.repo.updateQualityAssurance(qaid, changes);
    this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    this.repo.getRelease(id);
  }

  updateQualityAssuranceTitle(id: number, qaid: number, title: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Document Title: ' + title);
    let changes = new Map<string, any>();
    changes.set("title", title);
    this.repo.updateQualityAssurance(qaid, changes);
    this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    this.repo.getRelease(id);
  }

  updateQualityAssuranceDescription(id: number, qaid: number, description: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Description: ' + description);
    let changes = new Map<string, any>();
    changes.set("description", description);
    this.repo.updateQualityAssurance(qaid, changes);
    this.updateQualityAssuranceModifiedDate(id, qaid, this.myDate.toString());
    this.repo.getRelease(id);
  }

  updateQualityAssuranceCreatedDate(id: number, qaid: number, PatchQACreatedDate: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Created Date: ' + PatchQACreatedDate);
    let changes = new Map<string, any>();
    changes.set("createdDate", PatchQACreatedDate);
    this.repo.updateQualityAssurance(qaid, changes);
    this.repo.getRelease(id);
  }

  updateQualityAssuranceModifiedDate(id: number, qaid: number, PatchQAModifiedDate: string) {
    console.log('Release ID: ' + id + ', Release Quality Assurance Created Date: ' + PatchQAModifiedDate);
    let changes = new Map<string, any>();
    changes.set("modifiedDate", PatchQAModifiedDate);
    this.repo.updateQualityAssurance(qaid, changes);
    this.repo.getRelease(id);
  }

}
