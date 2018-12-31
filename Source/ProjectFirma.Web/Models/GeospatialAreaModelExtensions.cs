/*-----------------------------------------------------------------------
<copyright file="GeospatialAreaModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using GeoJSON.Net.Feature;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaModelExtensions
    {
        public static FeatureCollection ToGeoJsonFeatureCollection(this IEnumerable<GeospatialArea> geospatialAreas)
        {
            return new FeatureCollection(geospatialAreas.Select(x => x.MakeFeatureWithRelevantProperties()).ToList());
        }

        public static List<GeospatialArea> GetGeospatialAreasContainingProjectLocation(this IEnumerable<GeospatialArea> geospatialAreas, IProject project)
        {
            return project?.ProjectLocationPoint == null
                ? new List<GeospatialArea>()
                : geospatialAreas.Where(x =>
                    x.GeospatialAreaFeature.Contains(project.ProjectLocationPoint)).ToList();
        }
    }
}
