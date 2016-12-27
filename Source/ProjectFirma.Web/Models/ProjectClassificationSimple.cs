using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class ProjectClassificationSimple
    {

        public int ProjectClassificationID { get; set; }
        public int ProjectID { get; set; }
        public int ClassificationID { get; set; }
        public string ProjectClassificationNotes { get; set; }
        public bool Selected { get; set; }
        [StringLength(ProjectClassification.FieldLengths.ProjectClassificationNotes)]
        public string ProjectClassificationNotesForBinding
        {
            get { return ProjectClassificationNotes; }
            set { ProjectClassificationNotes = value; }
        }

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectClassificationSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProjectClassificationSimple(int projectClassificationID, int projectID, int classificationID, string projectClassificationNotes)
            : this()
        {
            ProjectClassificationID = projectClassificationID;
            ProjectID = projectID;
            ClassificationID = classificationID;
            ProjectClassificationNotes = projectClassificationNotes;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProjectClassificationSimple(ProjectClassification projectClassification)
            : this()
        {
            ProjectClassificationID = projectClassification.ProjectClassificationID;
            ProjectID = projectClassification.ProjectID;
            ClassificationID = projectClassification.ClassificationID;
        }
        
    }
}