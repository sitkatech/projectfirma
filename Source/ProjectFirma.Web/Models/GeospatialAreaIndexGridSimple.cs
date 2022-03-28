namespace ProjectFirma.Web.Models
{
    public class GeospatialAreaIndexGridSimple
    {
        public int GeospatialAreaID { get; set; }
        public string GeospatialAreaShortName { get; set; }
        public int ProjectViewableByUserCount { get; set; }
        public string LayerColor { get; set; }
        public GeospatialAreaIndexGridSimple()
        {
        }

        public GeospatialAreaIndexGridSimple(int geospatialAreaId, string geospatialAreaShortName, int projectViewableByUserCount, string layerColor)
        {
            GeospatialAreaID = geospatialAreaId;
            GeospatialAreaShortName = geospatialAreaShortName;
            ProjectViewableByUserCount = projectViewableByUserCount;
            LayerColor = layerColor;
        }

        public string GetGeospatialAreaShortNameWithColor()
        {
            return string.IsNullOrWhiteSpace(LayerColor) ? GeospatialAreaShortName : $"<span style=\"vertical-align:middle; width:10px; height:10px; margin-right:5px; display:inline-block; background:{LayerColor};\"></span>{GeospatialAreaShortName}";
        }
    }
}