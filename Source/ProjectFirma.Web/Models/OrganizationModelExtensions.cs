/*-----------------------------------------------------------------------
<copyright file="OrganizationModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using GeoJSON.Net.Feature;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.GeoJson;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static class OrganizationModelExtensions
    {
        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.DeleteOrganization(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this Organization organization)
        {
            return DeleteUrlTemplate.ParameterReplace(organization.OrganizationID);
        }

        public static HtmlString GetDisplayNameAsUrl(this Organization organization)
        {          
            return organization != null ? UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.DisplayName) : new HtmlString(null);
        }

        public static HtmlString GetShortNameAsUrl(this Organization organization)
        {          
            return organization != null ? UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.OrganizationShortName ?? organization.OrganizationName) : new HtmlString(null);
        }

        public static readonly UrlTemplate<int> SummaryUrlTemplate = new UrlTemplate<int>(SitkaRoute<OrganizationController>.BuildUrlFromExpression(t => t.Detail(UrlTemplate.Parameter1Int)));
        public static string GetDetailUrl(this Organization organization)
        {
            return organization == null ? "" : SummaryUrlTemplate.ParameterReplace(organization.OrganizationID);
        }

        public static List<LayerGeoJson> GetBoundaryLayerGeoJson(this IEnumerable<Organization> organizations)
        {
            var organizationsToShow =
                organizations?.Where(x => x.OrganizationBoundary != null && x.OrganizationType != null)
                    .ToList();
            if (organizationsToShow == null || !organizationsToShow.Any())
            {
                return new List<LayerGeoJson>();
            }


            return organizationsToShow.GroupBy(x => x.OrganizationType, (organizationType, organizationList) =>
            {
                return new LayerGeoJson(
                    $"{organizationType.OrganizationTypeName} {FieldDefinition.Organization.GetFieldDefinitionLabelPluralized()}",
                    new FeatureCollection(organizationList.Select(organization =>
                    {
                        var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(organization.OrganizationBoundary);
                        feature.Properties.Add("Organization Name", UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.OrganizationName).ToHtmlString());
                        feature.Properties.Add("Short Name", UrlTemplate.MakeHrefString(organization.GetDetailUrl(), organization.OrganizationShortName).ToHtmlString());
                        return feature;
                    }).ToList()),
                    organizationType.LegendColor, 1,
                    organizationType.ShowOnProjectMaps ? LayerInitialVisibility.Show : LayerInitialVisibility.Hide);
            }).ToList();
        }
    }
}
