using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ExpenditureAndBudgetControls
{
    public class ProjectBudgetSummaryViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYears;
        public readonly List<ProjectBudgetAmount> ProjectBudgetAmounts;

        public ProjectBudgetSummaryViewData(List<ProjectBudgetAmount> projectBudgetAmounts, List<int> calendarYears)
        {
            ProjectBudgetAmounts = projectBudgetAmounts;
            CalendarYears = calendarYears;
        }
    }
}