using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public enum ChartViewMode
    {
        Small,
        Large,
        InfoSheet,
        ManagementMode,
        NoPopup

    }

    public class PerformanceMeasureChartViewData : FirmaUserControlViewData
    {
        private const int DefaultWidth = 500;
        private const int DefaultHeight = 350;
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly int ChartWidth;
        public readonly int ChartHeight;
        public readonly bool HyperlinkPerformanceMeasureName;
        public readonly ChartViewMode ChartViewMode;
        public readonly Dictionary<string, GoogleChartJson> GoogleChartJsonDictionary;

        public readonly bool HasChartData;

        public PerformanceMeasureChartViewData(Models.PerformanceMeasure performanceMeasure, int width, int height, bool hyperlinkPerformanceMeasureName, ChartViewMode chartViewMode, List<int> projectIDs)
        {
            ChartWidth = width;
            ChartHeight = height;

            PerformanceMeasure = performanceMeasure;
            HyperlinkPerformanceMeasureName = hyperlinkPerformanceMeasureName;
            ChartViewMode = chartViewMode;

            GoogleChartJsonDictionary = performanceMeasure.GetGoogleChartJsonDictionary(projectIDs);
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

        public PerformanceMeasureChartViewData(Models.PerformanceMeasure performanceMeasure, bool hyperlinkPerformanceMeasureName, ChartViewMode chartViewMode, List<int> projectIDs)
            : this(performanceMeasure, DefaultWidth, DefaultHeight, hyperlinkPerformanceMeasureName, chartViewMode, projectIDs)
        {
        }
    }
}