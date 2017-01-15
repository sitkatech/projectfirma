using System.Collections.Generic;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Results
{
    public class CalendarYearExpendituresLineChartViewData : FirmaUserControlViewData
    {
        public readonly GoogleChartJson GoogleChartJson;
        public readonly List<string> ChartColorRange;

        public CalendarYearExpendituresLineChartViewData(GoogleChartJson googleChartJson,
            List<string> chartColorRange)
        {
            GoogleChartJson = googleChartJson;
            if (GoogleChartJson != null)
            {
                GoogleChartJson.GoogleChartConfiguration.SetSize(415, 550);
            }

            HasChartData = GoogleChartJson != null && GoogleChartJson.HasData();
            ChartColorRange = chartColorRange;
        }

        public readonly bool HasChartData;
    }
}