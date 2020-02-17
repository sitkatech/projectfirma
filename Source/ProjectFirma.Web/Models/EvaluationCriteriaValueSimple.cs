using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class EvaluationCriteriaValueSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EvaluationCriteriaValueSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EvaluationCriteriaValueSimple(EvaluationCriteriaValue evaluationCriteriaValue) : this()
        {
            EvaluationCriteriaValueID = evaluationCriteriaValue.EvaluationCriteriaValueID;
            EvaluationCriteriaID = evaluationCriteriaValue.EvaluationCriteriaID;
            EvaluationCriteriaValueRating = evaluationCriteriaValue.EvaluationCriteriaValueRating;
            EvaluationCriteriaValueDescription = evaluationCriteriaValue.EvaluationCriteriaValueDescription;
            SortOrder = evaluationCriteriaValue.SortOrder;
            HasAssociatedActuals = evaluationCriteriaValue.HasDependentObjects();
        }

        public int EvaluationCriteriaValueID { get; set; }
        public int EvaluationCriteriaID { get; set; }
        public string EvaluationCriteriaValueRating { get; set; }
        public string EvaluationCriteriaValueDescription { get; set; }
        public int? SortOrder { get; set; }
        public bool HasAssociatedActuals { get; set; }
    }
}