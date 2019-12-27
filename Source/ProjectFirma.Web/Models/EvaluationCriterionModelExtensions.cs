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

        public static int GetNumberOfEvaluationCriterionValues(this EvaluationCriterion evaluationCriterion)
        {
            return evaluationCriterion.EvaluationCriterionValues.Count;

        }
    }
}