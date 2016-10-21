using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationAssessment
{
    public class EditTransportationQuestionViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Question Text")]
        [StringLength(TransportationQuestion.FieldLengths.TransportationQuestionText)]        
        public string TransportationQuestionText { get; set; }

        [DisplayName("Archive Question?")]
        public bool Archive { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTransportationQuestionViewModel()
        {
        }

        public EditTransportationQuestionViewModel(TransportationQuestion transportationQuestion)
        {
            TransportationQuestionText = transportationQuestion.TransportationQuestionText;
            Archive = transportationQuestion.ArchiveDate.HasValue;
        }

        public void UpdateModel(TransportationQuestion transportationQuestion, Person currentPerson)
        {
            transportationQuestion.TransportationQuestionText = TransportationQuestionText;
            transportationQuestion.ArchiveDate = Archive ? DateTime.Now : (DateTime?) null;
        }
    }
}