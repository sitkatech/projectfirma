/*-----------------------------------------------------------------------
<copyright file="ProjectLocationSummaryViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Views.Map;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationSummaryViewData : FirmaUserControlViewData
    {
        public string ProjectLocationNotes { get; }
        public ProjectLocationSummaryMapInitJson ProjectLocationSummaryMapInitJson { get; }
        public List<ProjectFirmaModels.Models.GeospatialArea> GeospatialAreas { get; }
        public bool HasLocationNotes { get; }
        public bool HasLocationInformation { get; }
        public Dictionary<int, string> DictionaryGeoNotes { get; }
        public bool LocationIsPrivate { get; }
        public bool UserHasEditProjectPermissions { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }



        public ProjectLocationSummaryViewData(IProject project, ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson, 
            Dictionary<int, string> dictionaryGeoNotes, List<GeospatialAreaType> geospatialAreaTypes, 
            List<ProjectFirmaModels.Models.GeospatialArea> geospatialAreas, bool locationIsPrivate, bool userHasEditProjectPermissions)
        {
            ProjectLocationNotes = project.ProjectLocationNotes;
            ProjectLocationSummaryMapInitJson = projectLocationSummaryMapInitJson;
            GeospatialAreas = geospatialAreas;
            HasLocationNotes = !string.IsNullOrWhiteSpace(project.ProjectLocationNotes);
            HasLocationInformation = project.ProjectLocationSimpleType != ProjectLocationSimpleType.None;
            DictionaryGeoNotes = dictionaryGeoNotes;
            GeospatialAreaTypes = geospatialAreaTypes;
            LocationIsPrivate = locationIsPrivate;
            UserHasEditProjectPermissions = userHasEditProjectPermissions;  
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();

        }

        public List<GeospatialAreaType> GeospatialAreaTypes { get; }
    }
}
