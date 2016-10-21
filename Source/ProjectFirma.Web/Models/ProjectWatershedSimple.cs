namespace ProjectFirma.Web.Models
{
    public class ProjectWatershedSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectWatershedSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectWatershedSimple(int projectWatershedID, int projectID, int watershedID)
            : this()
        {
            ProjectWatershedID = projectWatershedID;
            ProjectID = projectID;
            WatershedID = watershedID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectWatershedSimple(ProjectWatershed projectWatershed)
            : this()
        {
            ProjectWatershedID = projectWatershed.ProjectWatershedID;
            ProjectID = projectWatershed.ProjectID;
            WatershedID = projectWatershed.WatershedID;
        }

        public int ProjectWatershedID { get; set; }
        public int ProjectID { get; set; }
        public int WatershedID { get; set; }
    }
}