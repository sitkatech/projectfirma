/*-----------------------------------------------------------------------
<copyright file="Watershed.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class Watershed : IAuditableEntity
    {
        public string DisplayName
        {
            get { return WatershedName; }
        }

        public List<Project> AssociatedProjects
        {
            get { return ProjectWatersheds.Select(ptc => ptc.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public static bool IsWatershedNameUnique(IEnumerable<Watershed> watersheds, string watershedName, int currentWatershedID)
        {
            var watershed = watersheds.SingleOrDefault(x => x.WatershedID != currentWatershedID && String.Equals(x.WatershedName, watershedName, StringComparison.InvariantCultureIgnoreCase));
            return watershed == null;
        }

        public string AuditDescriptionString
        {
            get { return WatershedName; }
        }

        public static GeoJSON.Net.Feature.FeatureCollection ToGeoJsonFeatureCollection(List<Watershed> watersheds)
        {
            var featureCollection = new GeoJSON.Net.Feature.FeatureCollection();
            featureCollection.Features.AddRange(watersheds.Select(MakeFeatureWithRelevantProperties).ToList());
            return featureCollection;
        }

        private static GeoJSON.Net.Feature.Feature MakeFeatureWithRelevantProperties(Watershed watershed)
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(watershed.WatershedFeature);
            feature.Properties.Add("Watershed", watershed.GetDisplayNameAsUrl().ToString());
            return feature;
        }
    }
}
