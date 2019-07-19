/*-----------------------------------------------------------------------
<copyright file="EditOrganizationsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectOrganization
{
    public class EditOrganizationsViewData
    {
        public List<OrganizationSimple> AllOrganizations { get; }
        public List<PersonSimple> AllPeople { get; }
        public List<OrganizationRelationshipTypeSimple> AllOrganizationRelationshipTypes { get; }
        public Dictionary<int, OrganizationSimple> OrganizationContainingProjectSimpleLocation { get; }
        public OrganizationRelationshipTypeSimple PrimaryContactRelationshipTypeSimple { get; }

        public EditOrganizationsViewData(IProject project, IEnumerable<ProjectFirmaModels.Models.Organization> organizations, IEnumerable<Person> allPeople, List<OrganizationRelationshipType> allOrganizationRelationshipTypes, Person defaultPrimaryContactPerson)
        {            
            AllPeople = allPeople.Select(x => new PersonSimple(x)).ToList();
            AllOrganizations = organizations.Where(x => x.OrganizationType.OrganizationTypeOrganizationRelationshipTypes.Any()).Select(x => new OrganizationSimple(x)).ToList();

            OrganizationContainingProjectSimpleLocation = allOrganizationRelationshipTypes.ToDictionary(
                x => x.OrganizationRelationshipTypeID, x =>
                {
                    var organization = x.GetOrganizationContainingProjectSimpleLocation(project);
                    return organization == null ? null : new OrganizationSimple(organization);
                });

            var primaryContactRelationshipType = MultiTenantHelpers.GetIsPrimaryContactOrganizationRelationship();
            PrimaryContactRelationshipTypeSimple = primaryContactRelationshipType != null
                ? new OrganizationRelationshipTypeSimple(primaryContactRelationshipType)
                : null;
            AllOrganizationRelationshipTypes = allOrganizationRelationshipTypes.Except(new[] {primaryContactRelationshipType}).Select(x => new OrganizationRelationshipTypeSimple(x)).ToList();
        }
    }
}
