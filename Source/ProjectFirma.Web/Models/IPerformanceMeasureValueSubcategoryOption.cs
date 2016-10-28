namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureValueSubcategoryOption
    {
        int PerformanceMeasureID { get; }
        int IndicatorSubcategoryID { get; }
        IndicatorSubcategoryOption IndicatorSubcategoryOption { get; }
        PerformanceMeasure PerformanceMeasure { get; }
        IndicatorSubcategory IndicatorSubcategory { get; }
        int PrimaryKey { get; }
    }
}