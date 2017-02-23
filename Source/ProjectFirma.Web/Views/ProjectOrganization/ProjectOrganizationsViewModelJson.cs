/*-----------------------------------------------------------------------
<copyright file="ProjectOrganizationsViewModelJson.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System;
using System.Collections.Generic;
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
            public int OrganizationID;
            public string OrganizationDisplayName;
            public bool IsFundingOrganization;
            public bool IsImplementingOrganization;

            [Obsolete("Needed by the ModelBinder")]
            public ProjectOrganizationJson()
            {
            }

            public ProjectOrganizationJson(ProjectImplementingOrganizationOrProjectFundingOrganization po)
            {
                OrganizationID = po.Organization.OrganizationID;
                OrganizationDisplayName = po.Organization.DisplayName;
                IsFundingOrganization = po.IsFundingOrganization;
                IsImplementingOrganization = po.IsImplementingOrganization;
            }

            public ProjectOrganizationJson(int organizationID, string organizationDisplayName, bool isFundingOrganization, bool isImplementingOrganization)
            {
                OrganizationID = organizationID;
                OrganizationDisplayName = organizationDisplayName;
                IsFundingOrganization = isFundingOrganization;
                IsImplementingOrganization = isImplementingOrganization;
            }

            public override string ToString()
            {
                return string.Format("OrganizationID: {0}; OrganizationDisplayName: {1}; IsFundingOrganization: {2}; IsImplementingOrganization: {3}",
                    OrganizationID,
                    OrganizationDisplayName,
                    IsFundingOrganization,
                    IsImplementingOrganization);
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
