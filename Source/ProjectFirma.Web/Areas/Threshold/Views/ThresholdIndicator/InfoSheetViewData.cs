using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Areas.Threshold.Views.ThresholdCategory;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Indicator;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicator
{
    public class InfoSheetViewData : ThresholdViewData
    {
        public readonly Models.ThresholdEvaluation ThresholdEvaluation;
        public readonly IndicatorRelationshipsViewData IndicatorRelationshipsViewData;
        public readonly IndicatorChartViewData IndicatorChartViewData;
        public readonly string IndexUrl;
        public readonly ImageGalleryViewData ImageGalleryViewData;

        public InfoSheetViewData(Person currentPerson, Models.ThresholdEvaluation thresholdEvaluation, IndicatorRelationshipsViewData indicatorRelationshipsViewData, IndicatorChartViewData indicatorChartViewData, ImageGalleryViewData imageGalleryViewData)
            : base(currentPerson)
        {
            HtmlPageTitle = string.Format("{0}", thresholdEvaluation.ThresholdIndicatorID);
            BreadCrumbTitle = "Info Sheet";
            PageTitle = string.Format("{0} Threshold Evaluation", thresholdEvaluation.ThresholdEvaluationPeriod.ThresholdEvaluationYear);

            ThresholdEvaluation = thresholdEvaluation;
            IndicatorRelationshipsViewData = indicatorRelationshipsViewData;
            IndicatorChartViewData = indicatorChartViewData;
            ImageGalleryViewData = imageGalleryViewData;

            IndexUrl = SitkaRoute<ThresholdCategoryController>.BuildUrlFromExpression(x => x.Index());           
        }
    }
}