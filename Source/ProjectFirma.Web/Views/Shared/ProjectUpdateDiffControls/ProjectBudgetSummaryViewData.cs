using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectUpdateDiffControls
{
    public class ProjectBudgetSummaryViewData : FirmaUserControlViewData
    {
        public readonly List<CalendarYearString> CalendarYears;
        public readonly List<ProjectBudgetAmount2> ProjectBudgetAmounts;
        public readonly List<ProjectCostType> ProjectCostTypes;

        public ProjectBudgetSummaryViewData(List<ProjectBudgetAmount2> projectBudgetAmounts, List<CalendarYearString> calendarYears)
        {
            ProjectCostTypes = ProjectCostType.All.ToList();
            ProjectBudgetAmounts = projectBudgetAmounts;
            CalendarYears = calendarYears;
        }
    }
}