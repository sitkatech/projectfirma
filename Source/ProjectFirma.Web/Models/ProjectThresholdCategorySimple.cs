using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class ProjectThresholdCategorySimple
    {

        public int ProjectThresholdCategoryID { get; set; }
        public int ProjectID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public string ProjectThresholdCategoryNotes { get; set; }
        public bool Selected { get; set; }
        [StringLength(ProjectThresholdCategory.FieldLengths.ProjectThresholdCategoryNotes)]
        public string ProjectThresholdCategoryNotesForBinding
        {
            get { return ProjectThresholdCategoryNotes; }
            set { ProjectThresholdCategoryNotes = value; }
        }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectThresholdCategorySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectThresholdCategorySimple(int projectThresholdCategoryID, int projectID, int thresholdCategoryID, string projectThresholdCategoryNotes)
            : this()
        {
            ProjectThresholdCategoryID = projectThresholdCategoryID;
            ProjectID = projectID;
            ThresholdCategoryID = thresholdCategoryID;
            ProjectThresholdCategoryNotes = projectThresholdCategoryNotes;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectThresholdCategorySimple(ProjectThresholdCategory projectThresholdCategory)
            : this()
        {
            ProjectThresholdCategoryID = projectThresholdCategory.ProjectThresholdCategoryID;
            ProjectID = projectThresholdCategory.ProjectID;
            ThresholdCategoryID = projectThresholdCategory.ThresholdCategoryID;
        }
        
    }
}