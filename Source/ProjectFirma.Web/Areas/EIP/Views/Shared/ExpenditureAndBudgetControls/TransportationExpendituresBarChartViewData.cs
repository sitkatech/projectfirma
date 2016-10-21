using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Areas.EIP.Views.Shared.ExpenditureAndBudgetControls
{
    public class TransportationExpendituresBarChartViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly GoogleChartJson GoogleChartJson;
        public readonly List<string> ChartColorRange;

        public TransportationExpendituresBarChartViewData(GoogleChartJson googleChartJson)
        {
            ChartColorRange = ProjectFirmaHelpers.DefaultColorRange;
            GoogleChartJson = googleChartJson;

            if (GoogleChartJson != null)
            {
                GoogleChartJson.GoogleChartConfiguration.SetSize(380, 420);
            }
        }
    }
}
