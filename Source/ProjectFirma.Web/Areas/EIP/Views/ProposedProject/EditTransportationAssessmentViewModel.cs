using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ApprovalUtilities.Utilities;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class EditTransportationAssessmentViewModel : FormViewModel, IValidatableObject
    {
        public List<ProposedProjectTransportationQuestionSimple> ProposedProjectTransportationQuestionSimples { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTransportationAssessmentViewModel()
        {
            
        }

       public EditTransportationAssessmentViewModel(List<ProposedProjectTransportationQuestionSimple> proposedProjectTransportationQuestionSimples)
        {
            ProposedProjectTransportationQuestionSimples = proposedProjectTransportationQuestionSimples;
        }   
 

        public void UpdateModel(Models.ProposedProject proposedProject)
        {

            HttpRequestStorage.DatabaseEntities.ProposedProjectTransportationQuestions.RemoveRange(proposedProject.ProposedProjectTransportationQuestions);

            foreach (var simple in ProposedProjectTransportationQuestionSimples)
            {
                proposedProject.ProposedProjectTransportationQuestions.Add(new ProposedProjectTransportationQuestion(simple));
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