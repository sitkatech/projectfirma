using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectClassificationSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProposedProjectClassificationSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectClassificationSimple(int proposedProjectClassificationID, int proposedProjectID, int classificationID, string proposedProjectClassificationNotes)
            : this()
        {
            ProposedProjectClassificationID = proposedProjectClassificationID;
            ProposedProjectID = proposedProjectID;
            ClassificationID = classificationID;
            ProposedProjectClassificationNotes = proposedProjectClassificationNotes;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProposedProjectClassificationSimple(ProposedProjectClassification proposedProjectClassification)
            : this()
        {
            ProposedProjectClassificationID = proposedProjectClassification.ProposedProjectClassificationID;
            ProposedProjectID = proposedProjectClassification.ProposedProjectID;
            ClassificationID = proposedProjectClassification.ClassificationID;
            ProposedProjectClassificationNotes = proposedProjectClassification.ProposedProjectClassificationNotes;
        }

        public ProposedProjectClassificationSimple(int classificationID)
        {
            ClassificationID = classificationID;
        }

        public int ProposedProjectClassificationID { get; set; }
        public int ProposedProjectID { get; set; }
        public int ClassificationID { get; set; }
        public string ProposedProjectClassificationNotes { get; set; }
        public bool Selected { get; set; }
        [StringLength(ProposedProjectClassification.FieldLengths.ProposedProjectClassificationNotes)]
        public string ProposedProjectClassificationNotesForBinding
        {
            get { return ProposedProjectClassificationNotes; }
            set { ProposedProjectClassificationNotes = value; }
        }
    }
}