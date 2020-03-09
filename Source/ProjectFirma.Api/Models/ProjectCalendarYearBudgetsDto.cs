using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Api.Models
{
    public class ProjectCalendarYearBudgetsDto
    {
        public ProjectCalendarYearBudgetsDto(Project project, Dictionary<int, decimal?> calendarYearBudgets)
        {
            ProjectDto = new ProjectDto(project);
            CalendarYearBudgets = calendarYearBudgets;
        }

        public ProjectCalendarYearBudgetsDto()
        {
        }

        public ProjectDto ProjectDto { get; set; }
        public Dictionary<int, decimal?> CalendarYearBudgets { get; set; }
    }
}