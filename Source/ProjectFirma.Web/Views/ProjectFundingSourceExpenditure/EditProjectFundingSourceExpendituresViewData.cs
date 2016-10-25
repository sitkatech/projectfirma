using System.Collections.Generic;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectFundingSourceExpenditure
{
    public class EditProjectFundingSourceExpendituresViewData : FirmaUserControlViewData
    {
        public readonly List<int> CalendarYearRange;
        public readonly List<FundingSourceSimple> AllFundingSources;
        public readonly List<ProjectSimple> AllProjects;
        public readonly int? ProjectID;
        public readonly int? FundingSourceID;
        public readonly IEnumerable<int> ProjectFundingOrganizationFundingSourceIDs;
        public readonly bool FromFundingSource;

        private EditProjectFundingSourceExpendituresViewData(List<ProjectSimple> allProjects,
            List<FundingSourceSimple> allFundingSources,
            int? projectID,
            int? fundingSourceID,
            IEnumerable<int> projectFundingOrganizationFundingSourceIDs,
            List<int> calendarYearRange)
        {
            CalendarYearRange = calendarYearRange;
            AllFundingSources = allFundingSources;
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            AllProjects = allProjects;
            ProjectFundingOrganizationFundingSourceIDs = projectFundingOrganizationFundingSourceIDs;
            var displayMode = FundingSourceID.HasValue ? EditorDisplayMode.FromFundingSource : EditorDisplayMode.FromProject;
            FromFundingSource = displayMode == EditorDisplayMode.FromFundingSource;
        }

        public EditProjectFundingSourceExpendituresViewData(ProjectSimple project,
            List<FundingSourceSimple> allFundingSources,
            IEnumerable<int> projectFundingOrganizationFundingSourceIDs,
            List<int> calendarYearRangeForExpenditures)
            : this(new List<ProjectSimple> { project }, allFundingSources, project.ProjectID, null, projectFundingOrganizationFundingSourceIDs, calendarYearRangeForExpenditures)
        {
        }

        public EditProjectFundingSourceExpendituresViewData(FundingSourceSimple fundingSource, List<ProjectSimple> allProjects, List<int> calendarYearRange)
            : this(allProjects, new List<FundingSourceSimple> {fundingSource}, null, fundingSource.FundingSourceID, new List<int>(), calendarYearRange)
        {
        }

        public enum EditorDisplayMode
        {
            FromProject,
            FromFundingSource
        }
    }
}