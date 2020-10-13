/*-----------------------------------------------------------------------
<copyright file="FactSheetViewData.cs" company="Tahoe Regional Planning Agency">
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

using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Project;
using ProjectFirma.Web.Views.Shared.ProjectPotentialPartner;

namespace ProjectFirma.Web.Views.MatchMaker
{
    public class ProjectPotentialPartnersViewData : ProjectViewData
    {
        public ProjectPotentialPartnerDetailViewData PotentialPartnerDetailViewData;

        public ProjectPotentialPartnersViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Project project) : base(currentFirmaSession, project)
        {
            PageTitle = $"Potential Partners for Project {project.GetDisplayName()}";
            BreadCrumbTitle = "Project Potential Partners";

            PotentialPartnerDetailViewData = new ProjectPotentialPartnerDetailViewData(currentFirmaSession, project, ProjectPotentialPartnerListDisplayMode.StandAloneFullList);
        }
    }

/*
    public class OrganizationPotentialPartnersViewData : FirmaViewData
    {
        public OrganizationPotentialPartnerDetailViewData PotentialPartnerDetailViewData;

        public OrganizationPotentialPartnersViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Organization organization) :base(currentFirmaSession)
        {
            PageTitle = $"Potential Partners for Organization {organization.GetDisplayName()}";
            BreadCrumbTitle = "Organization Potential Partners";

            PotentialPartnerDetailViewData = new ProjectPotentialPartnerDetailViewData(currentFirmaSession, project, ProjectPotentialPartnerListDisplayMode.StandAloneFullList);
        }
    }
*/

}
