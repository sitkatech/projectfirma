namespace ProjectFirmaModels.Models
{
    public class PerformanceMeasureSubcategoryOptionFromProjectFirma
    {
        public PerformanceMeasureSubcategoryOptionFromProjectFirma()
        {
        }

        public int PerformanceMeasureSubcategoryOptionID { get; set; }
        public int PerformanceMeasureSubcategoryID { get; set; }
        public string PerformanceMeasureSubcategoryOptionName { get; set; }

        public PerformanceMeasureSubcategoryOptionFromProjectFirma(IPerformanceMeasureValueSubcategoryOption performanceMeasureValueSubcategoryOption)
        {
            PerformanceMeasureSubcategoryOptionID = performanceMeasureValueSubcategoryOption.PerformanceMeasureSubcategoryOptionID;
            PerformanceMeasureSubcategoryID = performanceMeasureValueSubcategoryOption.PerformanceMeasureSubcategoryID;
            PerformanceMeasureSubcategoryOptionName = performanceMeasureValueSubcategoryOption.GetPerformanceMeasureSubcategoryOptionName();
        }
    }
}