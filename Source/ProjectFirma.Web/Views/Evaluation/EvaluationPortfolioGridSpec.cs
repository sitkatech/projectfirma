using System.Linq;
using System.Web;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.AgGridWrappers;
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

            Add("delete", pe => MakeDeleteIconAndLinkBootstrapIfAvailable(currentFirmaSession, pe), 30, AgGridColumnFilterType.None);
            Add("edit", pe => MakeEditIconAndLinkBootstrapIfAvailable(currentFirmaSession, pe), 30, AgGridColumnFilterType.None);

            Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), a => a.Project.GetDisplayNameAsUrl(), 280, AgGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.ProjectStage.ToType().ToGridHeaderString(), a => a.Project.ProjectStage.GetProjectStageDisplayName(), 90, AgGridColumnFilterType.SelectFilterStrict);
            foreach (var evaluationCriteriaColumn in evaluation.EvaluationCriterias)
            {
                Add(evaluationCriteriaColumn.EvaluationCriteriaName, a => GetCriteriaValueIfAvailable(a, evaluationCriteriaColumn), 75, AgGridColumnFilterType.SelectFilterStrict);
            }
            Add("Comments", a => a.Comments, 150, AgGridColumnFilterType.Text);


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
                return AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(projectEvaluation.GetDeleteUrl(), true, projectEvaluation.CanDelete());
            }
            return new HtmlString(string.Empty);
        }

        private static HtmlString MakeEditIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, ProjectEvaluation projectEvaluation)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, projectEvaluation.Evaluation))
            {
                if (projectEvaluation.Evaluation.EvaluationStatusID == (int) EvaluationStatusEnum.InProgress)
                {
                    return AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(projectEvaluation.GetEditUrl(), $"Evaluate {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectEvaluation.Project.GetDisplayName()}'");
                }

                return AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(projectEvaluation.GetEditUrl(), $"Evaluate {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} '{projectEvaluation.Project.GetDisplayName()}'", false);

            }
            return new HtmlString(string.Empty);
        }
    }
}