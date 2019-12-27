using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EvaluationCriterionGridSpec : GridSpec<ProjectFirmaModels.Models.EvaluationCriterion>
    {
        public EvaluationCriterionGridSpec(FirmaSession currentFirmaSession)
        {

            Add("Name", a => a.EvaluationCriterionName, 220, DhtmlxGridColumnFilterType.Text);
            Add("Definition", a => a.EvaluationCriterionDefinition, 220, DhtmlxGridColumnFilterType.Text);
            Add("Number of Criterion Values", a => a.GetNumberOfEvaluationCriterionValues().ToString(), 40, DhtmlxGridColumnFilterType.SelectFilterStrict);

        }
    }
}