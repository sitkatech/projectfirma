using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Views;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditManagementStatusViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> ThresholdEvaluationManagementStatusTypes;

        public EditManagementStatusViewData(IEnumerable<SelectListItem> thresholdEvaluationManagementStatusTypes)
        {
            ThresholdEvaluationManagementStatusTypes = thresholdEvaluationManagementStatusTypes;
        }
    }
}