using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Assessment
{
    public class EditSubGoalViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Title")]
        [StringLength(AssessmentSubGoal.FieldLengths.AssessmentSubGoalTitle)]
        
        public string AssessmentSubGoalTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(AssessmentSubGoal.FieldLengths.AssessmentSubGoalDescription)]
        public string AssessmentSubGoalDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditSubGoalViewModel()
        {
        }

        public EditSubGoalViewModel(AssessmentSubGoal assessmentSubGoal)
        {
            AssessmentSubGoalDescription = assessmentSubGoal.AssessmentSubGoalDescription;
            AssessmentSubGoalTitle = assessmentSubGoal.AssessmentSubGoalTitle;
        }

        public void UpdateModel(AssessmentSubGoal assessmentSubGoal, Person currentPerson)
        {
            assessmentSubGoal.AssessmentSubGoalDescription = AssessmentSubGoalDescription;
            assessmentSubGoal.AssessmentSubGoalTitle = AssessmentSubGoalTitle;
        }
    }
}