import { Company } from "./company.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Filter, Pagination } from "./configCompanies.repository";
import { Product } from './product.model';
import { Environment } from './environment.model';
import { Release } from "./release.model";
import { Database } from "./database.model";

const companiesUrl = "api/companies";
const productsUrl = "api/products";
const environmentUrl = "api/environments";
const releaseUrl = "api/releases";
const databaseUrl = "api/databases";

type environmentsMetadata = { envsdata: Environment[], environmenttypes: string[], companies: string[], products: string[]  }

@Injectable()
export class Repository {

  company: Company;
  companies: Company[];

  product: Product;
  products: Product[];

  environment: Environment;
  environments: Environment[];

  database: Database;
  databases: Database[];

  environmentTypes: string[];

  release: Release;
  releases: Release[];

  filter = new Filter();
  paginationObject = new Pagination();
  envFilter = new Filter();


  constructor(public http: HttpClient) {
    //this.filter.industry = null;
    //this.filter.search = null;
    this.filter.related = true;
    //this.filter.still = true;
    //this.getCompanies();
    this.getCompanies();
    this.getProducts();
    this.getEnvironments();
    this.getReleases();
  }

  getCompany(id: number) {
    this.http.get<Company>(`${companiesUrl}/${id}`).subscribe(c => this.company = c);
  }

  getCompanies() {
    let url = `${companiesUrl}?related=${this.filter.related}`;

    if (this.filter.industry) {
      url += `&industry=${this.filter.industry}`;
    }

    if (this.filter.search) {
      url += `&search=${this.filter.search}`;
    }

    if (this.filter.still) {
      url += `&still=${this.filter.still}`;
    }

    this.http.get<Company[]>(`${url}`).subscribe(cs => this.companies = cs);

  }

  getProduct(id: number) {
    let url = productsUrl + "/" + id;
    this.http.get<Product>(url).subscribe(prod => this.product = prod);
  }

  getProducts() {
    let url = productsUrl;
    this.http.get<Product[]>(productsUrl).subscribe(prods => this.products = prods);
  }

  getEnvironment(id: number) {
    this.http.get<Environment>(`${environmentUrl}/${id}`).subscribe(env => this.environment = env);
  }

  setEnvironment(database: Database): boolean {
    //this.http.patch
    return true;
  }

  getDatabases() {
    this.http.get<Database[]>(`${databaseUrl}`).subscribe(dbs => this.databases = dbs);
  }

  updateDatabase(id: number, changes: Map<string, any>): boolean {
    let patch = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${databaseUrl}/${id}`, patch).subscribe(() => this.getDatabases);
    return true;
  }

  getEnvironments() {
    let url = environmentUrl;

    this.http.get<Environment[]>(`${environmentUrl}`).subscribe(envs => this.environments = envs);
  }

  getRelease(id: number) {
    this.http.get<Release>(`${releaseUrl}/${id}`).subscribe(rel => this.release = rel);
  }

  getReleases() {
    this.http.get<Release[]>(`${releaseUrl}`).subscribe(rels => this.releases = rels);
  }


}
