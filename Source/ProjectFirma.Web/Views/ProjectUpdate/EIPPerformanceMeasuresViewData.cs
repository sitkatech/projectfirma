using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.EIPPerformanceMeasureControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class EIPPerformanceMeasuresViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly EIPPerformanceMeasureReportedValuesSummaryViewData EIPPerformanceMeasureReportedValuesSummaryViewData;
        public readonly ViewDataForAngularEditor ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly bool IsImplementationStartYearValid;
        public readonly string DiffUrl;

        public EIPPerformanceMeasuresViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ViewDataForAngularEditor viewDataForAngularEditor, UpdateStatus updateStatus)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.EIPPerformanceMeasures, updateStatus)
        {
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshEIPPerformanceMeasures(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffEIPPerformanceMeasures(projectUpdateBatch.Project));
            var eipPerformanceMeasureActualUpdates = projectUpdateBatch.EIPPerformanceMeasureActualUpdates;
            var eipPerformanceMeasureSubcategoriesCalendarYearReportedValues =
                EIPPerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromEIPPerformanceMeasuresAndCalendarYears(new List<IEIPPerformanceMeasureReportedValue>(eipPerformanceMeasureActualUpdates));
            EIPPerformanceMeasureReportedValuesSummaryViewData = new EIPPerformanceMeasureReportedValuesSummaryViewData(eipPerformanceMeasureSubcategoriesCalendarYearReportedValues,
                projectUpdateBatch.ProjectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList(),
                projectUpdateBatch.EIPPerformanceMeasureActualYearsExemptionExplanation,
                eipPerformanceMeasureActualUpdates.Select(x => x.CalendarYear).Distinct().Select(x => new CalendarYearString(x)).ToList());
            ViewDataForAngular = viewDataForAngularEditor;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.EIPPerformanceMeasuresComment, projectUpdateBatch.IsReturned);
            IsImplementationStartYearValid = projectUpdateBatch.ProjectUpdate.ImplementationStartYear.HasValue &&
                                             projectUpdateBatch.ProjectUpdate.ImplementationStartYear < projectUpdateBatch.ProjectUpdate.CompletionYear;
        }

        public class ViewDataForAngularEditor
        {
            public readonly int ProjectUpdateBatchID;
            public readonly List<EIPPerformanceMeasureSimple> AllEIPPerformanceMeasures;
            public readonly List<IndicatorSubcategorySimple> AllIndicatorSubcategories;
            public readonly List<IndicatorSubcategoryOptionSimple> AllIndicatorSubcategoryOptions;
            public readonly List<int> CalendarYears;
            public readonly int MaxSubcategoryOptions;
            public readonly HashSet<int> EIPPerformanceMeasureActualUpdatesWithValidationWarnings;
            public readonly bool ShowExemptYears;
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularEditor(int projectUpdateBatchID,
                List<EIPPerformanceMeasureSimple> allEIPPerformanceMeasures,
                List<EIPPerformanceMeasureSubcategorySimple> allEIPPerformanceMeasureSubcategories,
                List<IndicatorSubcategorySimple> allIndicatorSubcategories,
                List<IndicatorSubcategoryOptionSimple> allIndicatorSubcategoryOptions,
                List<int> calendarYears,
                bool showExemptYears,
                EIPPerformanceMeasuresValidationResult eipPerformanceMeasuresValidationResult)
            {
                ProjectUpdateBatchID = projectUpdateBatchID;
                AllEIPPerformanceMeasures = allEIPPerformanceMeasures;
                AllIndicatorSubcategories = allIndicatorSubcategories;
                AllIndicatorSubcategoryOptions = allIndicatorSubcategoryOptions;
                CalendarYears = calendarYears;
                ShowExemptYears = showExemptYears;
                EIPPerformanceMeasureActualUpdatesWithValidationWarnings = eipPerformanceMeasuresValidationResult.EIPPerformanceMeasureActualUpdatesWithWarnings;
                ValidationWarnings = eipPerformanceMeasuresValidationResult.GetWarningMessages();
                MaxSubcategoryOptions = allEIPPerformanceMeasureSubcategories.GroupBy(x => x.EIPPerformanceMeasureID).Max(x => x.Count());
            }
        }
    }
}