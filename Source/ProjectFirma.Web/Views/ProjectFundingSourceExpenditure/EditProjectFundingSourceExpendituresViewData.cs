/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceExpendituresViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.ProjectFundingSourceExpenditure
{
    public class EditProjectFundingSourceExpendituresViewData : FirmaUserControlViewData
    {
        public List<int> CalendarYearRange { get; }
        public List<FundingSourceSimple> AllFundingSources { get; }
        public List<ProjectSimple> AllProjects { get; }
        public int? ProjectID { get; }
        public int? FundingSourceID { get; }
        public bool FromFundingSource { get; }
        public bool UseFiscalYears { get; }

        private EditProjectFundingSourceExpendituresViewData(List<ProjectSimple> allProjects, List<FundingSourceSimple> allFundingSources, int? projectID, int? fundingSourceID, List<int> calendarYearRange)
        {
            CalendarYearRange = calendarYearRange;
            AllFundingSources = allFundingSources;
            ProjectID = projectID;
            FundingSourceID = fundingSourceID;
            AllProjects = allProjects;
            var displayMode = FundingSourceID.HasValue ? EditorDisplayMode.FromFundingSource : EditorDisplayMode.FromProject;
            FromFundingSource = displayMode == EditorDisplayMode.FromFundingSource;
            UseFiscalYears = MultiTenantHelpers.UseFiscalYears();
        }

        public EditProjectFundingSourceExpendituresViewData(ProjectSimple project, List<FundingSourceSimple> allFundingSources, List<int> calendarYearRangeForExpenditures)
            : this(new List<ProjectSimple> { project }, allFundingSources, project.ProjectID, null, calendarYearRangeForExpenditures)
        {
        }

        public EditProjectFundingSourceExpendituresViewData(FundingSourceSimple fundingSource, List<ProjectSimple> allProjects, List<int> calendarYearRange)
            : this(allProjects, new List<FundingSourceSimple> {fundingSource}, null, fundingSource.FundingSourceID, calendarYearRange)
        {
        }

        public enum EditorDisplayMode
        {
            FromProject,
            FromFundingSource
        }
    }
}
