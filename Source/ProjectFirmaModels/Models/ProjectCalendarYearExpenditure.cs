/*-----------------------------------------------------------------------
<copyright file="ProjectCalendarYearExpenditure.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ProjectCalendarYearExpenditure
    {
        public Project Project;
        public Dictionary<int, decimal?> CalendarYearExpenditure;

        public ProjectCalendarYearExpenditure(Project project, Dictionary<int, decimal?> calendarYearExpenditure)
        {
            Project = project;
            CalendarYearExpenditure = calendarYearExpenditure;
        }

        public static List<ProjectCalendarYearExpenditure> CreateFromProjectsAndCalendarYears(List<ProjectFundingSourceExpenditure> projectProjectExpenditures, List<int> calendarYears)
        {
            var distinctProjects = projectProjectExpenditures.Select(x => x.Project).Distinct(new HavePrimaryKeyComparer<Project>());
            var projectsCrossJoinCalendarYears =
                distinctProjects.Select(x => new ProjectCalendarYearExpenditure(x, calendarYears.ToDictionary<int, int, decimal?>(calendarYear => calendarYear, calendarYear => null))).ToList();

            foreach (var projectProjectExpenditure in projectProjectExpenditures.GroupBy(x => x.ProjectID))
            {
                var current = projectsCrossJoinCalendarYears.Single(x => x.Project.ProjectID == projectProjectExpenditure.Key);
                foreach (var projectExpenditure in projectProjectExpenditure.Where(projectExpenditure => current.CalendarYearExpenditure.ContainsKey(projectExpenditure.CalendarYear)))
                {
                    current.CalendarYearExpenditure[projectExpenditure.CalendarYear] = (current.CalendarYearExpenditure[projectExpenditure.CalendarYear] ?? 0) + projectExpenditure.ExpenditureAmount;
                }
            }
            return projectsCrossJoinCalendarYears.OrderBy(x => x.Project.ProjectID).ToList();
        }
    }
}
