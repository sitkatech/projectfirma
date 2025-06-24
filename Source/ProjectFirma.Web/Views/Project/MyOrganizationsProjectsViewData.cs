﻿/*-----------------------------------------------------------------------
<copyright file="MyOrganizationsProjectsViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;
using LtInfo.Common.AgGridWrappers;

namespace ProjectFirma.Web.Views.Project
{
    public class MyOrganizationsProjectsViewData : FirmaViewData
    {
        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public string PendingProjectsLabel { get; }
        public PendingGridSpec PendingGridSpec { get; }
        public string PendingGridName { get; }
        public string PendingGridDataUrl { get; }

        public ProposalsGridSpec ProposalsGridSpec { get; }
        public string ProposalsGridName { get; }
        public string ProposalsGridDataUrl { get; }
        public string ProposeNewProjectUrl { get; }

        public MyOrganizationsProjectsViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations) : base(currentFirmaSession, firmaPage)
        {
            //TODO: It shouldn't be possible to reach this if Person.Organization is null...
            var currentPerson = currentFirmaSession.Person;
            var organizationNamePossessive = currentPerson.Organization.GetOrganizationNamePossessive();
            PageTitle = $"{organizationNamePossessive} {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}";
            var projectDetails = HttpRequestStorage.DatabaseEntities.vProjectDetails.ToDictionary(x => x.ProjectID);
            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomDefaultGridConfigurations, ProjectCustomGridType.Default.ToEnum, projectDetails, currentFirmaSession.Tenant) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "myOrganizationsProjectListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.MyOrganizationProjectsCustomGridDefaultJsonData());

            PendingProjectsLabel = MultiTenantHelpers.GetTenantName() == "TCSProjectTracker"
                ? $"Existing {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}"
                : $"Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}";
            var pendingProjectLabel = MultiTenantHelpers.GetTenantName() == "TCSProjectTracker"
                ? $"Existing {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}"
                : $"Pending {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}";
            PendingGridSpec = new PendingGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = pendingProjectLabel,
                ObjectNamePlural = PendingProjectsLabel,
                SaveFiltersInCookie = true
            };
            PendingGridName = "myOrganizationsPendingProjectsGrid";
            PendingGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.PendingGridJsonData());

            ProposalsGridName = "myOrganizationsProposalsGrid";
            ProposalsGridSpec = new ProposalsGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = $"{organizationNamePossessive} {FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{organizationNamePossessive} {FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true 
            
            };
            ProposalsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.MyOrganizationsProposalsGridJsonData());

            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(tc => tc.InstructionsProposal(null));
        }
    }
}
