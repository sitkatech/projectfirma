using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdEvaluation
{
    public class EditImplementationAndEffectivenessViewModel : FormViewModel
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationProgramsAndActionsImplementedToImproveConditions)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.ProgramsAndActionsImplementedToImproveConditions)]
        public string ProgramsAndActionsImplementedToImproveConditions { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationEffectivenessOfProgramsAndActions)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.EffectivenessOfProgramsAndActions)]
        public string EffectivenessOfProgramsAndActions { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationInterimTarget)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.InterimTarget)]
        public string InterimTarget { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdEvaluationTargetAttainmentDate)]
        [StringLength(Models.ThresholdEvaluation.FieldLengths.TargetAttainmentDate)]
        public string TargetAttainmentDate { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditImplementationAndEffectivenessViewModel()
        {
        }

        public EditImplementationAndEffectivenessViewModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            ProgramsAndActionsImplementedToImproveConditions = thresholdEvaluation.ProgramsAndActionsImplementedToImproveConditions;
            EffectivenessOfProgramsAndActions = thresholdEvaluation.EffectivenessOfProgramsAndActions;
            InterimTarget = thresholdEvaluation.InterimTarget;
            TargetAttainmentDate = thresholdEvaluation.TargetAttainmentDate;
        }

        public void UpdateModel(Models.ThresholdEvaluation thresholdEvaluation)
        {
            thresholdEvaluation.ProgramsAndActionsImplementedToImproveConditions = ProgramsAndActionsImplementedToImproveConditions;
            thresholdEvaluation.EffectivenessOfProgramsAndActions = EffectivenessOfProgramsAndActions;
            thresholdEvaluation.InterimTarget = InterimTarget;
            thresholdEvaluation.TargetAttainmentDate = TargetAttainmentDate;
        }
    }
}