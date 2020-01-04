using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectEvaluationModelExtensions
    {

        public static readonly UrlTemplate<int> EditUrlTemplate = new UrlTemplate<int>(SitkaRoute<EvaluationController>.BuildUrlFromExpression(t => t.EditProjectEvaluation(UrlTemplate.Parameter1Int)));
        public static string GetEditUrl(this ProjectEvaluation projectEvaluation)
        {
            return EditUrlTemplate.ParameterReplace(projectEvaluation.ProjectEvaluationID);
        }


        public static ProjectEvaluation GetOrCreateProjectEvaluation(Evaluation evaluation, Project project)
        {
            var thisProjectEvaluation = HttpRequestStorage.DatabaseEntities.ProjectEvaluations.SingleOrDefault(x => x.EvaluationID == evaluation.EvaluationID && x.ProjectID == project.ProjectID);
            if (thisProjectEvaluation == null)
            {
                thisProjectEvaluation = new ProjectEvaluation(project, evaluation);
            }

            return thisProjectEvaluation;
        }
    }
}