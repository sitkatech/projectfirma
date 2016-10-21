using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;

namespace ProjectFirma.Web.Models
{
    public partial class ThresholdEvaluation
    {
        public const int CurrentThresholdEvaluationYear = 2015;
        public const int HistoricThresholdEvaluationYear = 2011;

        public static HtmlString MakeLegendIconLink()
        {
            var thresholdEvaluationLegendUrl = SitkaRoute<ThresholdEvaluationController>.BuildUrlFromExpression(c => c.ViewThresholdEvaluationLegend());
            return BootstrapHtmlHelpers.MakeModalDialogAlertLinkFromUrl(thresholdEvaluationLegendUrl,
                "Threshold Evaluation Legend",
                "Close",
                "<span class='glyphicon glyphicon-question-sign' style='margin-right: 3px;'></span>Legend",
                new List<string>(),
                null);
        }
    }
}