using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectBudget
{
    public class EditProjectBudgetsViewModel : FormViewModel
    {
        public List<ProjectBudgetBulk> ProjectBudgets { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditProjectBudgetsViewModel()
        {
        }

        public EditProjectBudgetsViewModel(List<Models.ProjectBudget> projectBudgets, List<int> calendarYearsToPopulate)
        {
            ProjectBudgets = ProjectBudgetBulk.MakeFromList(new List<IProjectBudgetAmount>(projectBudgets), calendarYearsToPopulate);
        }

        public void UpdateModel(List<Models.ProjectBudget> currentProjectBudgets, IList<Models.ProjectBudget> allProjectBudgets)
        {
            var projectBudgetsUpdated = new List<Models.ProjectBudget>();
            if (ProjectBudgets != null)
            {
                // Completely rebuild the list
                projectBudgetsUpdated = ProjectBudgets.SelectMany(x => x.ToProjectBudgets()).ToList();
            }

            currentProjectBudgets.Merge(projectBudgetsUpdated,
                allProjectBudgets,
                (x, y) =>
                    x.ProjectID == y.ProjectID && x.FundingSourceID == y.FundingSourceID && x.CalendarYear == y.CalendarYear && x.ProjectCostTypeID == y.ProjectCostTypeID,
                (x, y) => x.BudgetedAmount = y.BudgetedAmount);
        }
    }
}