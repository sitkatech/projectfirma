using System.ComponentModel.DataAnnotations;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectThresholdCategorySimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProposedProjectThresholdCategorySimple()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ProposedProjectThresholdCategorySimple(int proposedProjectThresholdCategoryID, int proposedProjectID, int thresholdCategoryID, string proposedProjectThresholdCategoryNotes)
            : this()
        {
            ProposedProjectThresholdCategoryID = proposedProjectThresholdCategoryID;
            ProposedProjectID = proposedProjectID;
            ThresholdCategoryID = thresholdCategoryID;
            ProposedProjectThresholdCategoryNotes = proposedProjectThresholdCategoryNotes;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public ProposedProjectThresholdCategorySimple(ProposedProjectThresholdCategory proposedProjectThresholdCategory)
            : this()
        {
            ProposedProjectThresholdCategoryID = proposedProjectThresholdCategory.ProposedProjectThresholdCategoryID;
            ProposedProjectID = proposedProjectThresholdCategory.ProposedProjectID;
            ThresholdCategoryID = proposedProjectThresholdCategory.ThresholdCategoryID;
            ProposedProjectThresholdCategoryNotes = proposedProjectThresholdCategory.ProposedProjectThresholdCategoryNotes;
        }

        public ProposedProjectThresholdCategorySimple(int thresholdCategoryID)
        {
            ThresholdCategoryID = thresholdCategoryID;
        }

        public int ProposedProjectThresholdCategoryID { get; set; }
        public int ProposedProjectID { get; set; }
        public int ThresholdCategoryID { get; set; }
        public string ProposedProjectThresholdCategoryNotes { get; set; }
        public bool Selected { get; set; }
        [StringLength(ProposedProjectThresholdCategory.FieldLengths.ProposedProjectThresholdCategoryNotes)]
        public string ProposedProjectThresholdCategoryNotesForBinding
        {
            get { return ProposedProjectThresholdCategoryNotes; }
            set { ProposedProjectThresholdCategoryNotes = value; }
        }
    }
}