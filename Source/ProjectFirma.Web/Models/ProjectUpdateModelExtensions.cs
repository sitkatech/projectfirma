using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;
using ProjectFirma.Web.Common;
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

        public static FeatureCollection DetailedLocationToGeoJsonFeatureCollection(this ProjectUpdate projectUpdate)
        {
            return projectUpdate.ProjectUpdateBatch.ProjectLocationUpdates.ToGeoJsonFeatureCollection();
        }

        public static FeatureCollection SimpleLocationToGeoJsonFeatureCollection(this ProjectUpdate projectUpdate, bool addProjectProperties)
        {
            var featureCollection = new FeatureCollection();

            if ((projectUpdate.ProjectLocationSimpleType == ProjectLocationSimpleType.PointOnMap || projectUpdate.ProjectLocationSimpleType == ProjectLocationSimpleType.LatLngInput) && projectUpdate.ProjectLocationPoint != null)
            {
                featureCollection.Features.Add(DbGeometryToGeoJsonHelper.FromDbGeometry(projectUpdate.ProjectLocationPoint));
            }
            return featureCollection;
        }
    }
}