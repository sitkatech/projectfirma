namespace ProjectFirma.Web.Models
{
    public interface IEIPPerformanceMeasureValueSubcategoryOption
    {
        int EIPPerformanceMeasureID { get; }
        int IndicatorSubcategoryID { get; }
        IndicatorSubcategoryOption IndicatorSubcategoryOption { get; }
        EIPPerformanceMeasure EIPPerformanceMeasure { get; }
        IndicatorSubcategory IndicatorSubcategory { get; }
        int PrimaryKey { get; }
    }
}