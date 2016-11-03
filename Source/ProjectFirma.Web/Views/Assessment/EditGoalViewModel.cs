using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Assessment
{
    public class EditGoalViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Title")]
        [StringLength(AssessmentGoal.FieldLengths.AssessmentGoalTitle)]
        
        public string AssessmentGoalTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(AssessmentGoal.FieldLengths.AssessmentGoalDescription)]
        public string AssessmentGoalDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditGoalViewModel()
        {
        }

        public EditGoalViewModel(AssessmentGoal assessmentGoal)
        {
            AssessmentGoalDescription = assessmentGoal.AssessmentGoalDescription;
            AssessmentGoalTitle = assessmentGoal.AssessmentGoalTitle;
        }

        public void UpdateModel(AssessmentGoal assessmentGoal, Person currentPerson)
        {
            assessmentGoal.AssessmentGoalDescription = AssessmentGoalDescription;
            assessmentGoal.AssessmentGoalTitle = AssessmentGoalTitle;
        }
    }
}