/*-----------------------------------------------------------------------
<copyright file="GeospatialArea.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using LtInfo.Common.GeoJson;
using GeoJSON.Net.Feature;

namespace ProjectFirmaModels.Models
{
    public partial class GeospatialArea : IAuditableEntity
    {
        public string GetDisplayName() => GeospatialAreaName;

        public List<Project> GetAssociatedProjects(Person person)
        {
            return ProjectGeospatialAreas.Select(ptc => ptc.Project).ToList().GetActiveProjectsAndProposals(person.CanViewProposals());
        }

        public string GetAuditDescriptionString() => GeospatialAreaName;

        public Feature MakeFeatureWithRelevantProperties()
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(GeospatialAreaFeature);
            feature.Properties.Add(GeospatialAreaType.GeospatialAreaTypeName, this.GetDisplayNameAsUrl().ToString());
            return feature;
        }
    }
}
