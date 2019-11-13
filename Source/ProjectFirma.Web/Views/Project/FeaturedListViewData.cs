/*-----------------------------------------------------------------------
<copyright file="FeaturedListViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectCustomGrid;

namespace ProjectFirma.Web.Views.Project
{
    public class FeaturedListViewData : FirmaViewData
    {
        public ProjectCustomGridSpec ProjectCustomDefaultGridSpec { get; }
        public string ProjectCustomDefaultGridName { get; }
        public string ProjectCustomDefaultGridDataUrl { get; }

        public string EditUrl { get; }

        public FeaturedListViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, List<ProjectCustomGridConfiguration> projectCustomDefaultGridConfigurations) 
                                    : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Featured {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}";

            ProjectCustomDefaultGridSpec = new ProjectCustomGridSpec(currentFirmaSession, projectCustomDefaultGridConfigurations) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            ProjectCustomDefaultGridName = "featuredListGrid";
            ProjectCustomDefaultGridDataUrl = SitkaRoute<ProjectCustomGridController>.BuildUrlFromExpression(tc => tc.FeaturedProjectsGridJsonData());

            EditUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.EditFeaturedProjects());
        }
    }

    public class FeaturesListProjectGridSpec : BasicProjectInfoGridSpec
    {
        public FeaturesListProjectGridSpec(FirmaSession firmaSession)
            : base(firmaSession, true)
        {
            Add("# of Photos", x => x.ProjectImages.Count, 100);
            Add($"Reported {MultiTenantHelpers.GetPerformanceMeasureNamePluralized()}", x => string.Join(", ", x.PerformanceMeasureActuals.Select(pm => pm.PerformanceMeasureID).Distinct().OrderBy(pmID => pmID)), 100);
        }
    }
}
