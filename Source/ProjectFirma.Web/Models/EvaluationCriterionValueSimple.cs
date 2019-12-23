using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class EvaluationCriterionValueSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EvaluationCriterionValueSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EvaluationCriterionValueSimple(EvaluationCriterionValue evaluationCriterionValue) : this()
        {
            EvaluationCriterionValueID = evaluationCriterionValue.EvaluationCriterionValueID;
            EvaluationCriterionID = evaluationCriterionValue.EvaluationCriterionID;
            EvaluationCriterionValueRating = evaluationCriterionValue.EvaluationCriterionValueRating;
            EvaluationCriterionValueDescription = evaluationCriterionValue.EvaluationCriterionValueDescription;
            SortOrder = evaluationCriterionValue.SortOrder;
            HasAssociatedActuals = evaluationCriterionValue.HasDependentObjects();
        }

        public int EvaluationCriterionValueID { get; set; }
        public int EvaluationCriterionID { get; set; }
        public string EvaluationCriterionValueRating { get; set; }
        public string EvaluationCriterionValueDescription { get; set; }
        public int? SortOrder { get; set; }
        public bool HasAssociatedActuals { get; set; }
    }
}