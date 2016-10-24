using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.TransportationAssessment
{
    public class NewTransportationQuestionViewModel : FormViewModel
    {

        [Required]
        [DisplayName("Question Text")]
        [StringLength(TransportationQuestion.FieldLengths.TransportationQuestionText)]
        public string TransportationQuestionText { get; set; }

        [Required]
        [DisplayName("Associated Goal and Indicator")]
        public int TransportationSubGoalID { get; set; }
        
        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewTransportationQuestionViewModel()
        {
        }        
        
        public void UpdateModel(Models.TransportationQuestion transportationQuestion, Person currentPerson)
        {
            transportationQuestion.TransportationQuestionText = TransportationQuestionText;
            transportationQuestion.TransportationSubGoalID = TransportationSubGoalID;
        }
    }
}