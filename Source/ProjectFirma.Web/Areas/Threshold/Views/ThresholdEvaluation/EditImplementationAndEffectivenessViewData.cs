using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Areas.Threshold.Controllers;
using ProjectFirma.Web.Views;
using LtInfo.Common;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditImplementationAndEffectivenessViewData : LakeTahoeInfoUserControlViewData
    {
        public readonly IEnumerable<SelectListItem> ThresholdEvaluationManagementStatusTypes;
        public readonly bool HasManagementOrPolicyStatementThresholdStandard;

        public EditImplementationAndEffectivenessViewData(IEnumerable<SelectListItem> thresholdEvaluationManagementStatusTypes, bool hasManagementOrPolicyStatementThresholdStandard)
        {
            ThresholdEvaluationManagementStatusTypes = thresholdEvaluationManagementStatusTypes;
            HasManagementOrPolicyStatementThresholdStandard = hasManagementOrPolicyStatementThresholdStandard;
        }
    }
}