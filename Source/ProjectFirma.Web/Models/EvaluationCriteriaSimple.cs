using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class EvaluationCriteriaSimple
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public EvaluationCriteriaSimple()
        {
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public EvaluationCriteriaSimple(EvaluationCriteria evaluationCriteria) : this()
        {
            EvaluationCriteriaID = evaluationCriteria.EvaluationCriteriaID;
            EvaluationID = evaluationCriteria.EvaluationID;
            EvaluationCriteriaName = evaluationCriteria.EvaluationCriteriaName;
            EvaluationCriteriaDefinition = evaluationCriteria.EvaluationCriteriaDefinition;
            EvaluationCriteriaDefinitionUrl = evaluationCriteria.GetDefinitionUrl();
            EvaluationCriteriaValueSimples = evaluationCriteria.EvaluationCriteriaValues.Select(x => new EvaluationCriteriaValueSimple(x)).ToList();
        }

        public int EvaluationCriteriaID { get; set; }
        public int EvaluationID { get; set; }
        public string EvaluationCriteriaName { get; set; }
        public string EvaluationCriteriaDefinition { get; set; }
        public string EvaluationCriteriaDefinitionUrl { get; set; }
        public List<EvaluationCriteriaValueSimple> EvaluationCriteriaValueSimples { get; set; }
    }
}