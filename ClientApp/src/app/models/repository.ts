import { Company } from "./company.model";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Filter, Pagination } from "./configCompanies.repository";
import { Product } from './product.model';
import { EnvironmentType } from './environmentType.model';
import { Environment } from './environment.model';
import { Release } from "./release.model";
import { Database } from "./database.model";
import { Server } from "./server.model";
import { Api } from './api.model';

const companiesUrl = "/api/companies";
const productsUrl = "/api/products";
const environmentTypeUrl = "/api/environmenttypes";
const environmentUrl = '/api/environments'; 
const releaseUrl = "/api/releases";
const databaseUrl = "/api/databases";
const serverUrl = "/api/servers";
const apiUrl = "/api/apis";
const apiQualityAssurance = "api/qualityassurances";

type environmentsMetadata = {
  environments: Environment[],
  distinctEnvironmentTypes: string[],
  distinctCompanies: string[],
  distinctProducts: string[]
}

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

  distinctEnvironmentTypes?: string[] = [];
  distinctCompanies?: string[] = [];
  distinctProducts?: string[] = [];

  environmentType: EnvironmentType;
  environmentTypes: EnvironmentType[];

  release: Release;
  releases: Release[];

  filter = new Filter();
  paginationObject = new Pagination();
  envFilter = new Filter();

  constructor(public http: HttpClient) {
    //this.filter.industry = null;
    //this.filter.search = null;
    this.filter.related = true;
    this.envFilter.related = true;
    //this.filter.still = true;
    //this.getCompanies();
    this.getCompanies();
    this.getProducts();
    //this.getEnvironments();
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

  getEnvironmentType(id: number) {
    this.http.get<EnvironmentType>(`${environmentTypeUrl}/${id}`).subscribe(envType => this.environmentType = envType);
  }

  getEnvironment(id: number) {
    this.http.get<Environment>(`${environmentUrl}/${id}`).subscribe(env => this.environment = env);
  }

  setEnvironment(database: Database): boolean {
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

  updateQualityAssurance(id: number, changes: Map<string, any>): boolean {
    let patch = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${apiQualityAssurance}/${id}`, patch).subscribe(() => this.getApis);
    return true;
  }

  getEnvironmentTypes() {
    let url = environmentTypeUrl;
    this.http.get<EnvironmentType[]>(`${url}`).subscribe(envTypes => this.environmentTypes = envTypes);
  }

  getEnvironments() {
    let url = environmentUrl;
    console.log('related =>' + this.envFilter.related);
    if (this.envFilter.related) {
      url += `?related=${this.envFilter.related}`; 
    }
    console.log('environmenttype =>' + this.envFilter.environmentType);
    if (this.envFilter.environmentType) {
      url += `&environmenttype=${this.envFilter.environmentType}`;
    }
    console.log('company =>' + this.envFilter.company);
    if (this.envFilter.company) {
      url += `&company=${this.envFilter.company}`;
    }
    console.log('product =>' + this.envFilter.product);
    if (this.envFilter.product) {
      url += `&product=${this.envFilter.product}`;
    }
    if (this.envFilter.industry) {
      url += `&industry=${this.envFilter.industry}`;
    }
    if (this.envFilter.search) {
      url += `&search=${this.envFilter.search}`;
    }
    url += '&metadata=true';
    console.log('url =>' + url);
    let a = '/api/environments?related=true&metatdata=true';
    this.http.get<environmentsMetadata>(a).subscribe(md => { this.environments = md.environments; this.distinctEnvironmentTypes = md.distinctEnvironmentTypes; this.distinctCompanies = md.distinctCompanies; this.distinctProducts = md.distinctProducts; });
    //console.log(this.environments[0].logo);
  }

  getRelease(id: number) {
    this.http.get<Release>(`${releaseUrl}/${id}`).subscribe(rel => this.release = rel);
  }

  getReleases() {
    this.http.get<Release[]>(`${releaseUrl}`).subscribe(rels => this.releases = rels);
  }

  updateRelease(id: number, changes: Map<string, any>): boolean {
    let patch = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch<Release>(`${releaseUrl}/${id}`, patch).subscribe(() => { this.getRelease(id); this.getReleases() });
    return true;
  }

  //updateReleaseEnvironmentType(id: number, changes: Map<string, any>): boolean {
  //  let patch = [];
  //  changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
  //  this.http.patch<Release>(`${releaseUrl}/${id}`, patch).subscribe(() => this.getRelease(id));
  //  return true;
  //}

  updateEnvironmentType(id: number, changes: Map<string, any>): boolean {
    let patch = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch<EnvironmentType>(`${environmentTypeUrl}/${id}`, patch).subscribe(() => this.getEnvironmentType(id));
    return true;
  }

}
