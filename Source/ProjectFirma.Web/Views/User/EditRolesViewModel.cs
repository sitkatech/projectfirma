/*-----------------------------------------------------------------------
<copyright file="EditRolesViewModel.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ProjectFirmaModels.Models;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.User
{
    public class EditRolesViewModel : FormViewModel
    {
        [Required] public int PersonID { get; set; }

        [Required] [DisplayName("Role")] public int? RoleID { get; set; }

        [Required] [DisplayName("Organization")] public int? OrganizationID { get; set; }

        [Required]
        [DisplayName("Should Receive Support Emails?")]
        public bool ShouldReceiveSupportEmails { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditRolesViewModel()
        {
        }

        public EditRolesViewModel(Person person)
        {
            PersonID = person.PersonID;
            RoleID = person.RoleID;
            OrganizationID = person.OrganizationID;
            ShouldReceiveSupportEmails = person.ReceiveSupportEmails;
        }

        public void UpdateModel(Person personBeingEdited, FirmaSession currentFirmaSession)
        {
            var downgradingFromSteward = personBeingEdited.Role == ProjectFirmaModels.Models.Role.ProjectSteward &&
                                         RoleID != ProjectFirmaModels.Models.Role.ProjectSteward.RoleID &&
                                         RoleID != ProjectFirmaModels.Models.Role.Admin.RoleID &&
                                         RoleID != ProjectFirmaModels.Models.Role.ESAAdmin.RoleID;

            personBeingEdited.RoleID = RoleID ?? ModelObjectHelpers.NotYetAssignedID;
            personBeingEdited.ReceiveSupportEmails = ShouldReceiveSupportEmails;
            var unknownOrganizationId = HttpRequestStorage.DatabaseEntities.Organizations.GetUnknownOrganization().OrganizationID;
            personBeingEdited.OrganizationID = OrganizationID ?? unknownOrganizationId;

            if (ModelObjectHelpers.IsRealPrimaryKeyValue(personBeingEdited.PersonID))
            {
                personBeingEdited.UpdateDate = DateTime.Now; // Existing person
            }
            else
            {
                personBeingEdited.CreateDate = DateTime.Now; // New person
            }

            if (downgradingFromSteward)
            {
                var personPersonStewardGeospatialAreas = personBeingEdited.PersonStewardGeospatialAreas.ToList();
                foreach (var personStewardGeospatialArea in personPersonStewardGeospatialAreas)
                {
                    personStewardGeospatialArea.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }

                var personPersonStewardTaxonomyBranches = personBeingEdited.PersonStewardTaxonomyBranches.ToList();
                foreach (var personStewardTaxonomyBranch in personPersonStewardTaxonomyBranches)
                {
                    personStewardTaxonomyBranch.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }

                var personPersonStewardOrganizations = personBeingEdited.PersonStewardOrganizations.ToList();
                foreach (var personStewardOrganization in personPersonStewardOrganizations)
                {
                    personStewardOrganization.DeleteFull(HttpRequestStorage.DatabaseEntities);
                }
            }
        }
    }
}
