/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceExpendituresViewData.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
