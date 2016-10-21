using GeoJSON.Net.Feature;

namespace ProjectFirma.Web.Models
{
    public interface IProjectLocationStaging
    {
        int PrimaryKey { get; }
        int PersonID { get; set; }
        string FeatureClassName { get; set; }
        string GeoJson { get; set; }
        string SelectedProperty { get; set; }
        bool ShouldImport { get; set; }
        FeatureCollection ToGeoJsonFeatureCollection();
    }
}