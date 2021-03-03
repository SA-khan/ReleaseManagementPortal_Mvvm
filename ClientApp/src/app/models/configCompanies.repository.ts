export class Filter {
  industry: string;
  search: string;
  related = true;
  still: boolean = true;
  reset() {
    this.industry = this.search = null;
    this.related = false;
    this.still = true;
  }
}
