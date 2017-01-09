namespace ProjectFirma.Web.Models
{
    public class PerformanceMeasureSimple
    {
        public PerformanceMeasureSimple(PerformanceMeasure performanceMeasure)
            : this(
                performanceMeasure.PerformanceMeasureID,
                performanceMeasure.PerformanceMeasureName,
                performanceMeasure.MeasurementUnitTypeID,
                performanceMeasure.DisplayOrder,
                performanceMeasure.PerformanceMeasureDisplayName,
                performanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName,
                performanceMeasure.HasRealSubcategories,
                performanceMeasure.GetDefinitionAndGuidanceUrl())
        {
        }

        public PerformanceMeasureSimple(int performanceMeasureID,
            string performanceMeasureName,
            int measurementUnitTypeID,
            int displayOrder,
            string displayName,
            string measurementUnitTypeDisplayName,
            bool hasRealSubcategories,
            string definitionAndGuidanceUrl)
        {
            PerformanceMeasureID = performanceMeasureID;
            PerformanceMeasureName = performanceMeasureName;
            MeasurementUnitTypeID = measurementUnitTypeID;
            DisplayOrder = displayOrder;
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