/*-----------------------------------------------------------------------
<copyright file="County.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
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
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public partial class County
    {
        public static GeoJSON.Net.Feature.FeatureCollection ToGeoJsonFeatureCollection(List<County> counties)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();
            featureCollection.Features.AddRange(counties.Select(MakeFeatureWithRelevantProperties).ToList());
            return featureCollection;
        }

        private static GeoJSON.Net.Feature.Feature MakeFeatureWithRelevantProperties(County county)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(county.CountyFeature);
            feature.Properties.Add("State", county.StateProvince.StateProvinceAbbreviation);
            feature.Properties.Add("County", county.CountyName);
            return feature;
        }
    }
}
