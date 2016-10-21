using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationAssessment
{
    public class EditTransportationSubGoalViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Title")]
        [StringLength(TransportationSubGoal.FieldLengths.TransportationSubGoalTitle)]
        
        public string TransportationSubGoalTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(TransportationSubGoal.FieldLengths.TransportationSubGoalDescription)]
        public string TransportationSubGoalDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTransportationSubGoalViewModel()
        {
        }

        public EditTransportationSubGoalViewModel(TransportationSubGoal transportationSubGoal)
        {
            TransportationSubGoalDescription = transportationSubGoal.TransportationSubGoalDescription;
            TransportationSubGoalTitle = transportationSubGoal.TransportationSubGoalTitle;
        }

        public void UpdateModel(TransportationSubGoal transportationSubGoal, Person currentPerson)
        {
            transportationSubGoal.TransportationSubGoalDescription = TransportationSubGoalDescription;
            transportationSubGoal.TransportationSubGoalTitle = TransportationSubGoalTitle;
        }
    }
}