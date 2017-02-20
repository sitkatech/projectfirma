using System.Collections.Generic;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectBudget
{
    public class EditProjectBudgetsViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYearRange;
        public readonly List<ProjectCostTypeSimple> AllProjectCostTypes;
        public readonly List<FundingSourceSimple> AllFundingSources;
        public readonly int ProjectID;
        public readonly IEnumerable<int> ProjectFundingOrganizationFundingSourceIDs;
        public readonly string FundingSourceUrl;

        public EditProjectBudgetsViewData(Models.Project project, List<FundingSourceSimple> allFundingSources, List<ProjectCostTypeSimple> allProjectCostTypes, IEnumerable<int> projectFundingOrganizationFundingSourceIDs, List<int> calendarYearRange)
        {
            CalendarYearRange = calendarYearRange;
            AllFundingSources = allFundingSources;
            ProjectID = project.ProjectID;
            AllProjectCostTypes = allProjectCostTypes;
            ProjectFundingOrganizationFundingSourceIDs = projectFundingOrganizationFundingSourceIDs;
            FundingSourceUrl = SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Index());
        }

        
    }
}