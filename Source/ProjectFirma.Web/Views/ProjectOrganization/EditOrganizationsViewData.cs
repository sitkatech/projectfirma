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
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    public class EditOrganizationsViewData
    {
        public readonly List<OrganizationSimple> AllOrganizations;
        public readonly List<PersonSimple> AllPeople;
        public readonly List<RelationshipTypeSimple> AllRelationshipTypes;

        public EditOrganizationsViewData(IEnumerable<Models.Organization> organizations, IEnumerable<Person> allPeople, List<RelationshipType> allRelationshipTypes)
        {
            AllPeople = allPeople.Select(x => new PersonSimple(x)).ToList();
            AllOrganizations = organizations.Where(x => x.OrganizationTypeID.HasValue && x.OrganizationType.OrganizationTypeRelationshipTypes.Any()).Select(x => new OrganizationSimple(x)).ToList();
            AllRelationshipTypes = allRelationshipTypes.Select(x => new RelationshipTypeSimple(x)).ToList();
        }
    }
}
