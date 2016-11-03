using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ExpendituresBarChartViewData : FirmaUserControlViewData
    {
        public readonly GoogleChartJson GoogleChartJson;
        public readonly List<string> ChartColorRange;

        public ExpendituresBarChartViewData(GoogleChartJson googleChartJson)
        {
            ChartColorRange = FirmaHelpers.DefaultColorRange;
            GoogleChartJson = googleChartJson;

            if (GoogleChartJson != null)
            {
                GoogleChartJson.GoogleChartConfiguration.SetSize(380, 420);
            }
        }
    }
}
