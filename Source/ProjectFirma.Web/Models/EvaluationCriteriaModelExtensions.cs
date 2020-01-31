using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class EvaluationCriteriaModelExtensions
    {
        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.EditEvaluationCriteria(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this EvaluationCriteria evaluationCriteria)
        {
            return EditUrlTemplate.ParameterReplace(evaluationCriteria.EvaluationCriteriaID);
        }


        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.DeleteEvaluationCriteria(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this EvaluationCriteria evaluationCriteria)
        {
            return DeleteUrlTemplate.ParameterReplace(evaluationCriteria.EvaluationCriteriaID);
        }

        public static readonly UrlTemplate<int> DefinitionUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.EvaluationCriteriaDefinition(UrlTemplate.Parameter1Int)));
        public static string GetDefinitionUrl(this EvaluationCriteria evaluationCriteria)
        {
            return DefinitionUrlTemplate.ParameterReplace(evaluationCriteria.EvaluationCriteriaID);
        }

        public static int GetNumberOfEvaluationCriteriaValues(this EvaluationCriteria evaluationCriteria)
        {
            return evaluationCriteria.EvaluationCriteriaValues.Count;
        }

    }
}