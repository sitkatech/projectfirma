/*-----------------------------------------------------------------------
<copyright file="GoogleChartPopupViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared
{
    public class ViewGoogleChartViewData : FirmaUserControlViewData
    {
        public readonly List<GoogleChartJson> GoogleChartJsons;
        public readonly string DownloadChartDataUrl;
        public readonly string ChartPopupUrl;
        public readonly string ChartTitle;
        public readonly string MainColumnLabel;
        public readonly string ChartUniqueName;
        public readonly int ChartHeight;
        public readonly DateTime? LastUpdatedDate;
        public readonly bool CanConfigureChart;
        public readonly bool HasData;
        public readonly bool ShowChartTitle;
        public readonly bool SortChartsByLegendTitle;
        public readonly ProjectFirmaModels.Models.PerformanceMeasure PerformanceMeasure;
        public readonly bool HyperlinkPerformanceMeasureName;

        public ViewGoogleChartViewData(GoogleChartJson googleChartJson, string chartTitle, int chartHeight, bool showChartTitle) : this(googleChartJson == null ? new List<GoogleChartJson>() : new List<GoogleChartJson> {googleChartJson},
            chartTitle,
            chartHeight,
            null,
            chartTitle.Replace(" ", ""),
            false,
            SitkaRoute<GoogleChartController>.BuildUrlFromExpression(c => c.DownloadChartData()),
            showChartTitle,
            true,
            null,
            false)
        {
        }

        public ViewGoogleChartViewData(GoogleChartJson googleChartJson, string chartTitle, int chartHeight, bool showChartTitle, bool isPieChart) : this(googleChartJson == null ? new List<GoogleChartJson>() : new List<GoogleChartJson> { googleChartJson },
            chartTitle,
            chartHeight,
            null,
            chartTitle.Replace(" ", ""),
            false,
            SitkaRoute<GoogleChartController>.BuildUrlFromExpression(c => c.DownloadChartData()),
            showChartTitle,
            true,
            null,
            false)
        {
            if (isPieChart)
            {
                ChartPopupUrl = SitkaRoute<GoogleChartController>.BuildUrlFromExpression(c => c.GooglePieChartPopup());
            }
        }

        public ViewGoogleChartViewData(List<GoogleChartJson> googleChartJsons,
            string chartTitle,
            int chartHeight,
            DateTime? lastUpdatedDate,
            string chartUniqueName,
            bool canConfigureChart,
            string downloadChartDataUrl,
            bool showChartTitle,
            bool sortChartsByLegendTitle,
            ProjectFirmaModels.Models.PerformanceMeasure performanceMeasure,
            bool hyperlinkPerformanceMeasureName)
        {
            GoogleChartJsons = googleChartJsons;
            ChartTitle = chartTitle;
            var hasData = googleChartJsons.Count != 0 && googleChartJsons.Any(x => x != null && x.HasData());
            HasData = hasData;
            MainColumnLabel = hasData ? googleChartJsons.Where(x => x != null).Select(x => x.GoogleChartDataTable.GoogleChartColumns.FirstOrDefault()?.ColumnLabel).Distinct().SingleOrDefault() : null;
            ChartHeight = hasData ? chartHeight : 65;
            LastUpdatedDate = lastUpdatedDate;
            ChartUniqueName = chartUniqueName;
            DownloadChartDataUrl = downloadChartDataUrl;
            ChartPopupUrl = SitkaRoute<GoogleChartController>.BuildUrlFromExpression(c => c.GoogleChartPopup());
            CanConfigureChart = canConfigureChart;
            ShowChartTitle = showChartTitle;
            SortChartsByLegendTitle = sortChartsByLegendTitle;
            PerformanceMeasure = performanceMeasure;
            HyperlinkPerformanceMeasureName = hyperlinkPerformanceMeasureName;
        }
    }
}
