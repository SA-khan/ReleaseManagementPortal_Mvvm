import { Company } from "./company.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Filter, Pagination } from "./configCompanies.repository";
import { Product } from './product.model';
import { Environment } from './environment.model';
import { Release } from "./release.model";
import { Database } from "./database.model";
import { Server } from "./server.model";
import { Api } from './api.model';

const companiesUrl = "api/companies";
const productsUrl = "api/products";
const environmentUrl = "api/environments";
const releaseUrl = "api/releases";
const databaseUrl = "api/databases";
const serverUrl = "api/servers";
const apiUrl = "api/apis";

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

  server: Server;
  servers: Server[];

  api: Api;
  apis: Api[];

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

  getDatabase(id: number) {
    this.http.get<Database>(`${databaseUrl}`).subscribe(db => this.database = db);
  }

  getDatabases() {
    this.http.get<Database[]>(`${databaseUrl}`).subscribe(dbs => this.databases = dbs);
  }

  getServers() {
    this.http.get<Server[]>(`${serverUrl}`).subscribe(srs => this.servers = srs);
  }

  getApis() {
    this.http.get<Api[]>(`${apiUrl}`).subscribe(apis => this.apis = apis);
  }

  updateDatabase(id: number, changes: Map<string, any>): boolean {
    let patch = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${databaseUrl}/${id}`, patch).subscribe(() => this.getDatabases);
    return true;
  }

  updateServer(id: number, changes: Map<string, any>): boolean {
    let patch = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${serverUrl}/${id}`, patch).subscribe(() => this.getServers);
    return true;
  }

  updateApi(id: number, changes: Map<string, any>): boolean {
    let patch = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${apiUrl}/${id}`, patch).subscribe(() => this.getApis);
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
