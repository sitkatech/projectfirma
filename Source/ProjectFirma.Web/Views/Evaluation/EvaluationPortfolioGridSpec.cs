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
            foreach (var evaluationCriteriaColumn in evaluation.EvaluationCriterias)
            {
                Add(evaluationCriteriaColumn.EvaluationCriteriaName, a => GetCriteriaValueIfAvailable(a, evaluationCriteriaColumn), 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            }
            Add("Comments", a => a.Comments, 150, DhtmlxGridColumnFilterType.Text);


        }

        private static HtmlString GetCriteriaValueIfAvailable(ProjectEvaluation projectEvaluation, EvaluationCriteria evaluationCriteria)
        {
            var selectedValue = projectEvaluation.ProjectEvaluationSelectedValues.SingleOrDefault(x => x.EvaluationCriteriaValue.EvaluationCriteriaID == evaluationCriteria.EvaluationCriteriaID);
            if (selectedValue != null)
            {
                return new HtmlString(selectedValue.EvaluationCriteriaValue.EvaluationCriteriaValueRating);
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