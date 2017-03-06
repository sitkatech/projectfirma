/*-----------------------------------------------------------------------
<copyright file="EditPersonOrganizationsViewModel.cs" company="Tahoe Regional Planning Agency">
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
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.PersonOrganization
{
    public class EditPersonOrganizationsViewModel : FormViewModel
    {
        public List<int> OrganizationIDs { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditPersonOrganizationsViewModel()
        {
        }

        public EditPersonOrganizationsViewModel(List<int> organizationIDs)
        {
            OrganizationIDs = organizationIDs;
        }

        public void UpdateModel(Person person, List<Models.Organization> allOrganizations)
        {
            // Remove all existing associations
            var currentOrgsForWhichIAmPrimaryContact = allOrganizations.Where(o => o.PrimaryContactPersonID == person.PersonID).ToList();
            currentOrgsForWhichIAmPrimaryContact.ForEach(org => org.PrimaryContactPersonID = null);

            // Create all-new associations
            if (OrganizationIDs != null && OrganizationIDs.Any())
            {
                var realOrgsINeedAssociationsFor = allOrganizations.Where(org => OrganizationIDs.Contains(org.OrganizationID)).ToList();
                realOrgsINeedAssociationsFor.ForEach(org => org.PrimaryContactPersonID = person.PersonID);
            }
        }
    }
}
