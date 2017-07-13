/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewModel.cs" company="Tahoe Regional Planning Agency">
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

        public EditOrganizationsViewModel(List<Models.ProjectOrganization> projectOrganizations, Models.Project project)
        {
            var projectOrganizationJsons = projectOrganizations.GroupBy(po => po.Organization).Select(o => new ProjectOrganizationsViewModelJson.ProjectOrganizationJson(o.Key, o.ToList())).ToList();

            var leadOrganization = project.LeadImplementerOrganization;
            var leadOrganizationID = leadOrganization?.OrganizationID;

            ProjectOrganizationsViewModelJson = new ProjectOrganizationsViewModelJson(leadOrganizationID, projectOrganizationJsons);
        }

        public void UpdateModel(Models.Project project, ICollection<Models.ProjectOrganization> allProjectOrganizations)
        {            
            Check.Require(ProjectOrganizationsViewModelJson.ProjectOrganizations.Count > 0, "Need to have at least the lead implementer set.");
            Check.Require(ProjectOrganizationsViewModelJson.ProjectOrganizations.Count == ProjectOrganizationsViewModelJson.ProjectOrganizations.Select(x => x.OrganizationID).Distinct().Count(),
                "Cannot have the same organization listed multiple times.");

            project.LeadImplementerOrganizationID = ProjectOrganizationsViewModelJson.LeadOrganizationID;

            var projectOrganizationViewModelJsons =
                ProjectOrganizationsViewModelJson.ProjectOrganizations.ToList();

            var projectOrganizationsUpdated = projectOrganizationViewModelJsons.SelectMany(
                    orgBeingAdded =>
                    {
                        var projectOrgsToAdd = new List<Models.ProjectOrganization>();
                        foreach (var relationshipType in orgBeingAdded.RelationshipTypes)
                        {
                            projectOrgsToAdd.Add(new Models.ProjectOrganization(project.ProjectID, orgBeingAdded.OrganizationID, relationshipType.RelationshipTypeID));
                        }
                        return projectOrgsToAdd;
                    }).ToList();

            project.ProjectOrganizations.Merge(projectOrganizationsUpdated,
                allProjectOrganizations,
                (x, y) => x.ProjectID == y.ProjectID && x.OrganizationID == y.OrganizationID && x.RelationshipTypeID == y.RelationshipTypeID);
        }
    }
}
