namespace ProjectFirma.Web.Views.Indicator
{
    public class DefinitionAndGuidanceViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly Models.Indicator Indicator;

        public DefinitionAndGuidanceViewData(Models.Indicator indicator)
        {
            Indicator = indicator;
        }
    }
}