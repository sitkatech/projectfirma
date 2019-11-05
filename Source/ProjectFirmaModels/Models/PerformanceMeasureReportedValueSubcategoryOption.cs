namespace ProjectFirmaModels.Models
{
    public partial class PerformanceMeasureReportedValueSubcategoryOption : IPerformanceMeasureValueSubcategoryOption
    {
        public string GetPerformanceMeasureSubcategoryOptionName()
        {
            return this.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
        }
    }
}