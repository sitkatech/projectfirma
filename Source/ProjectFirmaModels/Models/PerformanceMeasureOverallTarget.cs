namespace ProjectFirmaModels.Models
{
    public partial class PerformanceMeasureOverallTarget : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Performance Measure: {PerformanceMeasureID}, Target Value: {PerformanceMeasureTargetValue}";
        }
    }
}