using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.TransportationProjectBudget
{
    public class EditTransportationProjectBudgetsViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<int> CalendarYearRange;
        public readonly List<TransportationProjectCostTypeSimple> AllTransportationProjectCostTypes;
        public readonly List<FundingSourceSimple> AllFundingSources;
        public readonly int ProjectID;
        public readonly IEnumerable<int> ProjectFundingOrganizationFundingSourceIDs;

        public EditTransportationProjectBudgetsViewData(Models.Project project, List<FundingSourceSimple> allFundingSources, List<TransportationProjectCostTypeSimple> allTransportationProjectCostTypes, IEnumerable<int> projectFundingOrganizationFundingSourceIDs, List<int> calendarYearRange)
        {
            CalendarYearRange = calendarYearRange;
            AllFundingSources = allFundingSources;
            ProjectID = project.ProjectID;
            AllTransportationProjectCostTypes = allTransportationProjectCostTypes;
            ProjectFundingOrganizationFundingSourceIDs = projectFundingOrganizationFundingSourceIDs;
        }
    }
}