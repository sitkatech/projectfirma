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
        public readonly string EditAccomplishmentsMetadataUrl;
        public readonly string EditCriticalDefinitionsUrl;
        public readonly string EditAccountingPeriodAndScaleUrl;
        public readonly string EditProjectReportingUrl;

        public readonly string IndexUrl;

        public readonly string EditMonitoringProgramsUrl;

        public List<KeyValuePair<Models.TaxonomyTierTwo, bool>> TaxonomyTierTwoPerformanceMeasures { get; private set; }
        public string EditTaxonomyTierTwosUrl { get; private set; }
        public bool UserHasTaxonomyTierTwoPerformanceMeasureManagePermissions { get; private set; }
        public PerformanceMeasureReportedValuesGridSpec PerformanceMeasureReportedValuesGridSpec { get; private set; }
        public string PerformanceMeasureReportedValuesGridName { get; private set; }
        public string PerformanceMeasureReportedValuesGridDataUrl { get; private set; }
        public PerformanceMeasureExpectedGridSpec PerformanceMeasureExpectedGridSpec { get; private set; }
        public string PerformanceMeasureExpectedsGridName { get; private set; }
        public string PerformanceMeasureExpectedsGridDataUrl { get; private set; }

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
        }
    }
}