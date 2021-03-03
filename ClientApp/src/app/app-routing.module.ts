import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IndexPageComponent } from "./structure/indexPage.component";
import { CompanyTableComponent } from "./structure/companyTable.component";
import { CompanyDetailComponent } from "./structure/companyDetail.component";
import { ProductTableComponent } from "./structure/productTable.component";
import { ProductDetailComponent } from './structure/productDetail.component';
import { EnvironmentTableComponent } from "./structure/environmentTable.component";
import { ApplicationDetailComponent } from "./structure/applicationDetail.component";
import { ApplicationTableComponent } from "./structure/applicationTable.component";
import { EnvironmentDetailComponent } from './structure/environmentDetail.component';
import { EnvironmentSupplierComponent } from "./environment/environmentSupplier.component";

const routes: Routes = [
  { path: "productdetail", component: ProductDetailComponent },
  { path: "productdetail/:id", component: ProductDetailComponent },
  { path: "product", component: ProductTableComponent },
  { path: "detail", component: CompanyDetailComponent },
  { path: "detail/:id", component: CompanyDetailComponent },
  { path: "company", component: CompanyTableComponent },
  { path: "environmentdetail", component: EnvironmentDetailComponent },
  { path: "environmentdetail/:id", component: EnvironmentDetailComponent },
  { path: "environment", component: EnvironmentTableComponent },
  { path: "environmentoverview", component: EnvironmentSupplierComponent },
  { path: "applicationdetail", component: ApplicationDetailComponent },
  { path: "applicationdetail/:id", component: ApplicationDetailComponent },
  { path: "application", component: ApplicationTableComponent },
  { path: "", component: IndexPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
