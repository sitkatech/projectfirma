namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class DefinitionAndGuidanceViewData : FirmaUserControlViewData
    {
        public readonly Models.PerformanceMeasure PerformanceMeasure;

        public DefinitionAndGuidanceViewData(Models.PerformanceMeasure performanceMeasure)
        {
            PerformanceMeasure = performanceMeasure;
        }
    }
}