using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditManagementStatusViewModel : FormViewModel
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationManagementStatus)]
        public int? ThresholdEvaluationManagementStatusTypeID { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditManagementStatusViewModel()
        {
        }

        public EditManagementStatusViewModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            ThresholdEvaluationManagementStatusTypeID = thresholdEvaluation.ThresholdEvaluationManagementStatusTypeID;
        }

        public void UpdateModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            if (thresholdEvaluation.ThresholdIndicator.IsManagementOrPolicyStatement)
            {
                thresholdEvaluation.ThresholdEvaluationManagementStatusTypeID = ThresholdEvaluationManagementStatusTypeID;
            }
            else
            {
                thresholdEvaluation.ThresholdEvaluationManagementStatusTypeID = null;
            }
        }
    }
}