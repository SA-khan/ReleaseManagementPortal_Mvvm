import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ModelModule } from "./models/model.module";
import { IndexPageComponent } from "./structure/indexPage.component";
import { CompanyTableComponent } from "./structure/companyTable.component";
import { CompanyDetailComponent } from "./structure/companyDetail.component";
import { ConfigCompanyComponent } from "./structure/configCompany.component";
//, CompanyTableComponent, ConfigCompanyComponent, CompanyDetailComponent

import { ProductTableComponent } from "./structure/productTable.component";
import { ProductDetailComponent } from "./structure/productDetail.component";

import { EnvironmentTableComponent } from "./structure/environmentTable.component";
import { EnvironmentDetailComponent } from "./structure/environmentDetail.component";

import { EnvironmentSupplierComponent } from "./environment/environmentSupplier.component";
import { EnvironmentModule } from "./environment/environment.module";

import { ApplicationTableComponent } from "./structure/applicationTable.component";
import { ApplicationDetailComponent } from "./structure/applicationDetail.component";

@NgModule({
  declarations: [
    AppComponent,
    IndexPageComponent,
    CompanyTableComponent,
    ConfigCompanyComponent,
    CompanyDetailComponent,
    ProductTableComponent,
    ProductDetailComponent,
    EnvironmentTableComponent,
    EnvironmentDetailComponent,
    EnvironmentSupplierComponent,
    ApplicationTableComponent,
    ApplicationDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ModelModule,
    EnvironmentModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
