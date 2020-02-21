/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasuresViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;
using PerformanceMeasureSubcategoryOptionSimple = ProjectFirma.Web.Models.PerformanceMeasureSubcategoryOptionSimple;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ReportedPerformanceMeasuresViewData : ProjectUpdateViewData
    {
        public string RefreshUrl { get; }
        public PerformanceMeasureReportedValuesSummaryViewData PerformanceMeasureReportedValuesSummaryViewData { get; }
        public ViewDataForAngularEditor ViewDataForAngular { get; }
        public SectionCommentsViewData SectionCommentsViewData { get; }
        public bool IsImplementationStartYearValid { get; }
        public string DiffUrl { get; }
        public string ReportingYearLabel { get; }

        public ReportedPerformanceMeasuresViewData(FirmaSession currentFirmaSession, 
                                                   ProjectUpdateBatch projectUpdateBatch, 
                                                   ViewDataForAngularEditor viewDataForAngularEditor, 
                                                   ProjectUpdateStatus projectUpdateStatus,
                                                   List<PerformanceMeasuresValidationResult> performanceMeasuresValidationResults)
            : base(currentFirmaSession, 
                   projectUpdateBatch, 
                   projectUpdateStatus,
                   PerformanceMeasuresValidationResult.GetAllWarningMessages(performanceMeasuresValidationResults),
                   ProjectUpdateSection.ReportedAccomplishments.ProjectUpdateSectionDisplayName)
        {
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshReportedPerformanceMeasures(projectUpdateBatch.Project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffReportedPerformanceMeasures(projectUpdateBatch.Project));
            var performanceMeasureActualUpdates = projectUpdateBatch.PerformanceMeasureActualUpdates;
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(PerformanceMeasureReportedValue.MakeFromList(performanceMeasureActualUpdates)));
            PerformanceMeasureReportedValuesSummaryViewData = new PerformanceMeasureReportedValuesSummaryViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                projectUpdateBatch.GetPerformanceMeasuresExemptReportingYears().Select(x => x.CalendarYear).ToList(),
                projectUpdateBatch.PerformanceMeasureActualYearsExemptionExplanation,
                performanceMeasureActualUpdates.Select(x => x.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear).Distinct().Select(x => new CalendarYearString(x)).ToList());
            ViewDataForAngular = viewDataForAngularEditor;
            SectionCommentsViewData = new SectionCommentsViewData(projectUpdateBatch.ReportedPerformanceMeasuresComment, projectUpdateBatch.IsReturned());
            IsImplementationStartYearValid = projectUpdateBatch.ProjectUpdate.ImplementationStartYear.HasValue &&
                                             projectUpdateBatch.ProjectUpdate.ImplementationStartYear < projectUpdateBatch.ProjectUpdate.CompletionYear;

            ReportingYearLabel = "Year";
        }

        public class ViewDataForAngularEditor
        {
            public readonly int ProjectUpdateBatchID;
            public readonly List<PerformanceMeasureSimple> AllPerformanceMeasures;
            public readonly List<PerformanceMeasureSubcategorySimple> AllPerformanceMeasureSubcategories;
            public readonly List<PerformanceMeasureSubcategoryOptionSimple> AllPerformanceMeasureSubcategoryOptions;
            public readonly List<CalendarYearString> CalendarYearStrings;
            public readonly int MaxSubcategoryOptions;
            public readonly bool ShowExemptYears;

            public ViewDataForAngularEditor(int projectUpdateBatchID,
                List<PerformanceMeasureSimple> allPerformanceMeasures,
                List<PerformanceMeasureSubcategorySimple> allPerformanceMeasureSubcategories,
                List<PerformanceMeasureSubcategoryOptionSimple> allPerformanceMeasureSubcategoryOptions,
                List<CalendarYearString> calendarYearStrings,
                bool showExemptYears)
            {
                ProjectUpdateBatchID = projectUpdateBatchID;
                AllPerformanceMeasures = allPerformanceMeasures;
                AllPerformanceMeasureSubcategories = allPerformanceMeasureSubcategories;
                AllPerformanceMeasureSubcategoryOptions = allPerformanceMeasureSubcategoryOptions;
                CalendarYearStrings = calendarYearStrings;
                ShowExemptYears = showExemptYears;
                MaxSubcategoryOptions = 0;
                if (allPerformanceMeasureSubcategories.Any())
                {
                    MaxSubcategoryOptions = allPerformanceMeasureSubcategories.GroupBy(x => x.PerformanceMeasureID).Max(x => x.Count());
                }
            }
        }
    }
}
