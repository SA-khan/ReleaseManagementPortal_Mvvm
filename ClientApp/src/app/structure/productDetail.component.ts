import { Component } from "@angular/core";
import { Product } from "../models/product.model";
import { Repository } from "../models/repository";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "product-detail",
  templateUrl: "productDetail.component.html"
})

export class ProductDetailComponent {
  constructor(private repo: Repository, private router: Router, private activateRoute: ActivatedRoute) {
    let id = Number.parseInt(this.activateRoute.snapshot.params["id"]);
    if (id) {
      this.repo.getProduct(id);
    }
    else {
      this.router.navigateByUrl("/");
    }

  }
  get product(): Product {
    return this.repo.product;
  }
}
