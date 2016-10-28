using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.Indicator
{
    public enum ChartViewMode
    {
        Small,
        Large,
        InfoSheet,
        ManagementMode,
        NoPopup

    }

    public class IndicatorChartViewData : FirmaUserControlViewData
    {
        private const int DefaultWidth = 500;
        private const int DefaultHeight = 350;
        public readonly Models.Indicator Indicator;
        public readonly int ChartWidth;
        public readonly int ChartHeight;
        public readonly bool HyperlinkIndicatorName;
        public readonly ChartViewMode ChartViewMode;
        public readonly Dictionary<string, GoogleChartJson> GoogleChartJsonDictionary;

        public readonly bool HasChartData;

        public IndicatorChartViewData(Models.Indicator indicator, int width, int height, bool hyperlinkIndicatorName, ChartViewMode chartViewMode, List<int> projectIDs)
        {
            ChartWidth = width;
            ChartHeight = height;

            Indicator = indicator;
            HyperlinkIndicatorName = hyperlinkIndicatorName;
            ChartViewMode = chartViewMode;

            GoogleChartJsonDictionary = indicator.GetGoogleChartJsonDictionary(projectIDs);
            foreach (var googleChartJson in GoogleChartJsonDictionary.Values)
            {
                //JHB 8/23/16: HACK! Chart popup doesn't honor project list filter, so popup was displaying all data for Funding Sources/Expenditures. Just turn off popup for now :(
                if (projectIDs != null && projectIDs.Any())
                {
                    ChartViewMode = ChartViewMode.NoPopup;
                }
                googleChartJson.GoogleChartConfiguration.SetSize(ChartHeight, ChartWidth);
            }

            HasChartData = GoogleChartJsonDictionary.Values.Any(x => x.GoogleChartDataTable.GoogleChartRowCs.Any());
        }

        public IndicatorChartViewData(Models.Indicator indicator, bool hyperlinkIndicatorName, ChartViewMode chartViewMode, List<int> projectIDs)
            : this(indicator, DefaultWidth, DefaultHeight, hyperlinkIndicatorName, chartViewMode, projectIDs)
        {
        }
    }
}