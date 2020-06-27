namespace ProjectFirma.Web.Models
{
    public class GeospatialAreaIndexGridSimple
    {
        public int GeospatialAreaID { get; set; }
        public string GeospatialAreaShortName { get; set; }
        public int ProjectViewableByUserCount { get; set; }
        public GeospatialAreaIndexGridSimple()
        {
        }

        public GeospatialAreaIndexGridSimple(int geospatialAreaId, string geospatialAreaShortName, int projectViewableByUserCount)
        {
            GeospatialAreaID = geospatialAreaId;
            GeospatialAreaShortName = geospatialAreaShortName;
            ProjectViewableByUserCount = projectViewableByUserCount;
        }
    }
}