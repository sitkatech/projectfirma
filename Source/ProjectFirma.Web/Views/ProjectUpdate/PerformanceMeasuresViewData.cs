/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresViewData.cs" company="Tahoe Regional Planning Agency">
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
            public readonly List<PerformanceMeasureSubcategorySimple> AllPerformanceMeasureSubcategories;
            public readonly List<PerformanceMeasureSubcategoryOptionSimple> AllPerformanceMeasureSubcategoryOptions;
            public readonly List<int> CalendarYears;
            public readonly int MaxSubcategoryOptions;
            public readonly HashSet<int> PerformanceMeasureActualUpdatesWithValidationWarnings;
            public readonly bool ShowExemptYears;
            public readonly List<string> ValidationWarnings;

            public ViewDataForAngularEditor(int projectUpdateBatchID,
                List<PerformanceMeasureSimple> allPerformanceMeasures,
                List<PerformanceMeasureSubcategorySimple> allPerformanceMeasureSubcategories,
                List<PerformanceMeasureSubcategoryOptionSimple> allPerformanceMeasureSubcategoryOptions,
                List<int> calendarYears,
                bool showExemptYears,
                PerformanceMeasuresValidationResult performanceMeasuresValidationResult)
            {
                ProjectUpdateBatchID = projectUpdateBatchID;
                AllPerformanceMeasures = allPerformanceMeasures;
                AllPerformanceMeasureSubcategories = allPerformanceMeasureSubcategories;
                AllPerformanceMeasureSubcategoryOptions = allPerformanceMeasureSubcategoryOptions;
                CalendarYears = calendarYears;
                ShowExemptYears = showExemptYears;
                PerformanceMeasureActualUpdatesWithValidationWarnings = performanceMeasuresValidationResult.PerformanceMeasureActualUpdatesWithWarnings;
                ValidationWarnings = performanceMeasuresValidationResult.GetWarningMessages();
                MaxSubcategoryOptions = allPerformanceMeasureSubcategories.GroupBy(x => x.PerformanceMeasureID).Max(x => x.Count());
            }
        }
    }
}
