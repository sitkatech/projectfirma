/*-----------------------------------------------------------------------
<copyright file="ProjectLocationsMapInitJson.cs" company="Tahoe Regional Planning Agency">
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
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.Map
{
    public class ProjectLocationsMapInitJson : MapInitJson
    {
        private const int DefaultZoomLevel = 10;
        public readonly ProjectMapCustomization ProjectMapCustomization;
        public readonly LayerGeoJson ProjectLocationsLayerGeoJson;
        public readonly LayerGeoJson NamedAreasAsPointsLayerGeoJson;

        public ProjectLocationsMapInitJson(LayerGeoJson projectLocationsLayerGeoJson, LayerGeoJson namedAreasAsPointsLayerGeoJson, ProjectMapCustomization customization, string mapDivID)
            : base(mapDivID, DefaultZoomLevel, GetWatershedMapLayers(), BoundingBox.MakeNewDefaultBoundingBox())
        {
            ProjectMapCustomization = customization;
            ProjectLocationsLayerGeoJson = projectLocationsLayerGeoJson;
            NamedAreasAsPointsLayerGeoJson = namedAreasAsPointsLayerGeoJson;
        }
    }
}
