using System.Data.Entity.Spatial;
using GeoJSON.Net.Feature;
using LtInfo.Common.GeoJson;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectLocationAreaGroupType
    {
        public abstract string GetProjectLocationAreaName(ProjectLocationArea projectLocationArea);
        public abstract string GetProjectLocationAreaDisplayName(ProjectLocationArea projectLocationArea);
        public abstract LayerGeoJson GetLayerGeoJson(ProjectLocationArea projectLocationArea);
        public abstract DbGeometry GetGeometry(ProjectLocationArea projectLocationArea);

        protected LayerGeoJson GetGeoJsonImpl(DbGeometry geometry, string projectLocationAreaDisplayName)
        {
            var geoJsonFeatureCollection = new FeatureCollection();
            var feature = DbGeometryToGeoJsonHelper.FromDbGeometry(geometry);
            feature.Properties.Add("Project Location Area:", projectLocationAreaDisplayName);
            geoJsonFeatureCollection.Features.Add(feature);

            return new LayerGeoJson(projectLocationAreaDisplayName, geoJsonFeatureCollection, "Blue", 1m, LayerInitialVisibility.Show);
        }
    }

    public partial class ProjectLocationAreaGroupTypeMappedRegion
    {
        public override string GetProjectLocationAreaName(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.MappedRegion.RegionName;
        }

        public override string GetProjectLocationAreaDisplayName(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.MappedRegion.RegionDisplayName;
        }

        public override LayerGeoJson GetLayerGeoJson(ProjectLocationArea projectLocationArea)
        {
            return GetGeoJsonImpl(projectLocationArea.MappedRegion.RegionFeature, projectLocationArea.ProjectLocationAreaDisplayName);
        }

        public override DbGeometry GetGeometry(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.MappedRegion.RegionFeature;
        }
    }
    public partial class ProjectLocationAreaGroupTypeState
    {
        public override string GetProjectLocationAreaName(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.StateProvince.StateProvinceName;
        }

        public override string GetProjectLocationAreaDisplayName(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.StateProvince.StateProvinceName;
        }

        public override LayerGeoJson GetLayerGeoJson(ProjectLocationArea projectLocationArea)
        {
            return GetGeoJsonImpl(projectLocationArea.StateProvince.StateProvinceFeature, projectLocationArea.ProjectLocationAreaDisplayName);
        }

        public override DbGeometry GetGeometry(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.StateProvince.StateProvinceFeature;
        }
    }
    public partial class ProjectLocationAreaGroupTypeWatershed
    {
        public override string GetProjectLocationAreaName(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.Watershed.WatershedName;
        }

        public override string GetProjectLocationAreaDisplayName(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.Watershed.DisplayName;
        }

        public override LayerGeoJson GetLayerGeoJson(ProjectLocationArea projectLocationArea)
        {
            return GetGeoJsonImpl(projectLocationArea.Watershed.WatershedFeature, projectLocationArea.ProjectLocationAreaDisplayName);
        }

        public override DbGeometry GetGeometry(ProjectLocationArea projectLocationArea)
        {
            return projectLocationArea.Watershed.WatershedFeature;
        }
    }
}