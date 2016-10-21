using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class ViewThresholdEvaluationLegendViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly List<ThresholdEvaluationManagementStatusType> ThresholdEvaluationManagementStatusTypes;

        public ViewThresholdEvaluationLegendViewData()
        {
            ThresholdEvaluationManagementStatusTypes = ThresholdEvaluationManagementStatusType.All.ToList();
        }

    }
}