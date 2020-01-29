using ProjectFirmaModels.Models;
using System.Collections.Generic;

namespace ProjectFirma.Api.Models
{
    public class ProjectCalendarYearExpendituresDto
    {
        public ProjectCalendarYearExpendituresDto(Project project, Dictionary<int, decimal?> calendarYearExpenditures)
        {
            ProjectDto = new ProjectDto(project);
            CalendarYearExpenditures = calendarYearExpenditures;
        }

        public ProjectCalendarYearExpendituresDto()
        {
        }

        public ProjectDto ProjectDto { get; set; }
        public Dictionary<int, decimal?> CalendarYearExpenditures { get; set; }
    }
}