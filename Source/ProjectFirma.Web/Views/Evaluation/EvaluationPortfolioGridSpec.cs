using System.Linq;
using System.Web;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EvaluationPortfolioGridSpec : GridSpec<ProjectEvaluation>
    {
        public EvaluationPortfolioGridSpec(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Evaluation evaluation)
        {

            Add(string.Empty, pe => MakeDeleteIconAndLinkBootstrapIfAvailable(currentFirmaSession, pe), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, pe => MakeEditIconAndLinkBootstrapIfAvailable(currentFirmaSession, pe), 30, DhtmlxGridColumnFilterType.None);

            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), a => a.Project.GetDisplayNameAsUrl(), 280, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), a => a.Project.ProjectStage.ProjectStageDisplayName, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            foreach (var evaluationCriterionColumn in evaluation.EvaluationCriterions)
            {
                Add(evaluationCriterionColumn.EvaluationCriterionName, a => GetCriterionValueIfAvailable(a, evaluationCriterionColumn), 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            Add("Comments", a => a.Comments, 150, DhtmlxGridColumnFilterType.Text);


        }

        private static HtmlString GetCriterionValueIfAvailable(ProjectEvaluation projectEvaluation, EvaluationCriterion evaluationCriterion)
        {
            var selectedValue = projectEvaluation.ProjectEvaluationSelectedValues.SingleOrDefault(x => x.EvaluationCriterionValue.EvaluationCriterionID == evaluationCriterion.EvaluationCriterionID);
            if (selectedValue != null)
            {
                return new HtmlString(selectedValue.EvaluationCriterionValue.EvaluationCriterionValueRating);
            }

            return new HtmlString("not set");
        }

        private static HtmlString MakeDeleteIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, ProjectEvaluation projectEvaluation)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, projectEvaluation.Evaluation))
            {
                return DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(projectEvaluation.GetDeleteUrl(), true, projectEvaluation.CanDelete());
            }
            return new HtmlString(string.Empty);
        }

        private static HtmlString MakeEditIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, ProjectEvaluation projectEvaluation)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, projectEvaluation.Evaluation))
            {
                if (projectEvaluation.Evaluation.EvaluationStatusID == (int) EvaluationStatusEnum.InProgress)
                {
                    return DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(projectEvaluation.GetEditUrl(), $"Evaluate {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectEvaluation.Project.GetDisplayName()}'");
                }

                return DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(projectEvaluation.GetEditUrl(), $"Evaluate {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectEvaluation.Project.GetDisplayName()}'", false);

            }
            return new HtmlString(string.Empty);
        }
    }
}