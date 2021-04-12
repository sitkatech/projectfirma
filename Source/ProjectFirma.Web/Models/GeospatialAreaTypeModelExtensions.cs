using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using GeoJSON.Net.Converters;
using GeoJSON.Net.Feature;
using LtInfo.Common;
using LtInfo.Common.GdalOgr;
using Newtonsoft.Json;
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
            var geoServerNamespace = MultiTenantHelpers.GetTenantAttributeFromCache().GeoServerNamespace;
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

        public static readonly UrlTemplate<int> EditMapLayerUrlTemplate = new UrlTemplate<int>(SitkaRoute<MapLayerController>.BuildUrlFromExpression(t => t.EditGeospatialAreaMapLayer(UrlTemplate.Parameter1Int)));
        public static string GetEditMapLayerUrl(this GeospatialAreaType geospatialAreaType)
        {
            return EditMapLayerUrlTemplate.ParameterReplace(geospatialAreaType.GeospatialAreaTypeID);
        }     
        
        public static readonly UrlTemplate<int> SyncUrlTemplate = new UrlTemplate<int>(SitkaRoute<MapLayerController>.BuildUrlFromExpression(t => t.SyncGeospatialAreaType(UrlTemplate.Parameter1Int)));
        public static string GetSyncUrl(this GeospatialAreaType geospatialAreaType)
        {
            return SyncUrlTemplate.ParameterReplace(geospatialAreaType.GeospatialAreaTypeID);
        }

        public static void ProcessApiResponse(GeospatialAreaType geospatialAreaType,
            string responseData, DatabaseEntities dbContext, string databaseConnectionString)
        {
            var geospatialAreaTypeID = geospatialAreaType.GeospatialAreaTypeID;
            var geospatialAreaStagings = ConvertToGeospatialStagings(responseData, dbContext, databaseConnectionString);
            var stagedExternalIDs = geospatialAreaStagings.Select(x => x.ExternalID).ToList();
            var currentExternalIDs = dbContext.GeospatialAreas.Where(x => x.GeospatialAreaTypeID == geospatialAreaTypeID).Select(x => x.ExternalID).ToList();
            var newGeospatialAreas = geospatialAreaStagings.Where(x => !currentExternalIDs.Contains(x.ExternalID))
                .Select(x => new GeospatialArea(x.Name, geospatialAreaTypeID, x.Name) { ExternalID = x.ExternalID, GeospatialAreaFeature = x.Geometry }).ToList();
            dbContext.AllGeospatialAreas.AddRange(newGeospatialAreas);
            // Find entities with matching names in DB and Service
            var geospatialAreasToUpdate = dbContext.GeospatialAreas.Where(x => stagedExternalIDs.Contains(x.ExternalID));
            if (geospatialAreasToUpdate.Any())
            {
                foreach (var geospatialArea in geospatialAreasToUpdate)
                {
                    // Get the corresponding feature from staging
                    var geospatialAreaStaging = geospatialAreaStagings.Single(x => x.ExternalID == geospatialArea.ExternalID);
                    // Update certain properties
                    geospatialArea.GeospatialAreaName = geospatialAreaStaging.Name;
                    geospatialArea.GeospatialAreaShortName = geospatialAreaStaging.Name;
                    geospatialArea.GeospatialAreaFeature = geospatialAreaStaging.Geometry;
                }
            }

            var geospatialAreasToPotentiallyDelete =
                dbContext.GeospatialAreas.Where(x => !stagedExternalIDs.Contains(x.ExternalID)).ToList();
            if (geospatialAreasToPotentiallyDelete.Any())
            {
                foreach (var geospatialArea in geospatialAreasToPotentiallyDelete)
                {
                    if (!geospatialArea.HasDependentObjects())
                    {
                        geospatialArea.Delete(dbContext);
                    }
                }
            }
        }

        private static List<GeospatialAreaStaging> ConvertToGeospatialStagings(string responseData, DatabaseEntities dbContext, string databaseConnectionString)
        {
            var featureCollection =
                JsonConvert.DeserializeObject<FeatureCollection>(responseData, new GeometryConverter());
            if (!featureCollection.Features.Any())
            {
                throw new Exception("No geospatial area features were returned from the endpoint.");
            }

            // Clear out staging table
            var tenantID = HttpRequestStorage.Tenant.TenantID;
            var stagingsToDelete = dbContext.GeospatialAreaStagings.ToList();
            dbContext.AllGeospatialAreaStagings.RemoveRange(stagingsToDelete);
            dbContext.SaveChangesWithNoAuditing(tenantID);

            var ogr2OgrCommandLineRunner = new Ogr2OgrCommandLineRunner(FirmaWebConfiguration.Ogr2OgrExecutable,
                Ogr2OgrCommandLineRunner.DefaultCoordinateSystemId,
                FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);
            ogr2OgrCommandLineRunner.ImportGeoJsonToMsSql(responseData,
                databaseConnectionString,
                "GeospatialAreaStaging",
                $"SELECT {tenantID} as TenantID, Name as Name, GlobalID as ExternalID",
                false);
            return dbContext.GeospatialAreaStagings.ToList();
        }
    }
}