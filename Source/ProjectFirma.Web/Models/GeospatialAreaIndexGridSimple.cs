namespace ProjectFirma.Web.Models
{
    public class GeospatialAreaIndexGridSimple
    {
        public int GeospatialAreaID { get; set; }
        public string GeospatialAreaName { get; set; }
        public int ProjectViewableByUserCount { get; set; }

        public GeospatialAreaIndexGridSimple(int geospatialAreaId, string geospatialAreaName, int projectViewableByUserCount)
        {
            GeospatialAreaID = geospatialAreaId;
            GeospatialAreaName = geospatialAreaName;
            ProjectViewableByUserCount = projectViewableByUserCount;
        }
    }
}