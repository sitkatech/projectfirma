/*-----------------------------------------------------------------------
<copyright file="ProjectMapViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class ProjectMapViewData : FirmaViewData
    {
        public ProjectLocationsMapInitJson ProjectLocationsMapInitJson { get; }

        public ProjectLocationsMapViewData ProjectLocationsMapViewData { get; }
        public Dictionary<ProjectLocationFilterTypeSimple, IEnumerable<SelectListItem>> ProjectLocationFilterTypesAndValues { get; }
        public string ProjectLocationsUrl { get; }
        public string FilteredProjectsWithLocationAreasUrl { get; }

        public ProjectMapViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, ProjectLocationsMapInitJson projectLocationsMapInitJson, ProjectLocationsMapViewData projectLocationsMapViewData, Dictionary<ProjectLocationFilterTypeSimple, IEnumerable<SelectListItem>> projectLocationFilterTypesAndValues, string projectLocationsUrl, string filteredProjectsWithLocationAreasUrl, List<ProjectColorByType> projectColorByTypes) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} Map";
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationFilterTypesAndValues = projectLocationFilterTypesAndValues;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsUrl = projectLocationsUrl;
            FilteredProjectsWithLocationAreasUrl = filteredProjectsWithLocationAreasUrl;
            ProjectColorByTypes = projectColorByTypes;
        }

        public List<ProjectColorByType> ProjectColorByTypes { get; }
    }
}
