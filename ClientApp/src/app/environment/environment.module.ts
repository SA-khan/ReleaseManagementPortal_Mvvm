import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule } from "@angular/forms";
import { EnvironmentListComponent } from "./environmentList.component";
import { UserSummaryComponent } from "./userSummary.component";
import { EnvironmentSupplierComponent } from "./environmentSupplier.component";

@NgModule({
  providers: [EnvironmentListComponent, UserSummaryComponent],
  imports: [BrowserModule, FormsModule],
  exports: [EnvironmentSupplierComponent]
})

export class EnvironmentModule {

}
