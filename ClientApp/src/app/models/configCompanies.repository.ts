export class Filter {
  industry: string;
  environmentType: string;
  company: string;
  product: string;
  search: string;
  related = true;
  still: boolean = true;
  reset() {
    this.industry = this.environmentType = this.company = this.product = this.search = null;
    this.related = false;
    this.still = true;
  }
}

export class Pagination {
  environmentsPerPage: number = 4;
  currentPage = 1;
}
