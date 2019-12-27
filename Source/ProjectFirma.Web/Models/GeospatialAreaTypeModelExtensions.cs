using System;
using System.Collections.Specialized;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaTypeModelExtensions
    {
        public static string GetEditGeospatialAreasUrl(this GeospatialAreaType geospatialAreaType, Project project)
        {
            return SitkaRoute<ProjectGeospatialAreaController>.BuildUrlFromExpression(x =>
                x.EditProjectGeospatialAreas(project.ProjectID, geospatialAreaType.GeospatialAreaTypeID));
        }

        public static string MapServiceUrl(this GeospatialAreaType geospatialAreaType)
        {
            var geoServerNamespace = MultiTenantHelpers.GetTenantAttribute().GeoServerNamespace;
            return $"{FirmaWebConfiguration.GeoServerUrl}{geoServerNamespace}/wms";
        }

        public static HtmlString GetGeoJsonLinkHtmlString(this GeospatialAreaType geospatialAreaType)
        {
            var mapServiceUri = new UriBuilder(geospatialAreaType.MapServiceUrl());
            mapServiceUri.Path = mapServiceUri.Path.Replace("/wms", "/ows");

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["service"] = "WFS";
            queryString["version"] = "1.0.0";
            queryString["request"] = "GetFeature";
            queryString["typeName"] = geospatialAreaType.GeospatialAreaLayerName;
            queryString["outputFormat"] = "application/json";
            queryString["maxFeatures"] = "500";
            queryString["sortBy"] = "PrimaryKey";
            queryString["startIndex"] = "0";
            mapServiceUri.Query = queryString.ToString();

            return UrlTemplate.MakeHrefString(mapServiceUri.ToString(), mapServiceUri.ToString());
        }
    }
}