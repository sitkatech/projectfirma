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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Views.Shared.PerformanceMeasureControls;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class PerformanceMeasuresViewData : ProjectCreateViewData
    {
        public readonly string RefreshUrl;
        public readonly PerformanceMeasureReportedValuesSummaryViewData PerformanceMeasureReportedValuesSummaryViewData;
        public readonly ViewDataForAngularEditor ViewDataForAngular;
        
        public readonly bool IsImplementationStartYearValid;
        public readonly string DiffUrl;

        public PerformanceMeasuresViewData(Person currentPerson, Models.Project project, ViewDataForAngularEditor viewDataForAngularEditor, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentPerson, project, ProjectCreateSection.ReportedPerformanceMeasures, proposalSectionsStatus)
        {
            RefreshUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.RefreshPerformanceMeasures(project));
            DiffUrl = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(x => x.DiffPerformanceMeasures(project));
            var performanceMeasureActuals = project.GetReportedPerformanceMeasures();
            var performanceMeasureSubcategoriesCalendarYearReportedValues =
                PerformanceMeasureSubcategoriesCalendarYearReportedValue.CreateFromPerformanceMeasuresAndCalendarYears(new List<IPerformanceMeasureReportedValue>(performanceMeasureActuals));
            PerformanceMeasureReportedValuesSummaryViewData = new PerformanceMeasureReportedValuesSummaryViewData(performanceMeasureSubcategoriesCalendarYearReportedValues,
                project.ProjectExemptReportingYears.Select(x => x.CalendarYear).ToList(),
                project.PerformanceMeasureActualYearsExemptionExplanation,
                performanceMeasureActuals.Select(x => x.CalendarYear).Distinct().Select(x => new CalendarYearString(x)).ToList());
            ViewDataForAngular = viewDataForAngularEditor;
            
            IsImplementationStartYearValid = project.ImplementationStartYear.HasValue &&
                                             project.ImplementationStartYear < project.CompletionYear;
        }

        public class ViewDataForAngularEditor
        {
            public readonly int ProjectID;
            public readonly List<PerformanceMeasureSimple> AllPerformanceMeasures;
            public readonly List<PerformanceMeasureSubcategorySimple> AllPerformanceMeasureSubcategories;
            public readonly List<PerformanceMeasureSubcategoryOptionSimple> AllPerformanceMeasureSubcategoryOptions;
            public readonly List<int> CalendarYears;
            public readonly int MaxSubcategoryOptions;
            public readonly bool ShowExemptYears;

            public ViewDataForAngularEditor(int projectBatchID,
                List<PerformanceMeasureSimple> allPerformanceMeasures,
                List<PerformanceMeasureSubcategorySimple> allPerformanceMeasureSubcategories,
                List<PerformanceMeasureSubcategoryOptionSimple> allPerformanceMeasureSubcategoryOptions,
                List<int> calendarYears,
                bool showExemptYears)
            {
                ProjectID = projectBatchID;
                AllPerformanceMeasures = allPerformanceMeasures;
                AllPerformanceMeasureSubcategories = allPerformanceMeasureSubcategories;
                AllPerformanceMeasureSubcategoryOptions = allPerformanceMeasureSubcategoryOptions;
                CalendarYears = calendarYears;
                ShowExemptYears = showExemptYears;
                MaxSubcategoryOptions = allPerformanceMeasureSubcategories.GroupBy(x => x.PerformanceMeasureID).Max(x => x.Count());
            }
        }
    }
}
