using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectBudgetDetailViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYears;
        public readonly List<ProjectBudgetAmount> ProjectBudgetAmounts;

        public ProjectBudgetDetailViewData(List<ProjectBudgetAmount> projectBudgetAmounts, List<int> calendarYears)
        {
            ProjectBudgetAmounts = projectBudgetAmounts;
            CalendarYears = calendarYears;
        }
    }
}