/*-----------------------------------------------------------------------
<copyright file="Watershed.cs" company="Tahoe Regional Planning Agency">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.GeoJson;
using LtInfo.Common.Models;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Models
{
    public partial class Watershed : IAuditableEntity
    {
        public string DisplayName => WatershedName;

        public List<Project> AssociatedProjects
        {
            get { return ProjectWatersheds.Select(ptc => ptc.Project).Distinct(new HavePrimaryKeyComparer<Project>()).OrderBy(x => x.DisplayName).ToList(); }
        }

        public static bool IsWatershedNameUnique(IEnumerable<Watershed> watersheds, string watershedName, int currentWatershedID)
        {
            var watershed = watersheds.SingleOrDefault(x => x.WatershedID != currentWatershedID && String.Equals(x.WatershedName, watershedName, StringComparison.InvariantCultureIgnoreCase));
            return watershed == null;
        }

        public string AuditDescriptionString => WatershedName;

        public Feature MakeFeatureWithRelevantProperties()
        {
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(WatershedFeature);
            feature.Properties.Add(FieldDefinition.Watershed.GetFieldDefinitionLabel(), GetDisplayNameAsUrl().ToString());
            return feature;
        }

        public HtmlString GetDisplayNameAsUrl()
        {
            return UrlTemplate.MakeHrefString(GetSummaryUrl(), DisplayName);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<WatershedController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));

        public string GetSummaryUrl()
        {
            return SummaryUrlTemplate.ParameterReplace(WatershedID);
        }

        public static LayerGeoJson GetWatershedWmsLayerGeoJson(string layerColor, decimal layerOpacity, LayerInitialVisibility layerInitialVisibility = LayerInitialVisibility.Show)
        {
            var tenantAttribute = HttpRequestStorage.Tenant.GetTenantAttribute();
            return new LayerGeoJson(FieldDefinition.Watershed.GetFieldDefinitionLabel(), tenantAttribute.MapServiceUrl, tenantAttribute.WatershedLayerName, layerColor, layerOpacity, layerInitialVisibility);
        }
    }
}
