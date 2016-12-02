namespace ProjectFirma.Web.Models
{
    public interface IPerformanceMeasureValueSubcategoryOption
    {
        int PerformanceMeasureID { get; }
        int PerformanceMeasureSubcategoryID { get; }
        PerformanceMeasureSubcategoryOption PerformanceMeasureSubcategoryOption { get; }
        PerformanceMeasure PerformanceMeasure { get; }
        PerformanceMeasureSubcategory PerformanceMeasureSubcategory { get; }
        int PrimaryKey { get; }
    }
}