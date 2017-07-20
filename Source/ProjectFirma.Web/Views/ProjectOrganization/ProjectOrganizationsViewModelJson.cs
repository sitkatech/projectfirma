/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationsViewModelJson.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectOrganization
{
    [ModelBinder(typeof(ProjectOrganizationsViewModelJsonModelBinder))]
    public class ProjectOrganizationsViewModelJson
    {
        public ProjectOrganizationsViewModelJson(int? leadOrganizationID, List<ProjectOrganizationJson> projectOrganizations)
        {
            LeadOrganizationID = leadOrganizationID;
            ProjectOrganizations = projectOrganizations;
        }

        public int? LeadOrganizationID;
        public List<ProjectOrganizationJson> ProjectOrganizations;

        [Obsolete("Needed by the ModelBinder")]
        public ProjectOrganizationsViewModelJson()
        {
        }

        public class ProjectOrganizationJson
        {
            public int? OrganizationID;
            public List<RelationshipTypeSimple> RelationshipTypes;

            [Obsolete("Needed by the ModelBinder")]
            public ProjectOrganizationJson()
            {
            }

            public ProjectOrganizationJson(Models.Organization organization, List<Models.ProjectOrganization> organizationProjectOrganizations)
            {
                OrganizationID = organization.OrganizationID;
                RelationshipTypes = organizationProjectOrganizations.Select(x => new RelationshipTypeSimple(x.RelationshipType)).ToList();             
            }

            public override string ToString()
            {
                return
                    $"OrganizationID: {OrganizationID};";
            }
        }
    }

    public class ProjectOrganizationsViewModelJsonModelBinder : SitkaModelBinder
    {
        public ProjectOrganizationsViewModelJsonModelBinder() : base(JsonTools.DeserializeObject<ProjectOrganizationsViewModelJson>)
        {
        }
    }
}
