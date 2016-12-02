using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Assessment
{
    public class NewQuestionViewModel : FormViewModel
    {

        [Required]
        [DisplayName("Question Text")]
        [StringLength(AssessmentQuestion.FieldLengths.AssessmentQuestionText)]
        public string AssessmentQuestionText { get; set; }

        [Required]
        [DisplayName("Associated Goal and PerformanceMeasure")]
        public int AssessmentSubGoalID { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewQuestionViewModel()
        {
        }        
        
        public void UpdateModel(AssessmentQuestion question, Person currentPerson)
        {
            question.AssessmentQuestionText = AssessmentQuestionText;
            question.AssessmentSubGoalID = AssessmentSubGoalID;
        }
    }
}