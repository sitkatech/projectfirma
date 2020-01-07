using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class EvaluationCriterionModelExtensions
    {
        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.EditEvaluationCriterion(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this EvaluationCriterion evaluationCriterion)
        {
            return EditUrlTemplate.ParameterReplace(evaluationCriterion.EvaluationCriterionID);
        }


        public static readonly UrlTemplate<int> DeleteUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.DeleteEvaluationCriterion(UrlTemplate.Parameter1Int)));
        public static string GetDeleteUrl(this EvaluationCriterion evaluationCriterion)
        {
            return DeleteUrlTemplate.ParameterReplace(evaluationCriterion.EvaluationCriterionID);
        }

        public static int GetNumberOfEvaluationCriterionValues(this EvaluationCriterion evaluationCriterion)
        {
            return evaluationCriterion.EvaluationCriterionValues.Count;
        }

    }
}