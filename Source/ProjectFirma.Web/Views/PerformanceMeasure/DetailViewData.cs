/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class DetailViewData : FirmaViewData
    {
        public readonly Models.PerformanceMeasure PerformanceMeasure;
        public readonly PerformanceMeasureChartViewData PerformanceMeasureChartViewData;
        public readonly EntityNotesViewData EntityNotesViewData;

        public readonly bool UserHasPerformanceMeasureOverviewManagePermissions;

        public readonly string EditPerformanceMeasureUrl;
        public readonly string EditSubcategoriesAndOptionsUrl;
        public readonly string EditAccomplishmentsMetadataUrl;
        public readonly string EditCriticalDefinitionsUrl;
        public readonly string EditAccountingPeriodAndScaleUrl;
        public readonly string EditProjectReportingUrl;

        public readonly string IndexUrl;

        public readonly string EditMonitoringProgramsUrl;

        public readonly List<KeyValuePair<Models.TaxonomyTierTwo, bool>> TaxonomyTierTwoPerformanceMeasures;
        public readonly string EditTaxonomyTierTwosUrl;
        public readonly bool UserHasTaxonomyTierTwoPerformanceMeasureManagePermissions;
        public readonly PerformanceMeasureReportedValuesGridSpec PerformanceMeasureReportedValuesGridSpec;
        public readonly string PerformanceMeasureReportedValuesGridName;
        public readonly string PerformanceMeasureReportedValuesGridDataUrl;
        public readonly PerformanceMeasureExpectedGridSpec PerformanceMeasureExpectedGridSpec;
        public readonly string PerformanceMeasureExpectedsGridName;
        public readonly string PerformanceMeasureExpectedsGridDataUrl;

        public readonly string TaxonomyTierTwoDisplayName;
        public readonly string TaxonomyTierTwoDisplayNamePluralized;

        public DetailViewData(Person currentPerson,
            Models.PerformanceMeasure performanceMeasure,
            PerformanceMeasureChartViewData performanceMeasureChartViewData,
            EntityNotesViewData entityNotesViewData,
            bool userHasPerformanceMeasureManagePermissions) : base(currentPerson)
        {
            PageTitle = performanceMeasure.PerformanceMeasureDisplayName;
            EntityName = "PerformanceMeasure Detail";

            PerformanceMeasure = performanceMeasure;
            PerformanceMeasureChartViewData = performanceMeasureChartViewData;
            EntityNotesViewData = entityNotesViewData;
            UserHasPerformanceMeasureOverviewManagePermissions = userHasPerformanceMeasureManagePermissions;

            EditPerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Edit(performanceMeasure));
            EditSubcategoriesAndOptionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditSubcategoriesAndOptions(performanceMeasure));
            EditAccomplishmentsMetadataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditAccomplishmentsMetadata(performanceMeasure));
            EditMonitoringProgramsUrl = SitkaRoute<PerformanceMeasureMonitoringProgramController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureMonitoringPrograms(performanceMeasure));
                
            EditCriticalDefinitionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions));
            EditAccountingPeriodAndScaleUrl =
                SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.AccountingPeriodAndScale));
            EditProjectReportingUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting));

            IndexUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Index());

            UserHasTaxonomyTierTwoPerformanceMeasureManagePermissions = new TaxonomyTierTwoPerformanceMeasureManageFeature().HasPermission(currentPerson, performanceMeasure).HasPermission;
            EditTaxonomyTierTwosUrl = SitkaRoute<TaxonomyTierTwoPerformanceMeasureController>.BuildUrlFromExpression(c => c.Edit(performanceMeasure));
            TaxonomyTierTwoPerformanceMeasures = performanceMeasure.GetTaxonomyTierTwos().OrderBy(x => x.Key.DisplayName).ToList();

            PerformanceMeasureReportedValuesGridSpec = new PerformanceMeasureReportedValuesGridSpec(performanceMeasure)
            {
                ObjectNameSingular = "Reported Value for Projects",
                ObjectNamePlural = "Reported Values for Projects",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureReportedValuesGridName = "performanceMeasuresReportedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureReportedValuesGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureReportedValuesGridJsonData(performanceMeasure));

            PerformanceMeasureExpectedGridSpec = new PerformanceMeasureExpectedGridSpec(performanceMeasure)
            {
                ObjectNameSingular = "Expected Value for Projects",
                ObjectNamePlural = "Expected Values for Projects",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureExpectedsGridName = "performanceMeasuresExpectedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureExpectedsGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureExpectedsGridJsonData(performanceMeasure));
            TaxonomyTierTwoDisplayName = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabel();
            TaxonomyTierTwoDisplayNamePluralized = Models.FieldDefinition.TaxonomyTierTwo.GetFieldDefinitionLabelPluralized();
        }
    }
}
