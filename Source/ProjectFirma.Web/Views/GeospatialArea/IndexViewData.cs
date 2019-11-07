/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class IndexViewData : FirmaViewData
    {
        public GeospatialAreaType GeospatialAreaType { get; }
        public MapInitJson MapInitJson { get; }
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }

        public IndexViewData(FirmaSession currentFirmaSession, GeospatialAreaType geospatialAreaType, MapInitJson mapInitJson) : base(currentFirmaSession)
        {
            PageTitle = $"{geospatialAreaType.GeospatialAreaTypeNamePluralized}";
            MapInitJson = mapInitJson;
            GeospatialAreaType = geospatialAreaType;
            GridSpec = new IndexGridSpec(currentFirmaSession, geospatialAreaType) {ObjectNameSingular = $"{geospatialAreaType.GeospatialAreaTypeName}", ObjectNamePlural = $"{geospatialAreaType.GeospatialAreaTypeNamePluralized}", SaveFiltersInCookie = true};
            GridName = "geospatialAreasGrid";
            GridDataUrl = SitkaRoute<GeospatialAreaController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData(geospatialAreaType));
        }
    }
}
