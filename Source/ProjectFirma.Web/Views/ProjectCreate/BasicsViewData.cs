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
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class BasicsViewData : ProjectCreateViewData
    {
        public IEnumerable<SelectListItem> TaxonomyLeafs { get; private set; }
        public IEnumerable<SelectListItem> FundingTypes { get; private set; }
        public IEnumerable<SelectListItem> StartYearRange { get; private set; }
        public IEnumerable<SelectListItem> CompletionYearRange { get; private set; }
        public bool HasCanStewardProjectsOrganizationRelationship { get; private set; }
        public bool HasThreeTierTaxonomy { get; private set; }
        public bool ShowProjectStageDropDown { get; }
        public IEnumerable<ProjectFirmaModels.Models.ProjectCustomAttributeType> ProjectCustomAttributeTypes { get; private set; }
        private string ProjectDisplayName { get; }
        public TenantAttribute TenantAttribute { get; private set; }
        public bool ShowCommentsSection { get; }
        public bool CanEditComments { get; }

        public bool IsEditable = true;

        public IEnumerable<SelectListItem> ProjectStages = ProjectStage.All.Except(new List<ProjectStage>{ProjectStage.Proposal}).OrderBy(x => x.SortOrder).ToSelectListWithEmptyFirstRow(x => x.ProjectStageID.ToString(CultureInfo.InvariantCulture), y => y.ProjectStageDisplayName);

        public BasicsViewData(FirmaSession currentFirmaSession, IEnumerable<FundingType> fundingTypes,
            IEnumerable<ProjectFirmaModels.Models.TaxonomyLeaf> taxonomyLeafs, bool showProjectStageDropDown, string instructionsPageUrl,
            TenantAttribute tenantAttribute)
            : base(currentFirmaSession, ProjectCreateSection.Basics.ProjectCreateSectionDisplayName, instructionsPageUrl)
        {
            // This constructor is only used for the case where we're coming from the instructions, so we hide the dropdown if they clicked the button for proposing a new project.
            ShowProjectStageDropDown = showProjectStageDropDown;
            AssignParameters(taxonomyLeafs, fundingTypes, tenantAttribute);
        }

        public BasicsViewData(FirmaSession currentFirmaSession,
            ProjectFirmaModels.Models.Project project,
            ProposalSectionsStatus proposalSectionsStatus,
            IEnumerable<ProjectFirmaModels.Models.TaxonomyLeaf> taxonomyLeafs,
            IEnumerable<FundingType> fundingTypes,
            TenantAttribute tenantAttribute)
            : base(currentFirmaSession, project, ProjectCreateSection.Basics.ProjectCreateSectionDisplayName, proposalSectionsStatus)
        {
            ShowCommentsSection = project.IsPendingApproval() || (project.BasicsComment != string.Empty &&
                           project.ProjectApprovalStatus == ProjectApprovalStatus.Returned);
            CanEditComments = project.IsPendingApproval() && new ProjectEditAsAdminRegardlessOfStageFeature().HasPermission(currentFirmaSession, project).HasPermission;
            ShowProjectStageDropDown = project.ProjectStage != ProjectStage.Proposal;
            ProjectDisplayName = project.GetDisplayName();
            AssignParameters(taxonomyLeafs, fundingTypes, tenantAttribute);
        }

        private void AssignParameters(IEnumerable<ProjectFirmaModels.Models.TaxonomyLeaf> taxonomyLeafs,
            IEnumerable<FundingType> fundingTypes,
            TenantAttribute tenantAttribute)
        {
            TaxonomyLeafs = taxonomyLeafs.ToList().OrderTaxonomyLeaves().ToList().ToGroupedSelectList();
            
            FundingTypes = fundingTypes.ToSelectList(x => x.FundingTypeID.ToString(CultureInfo.InvariantCulture), y => y.FundingTypeDisplayName);
            StartYearRange =
                FirmaDateUtilities.YearsForUserInput()
                    .ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            CompletionYearRange = FirmaDateUtilities.YearsForUserInput().ToSelectListWithEmptyFirstRow(x => x.CalendarYear.ToString(CultureInfo.InvariantCulture), x => x.CalendarYearDisplay);
            HasCanStewardProjectsOrganizationRelationship = MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship();

            HasThreeTierTaxonomy = MultiTenantHelpers.IsTaxonomyLevelTrunk();

            var pagetitle = ShowProjectStageDropDown ? $"Add {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}" : $"Propose {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}";
            PageTitle = $"{pagetitle}";
            if (ProjectDisplayName != null)
            {
                PageTitle += $": {ProjectDisplayName}";
            }

            TenantAttribute = tenantAttribute;
        }
    }
}
