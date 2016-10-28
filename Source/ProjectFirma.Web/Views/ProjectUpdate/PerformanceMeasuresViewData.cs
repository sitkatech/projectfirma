using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class PerformanceMeasuresViewData : ProjectUpdateViewData
    {
        public readonly string RefreshUrl;
        public readonly PerformanceMeasureReportedValuesSummaryViewData PerformanceMeasureReportedValuesSummaryViewData;
        public readonly ViewDataForAngularEditor ViewDataForAngular;
        public readonly SectionCommentsViewData SectionCommentsViewData;
        public readonly bool IsImplementationStartYearValid;
        public readonly string DiffUrl;

        public PerformanceMeasuresViewData(Person currentPerson, ProjectUpdateBatch projectUpdateBatch, ViewDataForAngularEditor viewDataForAngularEditor, UpdateStatus updateStatus)
            : base(currentPerson, projectUpdateBatch, ProjectUpdateSectionEnum.PerformanceMeasures, updateStatus)
        {
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshPerformanceMeasures(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffPerformanceMeasures(projectUpdateBatch.Project));
            var performanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates;
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(performanceMeasureActualUpdates));
            PerformanceMeasureReportedValuesSummaryViewData = new PerformanceMeasureReportedValuesSummaryViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                projectUpdateBatch.ProjectExemptReportingYearUpdates.Select(x => x.CalendarYear).ToList(),
                projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation,
                performanceMeasureActualUpdates.Select(x => x.CalendarYear).Distinct().Select(x => new CalendarYearString(x)).ToList());
            ViewDataForAngular = viewDataForAngularEditor;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.PerformanceMeasuresComment, projectUpdateBatch.IsReturned);
            IsImplementationStartYearValid = projectUpdateBatch.ProjectUpdate.ImplementationStartYear.HasValue &&
                                             projectUpdateBatch.ProjectUpdate.ImplementationStartYear < projectUpdateBatch.ProjectUpdate.CompletionYear;
        }

        public class ViewDataForAngularEditor
        {
            public readonly int ProjectUpdateBatchID;
            public readonly List<PerformanceMeasureSimple> AllPerformanceMeasures;
            public readonly List<IndicatorSubcategorySimple> AllIndicatorSubcategories;
            public readonly List<IndicatorSubcategoryOptionSimple> AllIndicatorSubcategoryOptions;
            public readonly List<int> CalendarYears;
            public readonly int MaxSubcategoryOptions;
            public readonly HashSet<int> PerformanceMeasureActualUpdatesWithValidationWarnings;
            public readonly bool ShowExemptYears;
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularEditor(int projectUpdateBatchID,
                List<PerformanceMeasureSimple> allPerformanceMeasures,
                List<PerformanceMeasureSubcategorySimple> allPerformanceMeasureSubcategories,
                List<IndicatorSubcategorySimple> allIndicatorSubcategories,
                List<IndicatorSubcategoryOptionSimple> allIndicatorSubcategoryOptions,
                List<int> calendarYears,
                bool showExemptYears,
                PerformanceMeasuresValidationResult performanceMeasuresValidationResult)
            {
                ProjectUpdateBatchID = projectUpdateBatchID;
                AllPerformanceMeasures = allPerformanceMeasures;
                AllIndicatorSubcategories = allIndicatorSubcategories;
                AllIndicatorSubcategoryOptions = allIndicatorSubcategoryOptions;
                CalendarYears = calendarYears;
                ShowExemptYears = showExemptYears;
                PerformanceMeasureActualUpdatesWithValidationWarnings = performanceMeasuresValidationResult.PerformanceMeasureActualUpdatesWithWarnings;
                ValidationWarnings = performanceMeasuresValidationResult.GetWarningMessages();
                MaxSubcategoryOptions = allPerformanceMeasureSubcategories.GroupBy(x => x.PerformanceMeasureID).Max(x => x.Count());
            }
        }
    }
}