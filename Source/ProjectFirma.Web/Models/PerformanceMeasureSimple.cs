namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSimple
    {
        public PerformanceMeasureSimple(PerformanceMeasure performanceMeasure)
            : this(
                performanceMeasure.PerformanceMeasureID,
                performanceMeasure.MeasurementUnitTypeID,
                performanceMeasure.PerformanceMeasureDisplayName,
                performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName,
                performanceMeasure.HasRealSubcategories,
                performanceMeasure.GetDefinitionAndGuidanceUrl())
        {
        }

        public PerformanceMeasureSimple(int performanceMeasureID,
            int measurementUnitTypeID,
            string displayName,
            string measurementUnitTypeDisplayName,
            bool hasRealSubcategories,
            string definitionAndGuidanceUrl)
        {
            PerformanceMeasureID = performanceMeasureID;
            MeasurementUnitTypeID = measurementUnitTypeID;
            DisplayName = displayName;
            MeasurementUnitTypeDisplayName = measurementUnitTypeDisplayName;
            HasRealSubcategories = hasRealSubcategories;
            DefinitionAndGuidanceUrl = definitionAndGuidanceUrl;
        }

        public int PerformanceMeasureID { get; set; }
        public string PerformanceMeasureName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public string DisplayName { get; set; }
        public string MeasurementUnitTypeDisplayName { get; set; }
        public bool HasRealSubcategories { get; set; }
        public string DefinitionAndGuidanceUrl { get; set; }
    }
}