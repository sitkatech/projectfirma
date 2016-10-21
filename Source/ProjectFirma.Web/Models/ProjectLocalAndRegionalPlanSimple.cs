namespace ProjectFirma.Web.Models
{
    public class ProjectLocalAndRegionalPlanSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectLocalAndRegionalPlanSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectLocalAndRegionalPlanSimple(int projectLocalAndRegionalPlanID, int projectID, int localAndRegionalPlanID) : this()
        {
            ProjectLocalAndRegionalPlanID = projectLocalAndRegionalPlanID;
            ProjectID = projectID;
            LocalAndRegionalPlanID = localAndRegionalPlanID;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectLocalAndRegionalPlanSimple(ProjectLocalAndRegionalPlan projectLocalAndRegionalPlan) : this()
        {
            ProjectLocalAndRegionalPlanID = projectLocalAndRegionalPlan.ProjectLocalAndRegionalPlanID;
            ProjectID = projectLocalAndRegionalPlan.ProjectID;
            LocalAndRegionalPlanID = projectLocalAndRegionalPlan.LocalAndRegionalPlanID;
        }

        public int ProjectLocalAndRegionalPlanID { get; set; }
        public int ProjectID { get; set; }
        public int LocalAndRegionalPlanID { get; set; }
    }
}