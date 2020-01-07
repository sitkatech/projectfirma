using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class EvaluationCriterionSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EvaluationCriterionSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EvaluationCriterionSimple(EvaluationCriterion evaluationCriterion) : this()
        {
            EvaluationCriterionID = evaluationCriterion.EvaluationCriterionID;
            EvaluationID = evaluationCriterion.EvaluationID;
            EvaluationCriterionName = evaluationCriterion.EvaluationCriterionName;
            EvaluationCriterionDefinition = evaluationCriterion.EvaluationCriterionDefinition;
            EvaluationCriterionValueSimples = evaluationCriterion.EvaluationCriterionValues.Select(x => new EvaluationCriterionValueSimple(x)).ToList();
        }

        public int EvaluationCriterionID { get; set; }
        public int EvaluationID { get; set; }
        public string EvaluationCriterionName { get; set; }
        public string EvaluationCriterionDefinition { get; set; }
        public List<EvaluationCriterionValueSimple> EvaluationCriterionValueSimples { get; set; }
    }
}