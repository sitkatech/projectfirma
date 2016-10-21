using ProjectFirma.Web.Models;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Areas.EIP.Views.Map
{
    public class ProjectLocationsMapInitJson : MapInitJson
    {
        private const int DefaultZoomLevel = 10;
        public readonly ProjectMapCustomization ProjectMapCustomization;
        public readonly LayerGeoJson ProjectLocationsLayerGeoJson;
        public readonly LayerGeoJson NamedAreasAsPointsLayerGeoJson;

        public ProjectLocationsMapInitJson(LayerGeoJson projectLocationsLayerGeoJson, LayerGeoJson namedAreasAsPointsLayerGeoJson, ProjectMapCustomization customization, string mapDivID)
            : base(mapDivID, DefaultZoomLevel, GetWatershedAndJurisdictionMapLayers(), BoundingBox.MakeNewDefaultBoundingBox())
        {
            ProjectMapCustomization = customization;
            ProjectLocationsLayerGeoJson = projectLocationsLayerGeoJson;
            NamedAreasAsPointsLayerGeoJson = namedAreasAsPointsLayerGeoJson;
        }
    }
}