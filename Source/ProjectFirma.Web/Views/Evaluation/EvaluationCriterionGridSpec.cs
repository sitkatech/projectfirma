using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Evaluation
{
    public class EvaluationCriterionGridSpec : GridSpec<ProjectFirmaModels.Models.EvaluationCriterion>
    {
        public EvaluationCriterionGridSpec(FirmaSession currentFirmaSession)
        {

            //Add("Name", a => UrlTemplate.MakeHrefString(a.GetDetailUrl(), a.EvaluationName), 220, DhtmlxGridColumnFilterType.Html);
            //Add("Definition", a => a.EvaluationDefinition, 220, DhtmlxGridColumnFilterType.Text);
            //Add("Status", a => a.GetEvaluationStatusDisplayName(), 75, DhtmlxGridColumnFilterType.SelectFilterStrict);
            //Add("Start Date", a => a.EvaluationStartDate.HasValue ? a.EvaluationStartDate.ToStringDate() : "not set", 70);
            //Add("End Date", a => a.EvaluationEndDate.HasValue ? a.EvaluationEndDate.ToStringDate() : "not set", 70);
            //Add("Criteria", a => a.GetEvaluationCriteriaNamesAsCommaDelimitedString(), 200, DhtmlxGridColumnFilterType.Text);
            //Add("Visibility", a => a.GetEvaluationVisibilityDisplayName(), 200, DhtmlxGridColumnFilterType.SelectFilterStrict);
        }
    }
}