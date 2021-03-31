import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexPageComponent } from "./structure/indexPage.component";
import { CompanyTableComponent } from "./structure/companyTable.component";
import { CompanyDetailComponent } from "./structure/companyDetail.component";
import { ProductTableComponent } from "./structure/productTable.component";
import { ProductDetailComponent } from './structure/productDetail.component';
import { ApplicationDetailComponent } from "./structure/applicationDetail.component";
import { ApplicationTableComponent } from "./structure/applicationTable.component";
import { EnvironmentDetailComponent } from './environment/environmentDetail.component';
import { EnvironmentSupplierComponent } from "./environment/environmentSupplier.component";

const routes: Routes = [
  { path: "productdetail", component: ProductDetailComponent },
  { path: "productdetail/:id", component: ProductDetailComponent },
  { path: "products", component: ProductTableComponent },
  { path: "companydetail", component: CompanyDetailComponent },
  { path: "companydetail/:id", component: CompanyDetailComponent },
  { path: "companies", component: CompanyTableComponent },
  { path: "environments", component: EnvironmentSupplierComponent },
  { path: "environmentdetail", component: EnvironmentDetailComponent },
  { path: "environmentdetail/:id", component: EnvironmentDetailComponent },
  { path: "releasedetail", component: ApplicationDetailComponent },
  { path: "releasedetail/:id", component: ApplicationDetailComponent },
  { path: "releases", component: ApplicationTableComponent },
  { path: "", component: IndexPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
