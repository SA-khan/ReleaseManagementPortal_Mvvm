import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { EnvironmentListComponent } from "./environmentList.component";
import { UserSummaryComponent } from "./userSummary.component";
import { EnvironmentSupplierComponent } from "./environmentSupplier.component";
import { EnvironmentFilterComponent } from "./environmentFilter.component";
import { EnvironmentPaginationComponent } from "./environmentPagination.component";
import { EnvironmentRatingComponent } from "./environmentRating.component";
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [EnvironmentListComponent, UserSummaryComponent, EnvironmentSupplierComponent, EnvironmentFilterComponent, EnvironmentPaginationComponent, EnvironmentRatingComponent],
  imports: [BrowserModule, FormsModule],
  exports: [EnvironmentSupplierComponent]
})

export class EnvironmentModule {

}
