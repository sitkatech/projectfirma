/*-----------------------------------------------------------------------
<copyright file="MyOrganizationsProjectsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class MyOrganizationsProjectsViewData : FirmaViewData
    {
        public readonly BasicProjectInfoGridSpec ProjectsGridSpec;
        public readonly string ProjectsGridName;
        public readonly string ProjectsGridDataUrl;

        public readonly ProposalsGridSpec ProposalsesGridSpec;
        public readonly string ProposalsGridName;
        public readonly string ProposalsGridDataUrl;
        public readonly string ProposeNewProjectUrl;


        public MyOrganizationsProjectsViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            //TODO: It shouldn't be possible to reach this if Person.Organization is null...
            var organizationNamePossessive = currentPerson.Organization.OrganizationNamePossessive;
            PageTitle = $"{organizationNamePossessive} {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}";

            ProjectsGridName = "myOrganizationsProjectListGrid";
            ProjectsGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                
                ObjectNameSingular = $"{organizationNamePossessive} {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{organizationNamePossessive} {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };
            ProjectsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.MyOrganizationsProjectsGridJsonData());

            ProposalsGridName = "myOrganizationsProposalsGrid";
            ProposalsesGridSpec = new ProposalsGridSpec(currentPerson)
            {
                ObjectNameSingular = $"{organizationNamePossessive} {Models.FieldDefinition.Proposal.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{organizationNamePossessive} {Models.FieldDefinition.Proposal.GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true 
            
            };
            ProposalsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.MyOrganizationsProposalsGridJsonData());

            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(tc => tc.Instructions(null));
        }
    }
}
