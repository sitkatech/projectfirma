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
    public class SummaryViewData : EIPViewData
    {
        public enum IndicatorSummaryTab
        {
            Overview,
            EIP,
            SustainabilityDashboard,
            ThresholdDashboard
        }

        public class LakeTahoeInfoAreaSection
        {
            public readonly LTInfoArea LakeTahoeInfoArea;
            public readonly IndicatorSummaryTab IndicatorSummaryTab;
            public readonly bool IsReportedInArea;

            public LakeTahoeInfoAreaSection(LTInfoArea lakeTahoeInfoArea, IndicatorSummaryTab indicatorSummaryTab, bool isReportedInArea)
            {
                LakeTahoeInfoArea = lakeTahoeInfoArea;
                IndicatorSummaryTab = indicatorSummaryTab;
                IsReportedInArea = isReportedInArea;
            }
        }

        public readonly Models.Indicator Indicator;
        public readonly IndicatorSummaryTab ActiveTab;
        public readonly List<LakeTahoeInfoAreaSection> LakeTahoeInfoAreaSectons;
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
            List<LakeTahoeInfoAreaSection> lakeTahoeInfoAreaSectons,
            IndicatorChartViewData indicatorChartViewData,
            EntityNotesViewData entityNotesViewData,
            bool userHasIndicatorManagePermissions) : base(currentPerson)
        {
            PageTitle = indicator.IndicatorDisplayName;
            EntityName = "Indicator Detail";

            Indicator = indicator;
            ActiveTab = activeTab;
            LakeTahoeInfoAreaSectons = lakeTahoeInfoAreaSectons;
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

        public bool IsActiveTabSustainabilityDashboard
        {
            get { return ActiveTab == IndicatorSummaryTab.SustainabilityDashboard; }
        }

        public bool IsActiveTabThresholdDashboard
        {
            get { return ActiveTab == IndicatorSummaryTab.ThresholdDashboard; }
        }

        public string IndicatorReportedInText
        {
            get
            {
                var reportedInLakeTahoeInfoAreas = LakeTahoeInfoAreaSectons.Where(x => x.IsReportedInArea).Select(x => x.LakeTahoeInfoArea.LTInfoAreaDisplayName).ToList();
                if (reportedInLakeTahoeInfoAreas.Count > 2)
                {
                    return string.Format("{0} and {1}", string.Join(", ", reportedInLakeTahoeInfoAreas.Take(2)), reportedInLakeTahoeInfoAreas.Skip(2));
                }
                return string.Join(" and ", reportedInLakeTahoeInfoAreas);
            }
        }
    }
}