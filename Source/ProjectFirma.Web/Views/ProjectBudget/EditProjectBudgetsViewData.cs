using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectBudget
{
    public class EditProjectBudgetsViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYearRange;
        public readonly List<ProjectCostTypeSimple> AllProjectCostTypes;
        public readonly List<FundingSourceSimple> AllFundingSources;
        public readonly int ProjectID;
        public readonly IEnumerable<int> ProjectFundingOrganizationFundingSourceIDs;

        public EditProjectBudgetsViewData(Models.Project project, List<FundingSourceSimple> allFundingSources, List<ProjectCostTypeSimple> allProjectCostTypes, IEnumerable<int> projectFundingOrganizationFundingSourceIDs, List<int> calendarYearRange)
        {
            CalendarYearRange = calendarYearRange;
            AllFundingSources = allFundingSources;
            ProjectID = project.ProjectID;
            AllProjectCostTypes = allProjectCostTypes;
            ProjectFundingOrganizationFundingSourceIDs = projectFundingOrganizationFundingSourceIDs;
        }
    }
}