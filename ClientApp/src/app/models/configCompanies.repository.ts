export class Filter {
  industry?: string;
  environmentType?: string;
  company?: string;
  product?: string;
  search?: string;
  related: boolean = true;
  still: boolean = true;
  reset() {
    this.industry = this.environmentType = this.company = this.product = this.search = null;
    this.related = true;
    this.still = true;
  }
}

export class Pagination {
  environmentsPerPage: number = 3;
  currentPage = 1;
}
