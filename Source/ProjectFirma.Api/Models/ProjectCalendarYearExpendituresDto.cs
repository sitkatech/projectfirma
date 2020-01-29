using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class ProjectCalendarYearExpendituresDto
    {
        public ProjectCalendarYearExpendituresDto(Project project, Dictionary<int, decimal?> calendarYearExpenditureses)
        {
            ProjectDto = new ProjectDto(project);
            CalendarYearExpenditures = calendarYearExpenditureses;
        }

        public ProjectCalendarYearExpendituresDto()
        {
        }

        public ProjectDto ProjectDto { get; set; }
        public Dictionary<int, decimal?> CalendarYearExpenditures { get; set; }
    }
}