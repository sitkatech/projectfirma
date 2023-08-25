/*-----------------------------------------------------------------------
<copyright file="ProjectDashboardViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectDashboardViewData : FirmaViewData
    {
        public List<ProjectFirmaModels.Models.Project> Projects { get; }
        public int TotalProjects { get; }
        public int TotalPartners { get; }
        public int TotalProjectsInUnderservedCommunities { get; }
        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }
        public bool HasSitkaAdminPermissions { get; set; }

        public ProjectDashboardViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage,
            List<ProjectFirmaModels.Models.Project> projects,
            List<ProjectFirmaModels.Models.Organization> projectSponsors,
            List<ProjectFirmaModels.Models.Project> projectsInUnderservedCommunities,
            List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations,
            Dictionary<int, vProjectDetail> projectDetailsDictionary) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = "Project Dashboard";
            Projects = projects;

            TotalProjects = projects.Count;
            TotalPartners = projectSponsors.Count;
            TotalProjectsInUnderservedCommunities = projectsInUnderservedCommunities.Count;

            ProjectCustomDefaultGridSpec =
                new ProjectCustomGridSpec(currentFirmaSession, projectCustomDefaultGridConfigurations,
                    ProjectCustomGridType.Default.ToEnum, projectDetailsDictionary, currentFirmaSession.Tenant)
                {
                    ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                    ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                    SaveFiltersInCookie = true
                };
            ProjectCustomDefaultGridName = "projectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(tc => tc.ProjectDashboardProjectsGridJsonData());


            HasSitkaAdminPermissions = new SitkaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
        }
    }
}
