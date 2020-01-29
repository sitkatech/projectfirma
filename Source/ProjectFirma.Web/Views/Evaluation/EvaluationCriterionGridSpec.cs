using System.Web;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EvaluationCriterionGridSpec : GridSpec<EvaluationCriterion>
    {
        public EvaluationCriterionGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, ec => MakeDeleteIconAndLinkBootstrapIfAvailable(currentFirmaSession, ec), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, ec => MakeEditIconAndLinkBootstrapIfAvailable(currentFirmaSession, ec), 30, DhtmlxGridColumnFilterType.None);

            Add("Name", a => a.EvaluationCriterionName, 170, DhtmlxGridColumnFilterType.Text);
            Add("Definition", a => a.EvaluationCriterionDefinition, 170, DhtmlxGridColumnFilterType.Text);
            Add("Number of Criterion Values", a => a.GetNumberOfEvaluationCriterionValues().ToString(), 70, DhtmlxGridColumnFilterType.SelectFilterStrict);

        }

        private static HtmlString MakeDeleteIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, EvaluationCriterion evaluationCriterion)
        {
            if (EvaluationCriterionManageFeature.HasEvaluationCriterionManagePermission(currentFirmaSession, evaluationCriterion))
            {
                return DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(evaluationCriterion.GetDeleteUrl(), true, evaluationCriterion.CanDelete());
            }
            return new HtmlString(string.Empty);
        }

        private static HtmlString MakeEditIconAndLinkBootstrapIfAvailable(FirmaSession currentFirmaSession, EvaluationCriterion evaluationCriterion)
        {
            if (EvaluationManageFeature.HasEvaluationManagePermission(currentFirmaSession, evaluationCriterion.Evaluation))
            {
                string linkTitleText = $"Edit {FieldDefinitionEnum.EvaluationCriteria.ToType().GetFieldDefinitionLabel()} '{evaluationCriterion.EvaluationCriterionName}'";
                string editDialogUrl = evaluationCriterion.GetEditUrl();
                return DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(editDialogUrl, linkTitleText);
            }
            return new HtmlString(string.Empty);
        }
    }
}