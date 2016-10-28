using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Indicator
{
    public class SummaryViewData : FirmaViewData
    {
        public enum IndicatorSummaryTab
        {
            Overview,
            PerformanceMeasure
        }

        public readonly Models.Indicator Indicator;
        public readonly IndicatorSummaryTab ActiveTab;
        public readonly IndicatorChartViewData IndicatorChartViewData;
        public readonly EntityNotesViewData EntityNotesViewData;

        public readonly bool UserHasIndicatorOverviewManagePermissions;

        public readonly string EditIndicatorUrl;
        public readonly string EditAccomplishmentsMetadataUrl;
        public readonly string EditAssociatedProgramsUrl;
        public readonly string EditCriticalDefinitionsUrl;
        public readonly string EditAccountingPeriodAndScaleUrl;
        public readonly string EditProjectReportingUrl;

        public readonly string IndexUrl;

        public readonly string EditMonitoringProgramsUrl;

        public List<KeyValuePair<Models.Program, bool>> ProgramPerformanceMeasures { get; private set; }
        public string EditProgramsUrl { get; private set; }
        public bool UserHasProgramPerformanceMeasureManagePermissions { get; private set; }
        public PerformanceMeasureReportedValuesGridSpec PerformanceMeasureReportedValuesGridSpec { get; private set; }
        public string PerformanceMeasureReportedValuesGridName { get; private set; }
        public string PerformanceMeasureReportedValuesGridDataUrl { get; private set; }
        public PerformanceMeasureExpectedGridSpec PerformanceMeasureExpectedGridSpec { get; private set; }
        public string PerformanceMeasureExpectedsGridName { get; private set; }
        public string PerformanceMeasureExpectedsGridDataUrl { get; private set; }

        public SummaryViewData(Person currentPerson,
            Models.Indicator indicator,
            IndicatorSummaryTab activeTab,
            IndicatorChartViewData indicatorChartViewData,
            EntityNotesViewData entityNotesViewData,
            bool userHasIndicatorManagePermissions) : base(currentPerson)
        {
            PageTitle = indicator.IndicatorDisplayName;
            EntityName = "Indicator Detail";

            Indicator = indicator;
            ActiveTab = activeTab;
            IndicatorChartViewData = indicatorChartViewData;
            EntityNotesViewData = entityNotesViewData;
            UserHasIndicatorOverviewManagePermissions = userHasIndicatorManagePermissions;

            EditIndicatorUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.Edit(indicator));
            EditAccomplishmentsMetadataUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.EditAccomplishmentsMetadata(indicator));
            EditMonitoringProgramsUrl = SitkaRoute<IndicatorMonitoringProgramController>.BuildUrlFromExpression(c => c.EditIndicatorMonitoringPrograms(indicator));
                
            EditAssociatedProgramsUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.EditIndicatorRichText(indicator, EditRtfContent.IndicatorRichTextType.AssociatedPrograms));
            EditCriticalDefinitionsUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.EditIndicatorRichText(indicator, EditRtfContent.IndicatorRichTextType.CriticalDefinitions));
            EditAccountingPeriodAndScaleUrl =
                SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.EditIndicatorRichText(indicator, EditRtfContent.IndicatorRichTextType.AccountingPeriodAndScale));
            EditProjectReportingUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.EditIndicatorRichText(indicator, EditRtfContent.IndicatorRichTextType.ProjectReporting));

            IndexUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.Index());

            UserHasProgramPerformanceMeasureManagePermissions = new ProgramPerformanceMeasureManageFeature().HasPermission(currentPerson, indicator.PerformanceMeasure).HasPermission;
            EditProgramsUrl = SitkaRoute<ProgramPerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPrograms(indicator.PerformanceMeasure));
            ProgramPerformanceMeasures = indicator.PerformanceMeasure.GetPrograms().OrderBy(x => x.Key.DisplayName).ToList();

            PerformanceMeasureReportedValuesGridSpec = new PerformanceMeasureReportedValuesGridSpec(indicator.PerformanceMeasure)
            {
                ObjectNameSingular = "Reported Value for Projects",
                ObjectNamePlural = "Reported Values for Projects",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureReportedValuesGridName = "performanceMeasuresReportedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureReportedValuesGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureReportedValuesGridJsonData(indicator.PerformanceMeasure));

            PerformanceMeasureExpectedGridSpec = new PerformanceMeasureExpectedGridSpec(indicator.PerformanceMeasure)
            {
                ObjectNameSingular = "Expected Value for Projects",
                ObjectNamePlural = "Expected Values for Projects",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureExpectedsGridName = "performanceMeasuresExpectedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureExpectedsGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureExpectedsGridJsonData(indicator.PerformanceMeasure));
        }

        public bool IsActiveTabOverview
        {
            get { return ActiveTab == IndicatorSummaryTab.Overview; }
        }

        public bool IsActiveTabPerformanceMeasure
        {
            get { return ActiveTab == IndicatorSummaryTab.PerformanceMeasure; }
        }
    }
}