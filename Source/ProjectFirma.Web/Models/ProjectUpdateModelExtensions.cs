using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectUpdateModelExtensions
    {
        public static void CreateFromProject(this ProjectUpdateBatch projectUpdateBatch)
        {
            var projectUpdate = new ProjectUpdate(projectUpdateBatch);
            HttpRequestStorage.DatabaseEntities.AllProjectUpdates.Add(projectUpdate);
        }

        public static string GetPlanningDesignStartYear(this ProjectUpdate projectUpdate)
        {
            return projectUpdate.PlanningDesignStartYear.HasValue ? MultiTenantHelpers.FormatReportingYear(projectUpdate.PlanningDesignStartYear.Value) : null;
        }

        public static FeatureCollection DetailedLocationToGeoJsonFeatureCollection(this ProjectUpdate projectUpdate, bool userCanViewPrivateLocations)
        {
            return projectUpdate.GetProjectLocationDetailedAsProjectLocationUpdate(userCanViewPrivateLocations).ToGeoJsonFeatureCollection();
        }

        public static FeatureCollection SimpleLocationToGeoJsonFeatureCollection(this ProjectUpdate projectUpdate, FirmaSession firmaSession)
        {
            var featureCollection = new FeatureCollection();
            var userCanViewPrivateLocations = firmaSession.UserCanViewPrivateLocations(projectUpdate);
            if ((projectUpdate.ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap || projectUpdate.ProjectLocationSimpleType == ProjectLocationSimpleType.LatLngInput) && 
                projectUpdate.HasProjectLocationPoint(userCanViewPrivateLocations))
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(projectUpdate.GetProjectLocationPoint(userCanViewPrivateLocations)));
            }
            return featureCollection;
        }
    }
}