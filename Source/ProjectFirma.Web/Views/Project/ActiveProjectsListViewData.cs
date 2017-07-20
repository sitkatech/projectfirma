/*-----------------------------------------------------------------------
<copyright file="ActiveProjectsListViewData.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Project
{
    public class ActiveProjectsListViewData : FirmaViewData
    {
        public readonly bool HasProposedProjectPermissions;
        public readonly BasicProjectInfoGridSpec GridSpec;
        public readonly string GridName;
        public readonly string GridDataUrl;
        public readonly string ProposeNewProjectUrl;
        public ActiveProjectsListViewData(Person currentPerson, Models.FirmaPage firmaPage) : base(currentPerson, firmaPage)
        {
            HasProposedProjectPermissions = new ProposedProjectCreateNewFeature().HasPermissionByPerson(currentPerson);
            ProposeNewProjectUrl = SitkaRoute<ProposedProjectController>.BuildUrlFromExpression(tc => tc.Instructions(null));

            PageTitle = $"Active {Models.FieldDefinition.Project.GetFieldDefinitionLabel()} List";

            GridName = "activeProjectsListGrid";
            GridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true) { ObjectNameSingular = "Active Project", ObjectNamePlural = "Active Projects", SaveFiltersInCookie = true };
            
            GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.ActiveProjectsListGridJsonData());

        }
    }
}
