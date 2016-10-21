using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.Project
{
    public class ProjectCalendarYearExpenditure
    {
        public Models.Project Project;
        public Dictionary<int, decimal?> CalendarYearExpenditure;

        public ProjectCalendarYearExpenditure(Models.Project project, Dictionary<int, decimal?> calendarYearExpenditure)
        {
            Project = project;
            CalendarYearExpenditure = calendarYearExpenditure;
        }

        public static List<ProjectCalendarYearExpenditure> CreateFromProjectsAndCalendarYears(List<Models.ProjectFundingSourceExpenditure> projectProjectExpenditures, List<int> calendarYears)
        {
            var distinctProjects = projectProjectExpenditures.Select(x => x.Project).Distinct(new HavePrimaryKeyComparer<Models.Project>());
            var projectsCrossJoinCalendarYears =
                distinctProjects.Select(x => new ProjectCalendarYearExpenditure(x, calendarYears.ToDictionary<int, int, decimal?>(calendarYear => calendarYear, calendarYear => null))).ToList();

            foreach (var projectProjectExpenditure in projectProjectExpenditures.GroupBy(x => x.ProjectID))
            {
                var current = projectsCrossJoinCalendarYears.Single(x => x.Project.ProjectID == projectProjectExpenditure.Key);
                foreach (var projectExpenditure in projectProjectExpenditure.Where(projectExpenditure => current.CalendarYearExpenditure.ContainsKey(projectExpenditure.CalendarYear)))
                {
                    current.CalendarYearExpenditure[projectExpenditure.CalendarYear] = projectExpenditure.ExpenditureAmount;
                }
            }
            return projectsCrossJoinCalendarYears.OrderBy(x => x.Project.ProjectNumberString).ToList();
        }
    }
}