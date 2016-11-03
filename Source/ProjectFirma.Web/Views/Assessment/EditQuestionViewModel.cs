using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Assessment
{
    public class EditQuestionViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Question Text")]
        [StringLength(AssessmentQuestion.FieldLengths.AssessmentQuestionText)]        
        public string AssessmentQuestionText { get; set; }

        [DisplayName("Archive Question?")]
        public bool Archive { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditQuestionViewModel()
        {
        }

        public EditQuestionViewModel(AssessmentQuestion assessmentQuestion)
        {
            AssessmentQuestionText = assessmentQuestion.AssessmentQuestionText;
            Archive = assessmentQuestion.ArchiveDate.HasValue;
        }

        public void UpdateModel(AssessmentQuestion assessmentQuestion, Person currentPerson)
        {
            assessmentQuestion.AssessmentQuestionText = AssessmentQuestionText;
            assessmentQuestion.ArchiveDate = Archive ? DateTime.Now : (DateTime?) null;
        }
    }
}