using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class EditAssessmentViewModel : FormViewModel, IValidatableObject
    {
        public List<ProposedProjectAssessmentQuestionSimple> ProposedProjectAssessmentQuestionSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAssessmentViewModel()
        {
            
        }

       public EditAssessmentViewModel(List<ProposedProjectAssessmentQuestionSimple> proposedProjectAssessmentQuestionSimples)
        {
            ProposedProjectAssessmentQuestionSimples = proposedProjectAssessmentQuestionSimples;
        }   
 

        public void UpdateModel(Models.ProposedProject proposedProject)
        {

            HttpRequestStorage.DatabaseEntities.ProposedProjectAssessmentQuestions.DeleteProposedProjectAssessmentQuestion(proposedProject.ProposedProjectAssessmentQuestions);

            foreach (var simple in ProposedProjectAssessmentQuestionSimples)
            {
                proposedProject.ProposedProjectAssessmentQuestions.Add(new ProposedProjectAssessmentQuestion(simple));
            }                       
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return GetValidationResults();
        }

        public IEnumerable<ValidationResult> GetValidationResults()
        {
            var validationResults = new List<ValidationResult>();

            //Validate here!

            return validationResults;
        }
    }
}