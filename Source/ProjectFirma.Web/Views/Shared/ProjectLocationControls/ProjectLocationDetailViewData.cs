using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationDetailViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly int ProjectID;
        public readonly MapInitJson MapInitJson;
        public readonly LayerGeoJson EditableLayerGeoJson;
        public readonly string UploadGisFileUrl;
        public readonly string MapFormID;
        public readonly string SaveFeatureCollectionUrl;
        public readonly int AnnotationMaxLength;

        public ProjectLocationDetailViewData(int projectID, MapInitJson mapInitJson, LayerGeoJson editableLayerGeoJson, string uploadGisFileUrl, string mapFormID, string saveFeatureCollectionUrl, int annotationMaxLength)
        {
            ProjectID = projectID;
            MapInitJson = mapInitJson;
            EditableLayerGeoJson = editableLayerGeoJson;
            UploadGisFileUrl = uploadGisFileUrl;
            MapFormID = mapFormID;
            SaveFeatureCollectionUrl = saveFeatureCollectionUrl;
            AnnotationMaxLength = annotationMaxLength;
        }
    }
}