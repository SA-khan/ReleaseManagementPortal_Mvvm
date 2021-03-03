export class HealthCheck {
  constructor(
    public healthCheckId?: number,
    public date?: string,
    public referenceLink?: string,
    public directory?: string,
    public isPassed?: boolean,
    public description?: string
  ) { }
}
