namespace ProjectFirmaModels.Models
{
    public partial class PerformanceMeasureFixedTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Target Value: {PerformanceMeasureTargetValue}";
        }
    }
}