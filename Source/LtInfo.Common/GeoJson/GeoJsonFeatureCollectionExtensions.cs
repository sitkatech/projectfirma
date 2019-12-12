/*-----------------------------------------------------------------------
<copyright file="GeoJsonFeatureCollectionExtensions.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
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

namespace LtInfo.Common.GeoJson
{
    public static class GeoJsonFeatureCollectionExtensions
    {
        public static List<string> GetFeaturePropertyNames(this FeatureCollection featureCollection)
        {
            return featureCollection.Features.First().Properties.Keys.ToList();
        }

        public static List<string> GetFeaturePropertyNamesNoNullValues(this FeatureCollection featureCollection)
        {
            var propertiesDictionary = featureCollection.Features.First().Properties;
            var properties = new List<string>();
            foreach (var key in propertiesDictionary.Keys.ToList())
            {
                if (propertiesDictionary[key] != null)
                {
                    properties.Add(key);
                }
            }
            return properties;
        }
    }
}
