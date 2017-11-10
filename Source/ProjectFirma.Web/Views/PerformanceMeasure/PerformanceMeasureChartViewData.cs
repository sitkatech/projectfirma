/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureChartViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class PerformanceMeasureChartViewData : FirmaUserControlViewData
    {
        private const int DefaultHeight = 350;
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly bool HyperlinkPerformanceMeasureName;
        public readonly List<GoogleChartJson> GoogleChartJsons;
        public readonly bool CanManagePerformanceMeasures;
        public readonly bool ShowLastUpdatedDate;
        public readonly string ChartTitle;

        public readonly ViewGoogleChartViewData ViewGoogleChartViewData;

        public PerformanceMeasureChartViewData(Models.PerformanceMeasure performanceMeasure,
            int height,
            List<int> projectIDs,
            Person currentPerson,
            bool showLastUpdatedDate,
            bool fromPerformanceMeasureDetailPage)
        {
            PerformanceMeasure = performanceMeasure;
            HyperlinkPerformanceMeasureName = !fromPerformanceMeasureDetailPage;

            GoogleChartJsons = performanceMeasure.GetGoogleChartJsonDictionary(projectIDs);

            var currentPersonHasManagePermission = new PerformanceMeasureManageFeature().HasPermissionByPerson(currentPerson);
            CanManagePerformanceMeasures = currentPersonHasManagePermission && fromPerformanceMeasureDetailPage;

            ShowLastUpdatedDate = showLastUpdatedDate;
            ChartTitle = performanceMeasure.ChartTitle;
            ViewGoogleChartViewData = new ViewGoogleChartViewData(GoogleChartJsons,
                ChartTitle,
                height,
                null,
                performanceMeasure.GetJavascriptSafeChartUniqueName(),
                CanManagePerformanceMeasures,
                SitkaRoute<GoogleChartController>.BuildUrlFromExpression(c => c.DownloadPerformanceMeasureChartData()),
                true,
                true,
                performanceMeasure,
                HyperlinkPerformanceMeasureName);
        }

        public PerformanceMeasureChartViewData(Models.PerformanceMeasure performanceMeasure, List<int> projectIDs, Person currentPerson,
            bool showLastUpdatedDate) : this(
            performanceMeasure,
            DefaultHeight,
            projectIDs,
            currentPerson,
            showLastUpdatedDate,
            false)
        {
        }

        public PerformanceMeasureChartViewData(Models.PerformanceMeasure performanceMeasure, List<int> projectIDs, Person currentPerson, bool showLastUpdatedDate, bool showConfigureOption) : this(
            performanceMeasure,
            DefaultHeight,
            projectIDs,
            currentPerson,
            showLastUpdatedDate,
            showConfigureOption)
        {
        }
    }
}
