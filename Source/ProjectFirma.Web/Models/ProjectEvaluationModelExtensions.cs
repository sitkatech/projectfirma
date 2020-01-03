using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ProjectEvaluationModelExtensions
    {


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