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

using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationSummaryViewData : FirmaUserControlViewData
    {
        public readonly string ProjectLocationNotes;
        public readonly ProjectLocationSummaryMapInitJson ProjectLocationSummaryMapInitJson;
        public readonly List<Models.GeospatialArea> GeospatialAreas;
        public readonly bool HasLocationNotes;
        public readonly bool HasLocationInformation;
        public Dictionary<int, string> DictionaryGeoNotes { get; }


        public ProjectLocationSummaryViewData(IProject project, ProjectLocationSummaryMapInitJson projectLocationSummaryMapInitJson, Dictionary<int, string> dictionaryGeoNotes, List<GeospatialAreaType> geospatialAreaTypes, List<Models.GeospatialArea> geospatialAreas)
        {
            ProjectLocationNotes = project.ProjectLocationNotes;
            ProjectLocationSummaryMapInitJson = projectLocationSummaryMapInitJson;
            GeospatialAreas = geospatialAreas;
            HasLocationNotes = !string.IsNullOrWhiteSpace(project.ProjectLocationNotes);
            HasLocationInformation = project.ProjectLocationSimpleType != ProjectLocationSimpleType.None;
            DictionaryGeoNotes = dictionaryGeoNotes;
            GeospatialAreaTypes = geospatialAreaTypes;
        }

        public List<GeospatialAreaType> GeospatialAreaTypes { get; }
    }
}
