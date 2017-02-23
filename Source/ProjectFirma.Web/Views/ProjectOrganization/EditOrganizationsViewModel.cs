/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModel.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using System.Linq;
using ProjectFirma.Web.Models;
using FluentValidation.Attributes;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    [Validator(typeof(EditOrganizationsViewModelValidator))]
    public class EditOrganizationsViewModel : FormViewModel
    {
        public ProjectOrganizationsViewModelJson ProjectOrganizationsViewModelJson { get; set; }

        /// <summary>
        /// Needed by Model Binder
        /// </summary>
        public EditOrganizationsViewModel()
        {
        }

        public EditOrganizationsViewModel(List<ProjectImplementingOrganizationOrProjectFundingOrganization> projectOrganizations)
        {
            var projectOrganizationJsons = projectOrganizations.OrderBy(po => po.Organization.DisplayName).Select(po => new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(po)).ToList();
            var projectImplementingOrganizationOrProjectFundingOrganization = projectOrganizations.SingleOrDefault(po => po.IsLeadOrganization);
            var leadOrganization = projectImplementingOrganizationOrProjectFundingOrganization != null ? projectImplementingOrganizationOrProjectFundingOrganization.Organization : null;
            var leadOrganizationID = leadOrganization != null ? leadOrganization.OrganizationID : (int?) null;
            ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(leadOrganizationID, projectOrganizationJsons);
        }

        public void UpdateModel(Models.Project project,
            ICollection<ProjectFundingOrganization> allProjectFundingOrganizations,
            ICollection<ProjectImplementingOrganization> allProjectImplementingOrganizations)
        {
            Check.Require(ProjectOrganizationsViewModelJson.ProjectOrganizations.Count > 0, "Need to have at least the lead implementer set.");
            Check.Require(ProjectOrganizationsViewModelJson.ProjectOrganizations.Count == ProjectOrganizationsViewModelJson.ProjectOrganizations.Select(x => x.OrganizationID).Distinct().Count(),
                "Cannot have the same organization listed multiple times.");

            // we need to also include when the lead implementer is selected but not checked as an implementer
            var projectImplementingOrganizationViewModelJsons =
                ProjectOrganizationsViewModelJson.ProjectOrganizations.Where(x => x.IsImplementingOrganization || ProjectOrganizationsViewModelJson.LeadOrganizationID == x.OrganizationID).ToList();
            var projectImplementingOrganizationsUpdated =
                projectImplementingOrganizationViewModelJsons.Select(
                    orgBeingAdded =>
                        new ProjectImplementingOrganization(project.ProjectID, orgBeingAdded.OrganizationID, ProjectOrganizationsViewModelJson.LeadOrganizationID == orgBeingAdded.OrganizationID))
                    .ToList();
            project.ProjectImplementingOrganizations.Merge(projectImplementingOrganizationsUpdated,
                allProjectImplementingOrganizations,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID,
                (x, y) => x.IsLeadOrganization = y.IsLeadOrganization);

            // funding orgs
            var projectFundingOrganizationViewModelJsons = ProjectOrganizationsViewModelJson.ProjectOrganizations.Where(x => x.IsFundingOrganization).ToList();
            var projectFundingOrganizationsUpdated =
                projectFundingOrganizationViewModelJsons.Select(orgBeingAdded => new ProjectFundingOrganization(project.ProjectID, orgBeingAdded.OrganizationID)).ToList();
            project.ProjectFundingOrganizations.Merge(projectFundingOrganizationsUpdated, allProjectFundingOrganizations, (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID);
        }
    }
}
