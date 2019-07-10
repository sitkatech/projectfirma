/*-----------------------------------------------------------------------
<copyright file="EditProjectFundingSourceBudgetsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public class EditProjectFundingSourceBudgetViewData : FirmaUserControlViewData
    {
        public int SelectedFundingTypeID { get; }
        public IEnumerable<SelectListItem> FundingTypes { get; }
        public List<FundingSourceSimple> AllFundingSources { get; }
        public List<ProjectSimple> AllProjects { get; }
        public int? ProjectID { get; }
        public int? FundingSourceID { get; }
        public bool FromFundingSource { get; }

        public EditProjectFundingSourceBudgetViewData(ProjectSimple project, int selectedFundingTypeID, 
            IEnumerable<FundingType> fundingTypes,
            List<FundingSourceSimple> allFundingSources)
        {
            SelectedFundingTypeID = selectedFundingTypeID;
            AllProjects = new List<ProjectSimple> {project};
            FundingTypes = fundingTypes.ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            AllFundingSources = allFundingSources;
            ProjectID = project.ProjectID;
            var displayMode = FundingSourceID.HasValue ? EditorDisplayMode.FromFundingSource : EditorDisplayMode.FromProject;
            FromFundingSource = displayMode == EditorDisplayMode.FromFundingSource;
        }

//        public EditProjectFundingSourceBudgetViewData(ProjectSimple project,
//            int selectedFundingTypeID,
//            IEnumerable<FundingType> fundingTypes,
//            List<FundingSourceSimple> allFundingSources)
//            : this(selectedFundingTypeID, fundingTypes, new List <ProjectSimple> { project }, allFundingSources, project.ProjectID, null)
//        {
//        }

//        public EditProjectFundingSourceBudgetViewData(FundingSourceSimple fundingSource,
//            IEnumerable<FundingType> fundingTypes,
//            List<ProjectSimple> allProjects)
//            : this(fundingTypes, allProjects, new List<FundingSourceSimple> {fundingSource}, null, fundingSource.FundingSourceID)
//        {
//        }

        public enum EditorDisplayMode
        {
            FromProject,
            FromFundingSource
        }
    }
}
