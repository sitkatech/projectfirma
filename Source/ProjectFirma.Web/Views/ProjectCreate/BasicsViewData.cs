/*-----------------------------------------------------------------------
<copyright file="BasicsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class BasicsViewData : ProjectCreateViewData
    {
        public IEnumerable<SelectListItem> TaxonomyTierOnes { get; private set; }
        public IEnumerable<SelectListItem> FundingTypes { get; private set; }
        public IEnumerable<SelectListItem> StartYearRange { get; private set; }
        public IEnumerable<SelectListItem> CompletionYearRange { get; private set; }
        public bool HasCanStewardProjectsOrganizationRelationship { get; private set; }
        public bool HasThreeTierTaxonomy { get; private set; }
        public bool ShowProjectStageDropDown { get; private set; }
        private string ProjectDisplayName { get; set; }

        // todo: put correct value in if this is relevant, otherwise rip it out. 
        public bool IsEditable = true;

        public IEnumerable<SelectListItem> ProjectStages = ProjectStage.All.Except(new List<ProjectStage>{ProjectStage.Proposal}).OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);


        public BasicsViewData(Person currentPerson,
            IEnumerable<FundingType> fundingTypes,
            IEnumerable<Models.TaxonomyTierOne> taxonomyTierOnes, 
            bool showProjectStageDropDown,
            string instructionsPageUrl)
            : base(currentPerson, ProjectCreateSection.Basics, instructionsPageUrl)
        {
            // This constructor is only used for the case where we're coming from the instructions, so we hide the dropdown if they clicked the button for proposing a new project.
            ShowProjectStageDropDown = showProjectStageDropDown;
            AssignParameters(taxonomyTierOnes, fundingTypes);
        }

        public BasicsViewData(Person currentPerson,
            Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            IEnumerable<Models.TaxonomyTierOne> taxonomyTierOnes,
            IEnumerable<FundingType> fundingTypes)
            : base(currentPerson, project, ProjectCreateSection.Basics, proposalSectionsStatus)
        {
            ShowProjectStageDropDown = project.ProjectStage != ProjectStage.Proposal;
            ProjectDisplayName = project.DisplayName;
            AssignParameters(taxonomyTierOnes, fundingTypes);
        }

        private void AssignParameters(IEnumerable<Models.TaxonomyTierOne> taxonomyTierOnes, IEnumerable<FundingType> fundingTypes)
        {
            TaxonomyTierOnes = taxonomyTierOnes.ToList().OrderBy(ap => ap.DisplayName).ToList().ToGroupedSelectList();
            
            FundingTypes = fundingTypes.ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.GetFundingTypeDisplayName());
            StartYearRange =
                FirmaDateUtilities.GetRangeOfYears(FirmaDateUtilities.MinimumYear, DateTime.Now.Year + FirmaDateUtilities.YearsBeyondPresentForMaximumYearForUserInput)
                    .ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            CompletionYearRange = FirmaDateUtilities.GetRangeOfYears(FirmaDateUtilities.MinimumYear, DateTime.Now.Year + FirmaDateUtilities.YearsBeyondPresentForMaximumYearForUserInput)
                    .ToSelectListWithEmptyFirstRow(x => x.ToString(CultureInfo.InvariantCulture));
            HasCanStewardProjectsOrganizationRelationship = MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship();

            HasThreeTierTaxonomy = MultiTenantHelpers.GetNumberOfTaxonomyTiers() == 3;

            var pagetitle = ShowProjectStageDropDown ? "Add Project" : "Propose Project";
            PageTitle = $"{pagetitle}";
            if (ProjectDisplayName != null)
            {
                PageTitle += $": {ProjectDisplayName}";
            }
        }
    }
}
