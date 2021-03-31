export class HealthCheck {
  constructor(
    public healthCheckId?: number,
    public date?: string,
    public referenceLink?: string,
    public directory?: string,
    public passed?: boolean,
    public description?: string
  ) { }
}
