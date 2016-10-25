using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.EIPPerformanceMeasure;
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
            EIP
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
        public readonly string EditEIPContextUrl;

        public readonly string IndexUrl;

        public readonly string EditMonitoringProgramsUrl;

        public List<KeyValuePair<Models.Program, bool>> EIPPerformanceMeasurePrograms { get; private set; }
        public string EditProgramsUrl { get; private set; }
        public bool UserHasProgramEIPPerformanceMeasureManagePermissions { get; private set; }
        public EIPPerformanceMeasureReportedValuesGridSpec EIPPerformanceMeasureReportedValuesGridSpec { get; private set; }
        public string EIPPerformanceMeasureReportedValuesGridName { get; private set; }
        public string EIPPerformanceMeasureReportedValuesGridDataUrl { get; private set; }
        public EIPPerformanceMeasureExpectedGridSpec EipPerformanceMeasureExpectedGridSpec { get; private set; }
        public string EIPPerformanceMeasureExpectedsGridName { get; private set; }
        public string EIPPerformanceMeasureExpectedsGridDataUrl { get; private set; }

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
            EditEIPContextUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.EditIndicatorRichText(indicator, EditRtfContent.IndicatorRichTextType.EIPContext));

            IndexUrl = SitkaRoute<IndicatorController>.BuildUrlFromExpression(c => c.Index());

            // EIP specific
            SetEIPSpecificData(indicator, currentPerson);
        }

        private void SetEIPSpecificData(Models.Indicator indicator, Person currentPerson)
        {
            UserHasProgramEIPPerformanceMeasureManagePermissions = indicator.ReportedInEIP && new ProgramEIPPerformanceMeasureManageFeature().HasPermission(currentPerson, indicator.EIPPerformanceMeasure).HasPermission;
            EditProgramsUrl = indicator.ReportedInEIP ? SitkaRoute<ProgramEIPPerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPrograms(indicator.EIPPerformanceMeasure)) : string.Empty;
            EIPPerformanceMeasurePrograms = indicator.ReportedInEIP ? indicator.EIPPerformanceMeasure.GetPrograms().OrderBy(x => x.Key.DisplayName).ToList() : new List<KeyValuePair<Models.Program, bool>>();

            EIPPerformanceMeasureReportedValuesGridSpec = indicator.ReportedInEIP
                ? new EIPPerformanceMeasureReportedValuesGridSpec(indicator.EIPPerformanceMeasure)
                {
                    ObjectNameSingular = "Reported Value for Projects",
                    ObjectNamePlural = "Reported Values for Projects",
                    SaveFiltersInCookie = true
                }
                : null;

            EIPPerformanceMeasureReportedValuesGridName = "eipPerformanceMeasuresReportedValuesFromEIPPerformanceMeasureGrid";
            EIPPerformanceMeasureReportedValuesGridDataUrl = indicator.ReportedInEIP
                ? SitkaRoute<EIPPerformanceMeasureController>.BuildUrlFromExpression(tc => tc.EIPPerformanceMeasureReportedValuesGridJsonData(indicator.EIPPerformanceMeasure))
                : string.Empty;

            EipPerformanceMeasureExpectedGridSpec = indicator.ReportedInEIP
                ? new EIPPerformanceMeasureExpectedGridSpec(indicator.EIPPerformanceMeasure)
                {
                    ObjectNameSingular = "Expected Value for Projects",
                    ObjectNamePlural = "Expected Values for Projects",
                    SaveFiltersInCookie = true
                }
                : null;

            EIPPerformanceMeasureExpectedsGridName = "eipPerformanceMeasuresExpectedValuesFromEIPPerformanceMeasureGrid";
            EIPPerformanceMeasureExpectedsGridDataUrl = indicator.ReportedInEIP
                ? SitkaRoute<EIPPerformanceMeasureController>.BuildUrlFromExpression(tc => tc.EIPPerformanceMeasureExpectedsGridJsonData(indicator.EIPPerformanceMeasure))
                : string.Empty;
        }

        public bool IsActiveTabOverview
        {
            get { return ActiveTab == IndicatorSummaryTab.Overview; }
        }

        public bool IsActiveTabEIP
        {
            get { return ActiveTab == IndicatorSummaryTab.EIP; }
        }
    }
}