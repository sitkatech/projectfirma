/*-----------------------------------------------------------------------
<copyright file="InfoSheetViewData.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class InfoSheetViewData : FirmaViewData
    {
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly bool HasReportedValues;
        public readonly List<KeyValuePair<Models.TaxonomyTierTwo, bool>> PerformanceMeasureTaxonomyTierTwos;
        public readonly PerformanceMeasureChartViewData PerformanceMeasureChartViewData;
        public readonly string IndexUrl;
        
        public InfoSheetViewData(Person currentPerson, Models.PerformanceMeasure performanceMeasure, PerformanceMeasureChartViewData performanceMeasureChartViewData)
            : base(currentPerson)
        {
            PerformanceMeasure = performanceMeasure;
            HtmlPageTitle = string.Format("{0}: {1}", MultiTenantHelpers.GetPerformanceMeasureName(), performanceMeasure.PerformanceMeasureDisplayName);
            EntityName = MultiTenantHelpers.GetPerformanceMeasureName();
            BreadCrumbTitle = "Info Sheet";

            HasReportedValues = performanceMeasure.PerformanceMeasureActuals.Any();
            PerformanceMeasureTaxonomyTierTwos = performanceMeasure.GetTaxonomyTierTwos().OrderBy(x => x.Key.DisplayName).ToList();
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;

            IndexUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }
    }
}
