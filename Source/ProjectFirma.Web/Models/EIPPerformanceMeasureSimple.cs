namespace ProjectFirma.Web.Models
{
    public class EIPPerformanceMeasureSimple
    {
        public EIPPerformanceMeasureSimple(EIPPerformanceMeasure eipPerformanceMeasure)
            : this(
                eipPerformanceMeasure.EIPPerformanceMeasureID,
                eipPerformanceMeasure.EIPPerformanceMeasureTypeID,
                eipPerformanceMeasure.Indicator.IndicatorName,
                eipPerformanceMeasure.Indicator.MeasurementUnitTypeID,
                eipPerformanceMeasure.Indicator.DisplayOrder,
                eipPerformanceMeasure.DisplayName,
                eipPerformanceMeasure.Indicator.MeasurementUnitType.MeasurementUnitTypeDisplayName,
                eipPerformanceMeasure.Indicator.HasRealSubcategories,
                eipPerformanceMeasure.Indicator.GetDefinitionAndGuidanceUrl())
        {
        }

        public EIPPerformanceMeasureSimple(int eipPerformanceMeasureID,
            int eipPerformanceMeasureTypeID,
            string eipPerformanceMeasureName,
            int measurementUnitTypeID,
            int displayOrder,
            string displayName,
            string measurementUnitTypeDisplayName,
            bool hasRealSubcategories,
            string definitionAndGuidanceUrl)
        {
            EIPPerformanceMeasureID = eipPerformanceMeasureID;
            EIPPerformanceMeasureTypeID = eipPerformanceMeasureTypeID;
            EIPPerformanceMeasureName = eipPerformanceMeasureName;
            MeasurementUnitTypeID = measurementUnitTypeID;
            DisplayOrder = displayOrder;
            DisplayName = displayName;
            MeasurementUnitTypeDisplayName = measurementUnitTypeDisplayName;
            HasRealSubcategories = hasRealSubcategories;
            DefinitionAndGuidanceUrl = definitionAndGuidanceUrl;
        }

        public int EIPPerformanceMeasureID { get; set; }
        public int EIPPerformanceMeasureTypeID { get; set; }
        public string EIPPerformanceMeasureName { get; set; }
        public int MeasurementUnitTypeID { get; set; }
        public int DisplayOrder { get; set; }
        public string DisplayName { get; set; }
        public string MeasurementUnitTypeDisplayName { get; set; }
        public bool HasRealSubcategories { get; set; }
        public string DefinitionAndGuidanceUrl { get; set; }
    }
}