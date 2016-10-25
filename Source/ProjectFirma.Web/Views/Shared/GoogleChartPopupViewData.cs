namespace ProjectFirma.Web.Views.Shared
{
    public class GoogleChartPopupViewData : FirmaUserControlViewData
    {
        public GoogleChartPopupViewData(GoogleChartJson googleChartJson)
        {
            GoogleChartJson = googleChartJson;
            googleChartJson.GoogleChartConfiguration.MakeBig();
            
        }

        public readonly GoogleChartJson GoogleChartJson;
    }
}