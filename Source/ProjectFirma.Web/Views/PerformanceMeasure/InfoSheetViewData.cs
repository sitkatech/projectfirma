/*-----------------------------------------------------------------------
<copyright file="InfoSheetViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class InfoSheetViewData : FirmaViewData
    {
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly bool HasReportedValues;
        public readonly List<KeyValuePair<Models.TaxonomyTierTwo, bool>> PerformanceMeasureTaxonomyTierTwos;
        public readonly string IndexUrl;
        public readonly string TaxonomyTierTwoDisplayName;
        public readonly string TaxonomyTierTwoDisplayNamePluralized;
        public List<GoogleChartJson> GoogleChartJsons { get; set; }

        public InfoSheetViewData(Person currentPerson, Models.PerformanceMeasure performanceMeasure, List<GoogleChartJson> googleChartJsons)
            : base(currentPerson)
        {
            PerformanceMeasure = performanceMeasure;
            HtmlPageTitle = $"PM {performanceMeasure.PerformanceMeasureID}";
            EntityName = "Performance Measure";
            BreadCrumbTitle = "Info Sheet";

            HasReportedValues = performanceMeasure.PerformanceMeasureActuals.Any();
            PerformanceMeasureTaxonomyTierTwos = performanceMeasure.GetTaxonomyTierTwos().OrderBy(x => x.Key.DisplayName).ToList();


            IndexUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
            TaxonomyTierTwoDisplayName = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel();
            TaxonomyTierTwoDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized();

            HasReportedValues = performanceMeasure.PerformanceMeasureActuals.Any();
            GoogleChartJsons = googleChartJsons;

            IndexUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(x => x.Index());
        }

    }
}
