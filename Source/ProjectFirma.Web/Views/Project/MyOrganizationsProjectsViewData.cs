/*-----------------------------------------------------------------------
<copyright file="MyOrganizationsProjectsViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class MyOrganizationsProjectsViewData : FirmaViewData
    {
        public readonly BasicProjectInfoGridSpec ProjectsGridSpec;
        public readonly string ProjectsGridName;
        public readonly string ProjectsGridDataUrl;

        public readonly ProposedProjectGridSpec ProposedProjectsGridSpec;
        public readonly string ProposedProjectsGridName;
        public readonly string ProposedProjectsGridDataUrl;
        public readonly string ProposeNewProjectUrl;


        public MyOrganizationsProjectsViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            //TODO: It shouldn't be possible to reach this if Person.Organization is null...
            string organizationNamePossessive = currentPerson.Organization.OrganizationNamePossessive;
            PageTitle = $"{organizationNamePossessive} {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}";

            ProjectsGridName = "myOrganizationsProjectListGrid";
            ProjectsGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                
                ObjectNameSingular = $"{organizationNamePossessive} {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{organizationNamePossessive} {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };
            ProjectsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.MyOrganizationsProjectsGridJsonData());

            ProposedProjectsGridName = "myOrganizationsProposedProjectsGrid";
            ProposedProjectsGridSpec = new ProposedProjectGridSpec(currentPerson)
            {
                ObjectNameSingular = $"{organizationNamePossessive} {Models.FieldDefinition.ProposedProject.GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{organizationNamePossessive} {Models.FieldDefinition.ProposedProject.GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true 
            
            };
            ProposedProjectsGridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.MyOrganizationsProposedProjectsGridJsonData());

            ProposeNewProjectUrl = SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(tc => tc.Instructions(null));
        }
    }
}
