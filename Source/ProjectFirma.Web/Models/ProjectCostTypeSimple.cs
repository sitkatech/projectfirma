namespace ProjectFirma.Web.Models
{
    public class ProjectCostTypeSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectCostTypeSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectCostTypeSimple(int ProjectCostTypeID, string ProjectCostTypeName, string ProjectCostTypeDisplayName, int sortOrder)
            : this()
        {
            this.ProjectCostTypeID = ProjectCostTypeID;
            this.ProjectCostTypeName = ProjectCostTypeName;
            this.ProjectCostTypeDisplayName = ProjectCostTypeDisplayName;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectCostTypeSimple(ProjectCostType ProjectCostType)
            : this()
        {
            this.ProjectCostTypeID = ProjectCostType.ProjectCostTypeID;
            this.ProjectCostTypeName = ProjectCostType.ProjectCostTypeName;
            this.ProjectCostTypeDisplayName = ProjectCostType.ProjectCostTypeDisplayName;
            this.SortOrder = ProjectCostType.SortOrder;
        }

        public int ProjectCostTypeID { get; set; }
        public string ProjectCostTypeName { get; set; }
        public string ProjectCostTypeDisplayName { get; set; }
        public int SortOrder { get; set; }
    }
}