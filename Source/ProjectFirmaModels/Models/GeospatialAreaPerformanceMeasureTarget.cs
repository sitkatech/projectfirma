namespace ProjectFirmaModels.Models
{
    public partial class GeospatialAreaPerformanceMeasureTarget : IAuditableEntity
    {
        /// <summary>
        /// Constructor with Tenant (clueless hack)
        /// </summary>
        public GeospatialAreaPerformanceMeasureTarget(GeospatialArea geospatialArea,
                                                     PerformanceMeasure performanceMeasure,
                                                     PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod,
                                                     Tenant tenant) : this(geospatialArea, performanceMeasure, performanceMeasureReportingPeriod)
        {
            this.TenantID = tenant.TenantID;
        }

        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Target Value: {GeospatialAreaPerformanceMeasureTargetValue}, Reporting Period ID: {PerformanceMeasureReportingPeriodID}";
        }
    }
}