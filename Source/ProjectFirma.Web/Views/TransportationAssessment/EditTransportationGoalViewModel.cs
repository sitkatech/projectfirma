using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.TransportationAssessment
{
    public class EditTransportationGoalViewModel : FormViewModel
    {
        [Required]
        [DisplayName("Title")]
        [StringLength(TransportationGoal.FieldLengths.TransportationGoalTitle)]
        
        public string TransportationGoalTitle { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(TransportationGoal.FieldLengths.TransportationGoalDescription)]
        public string TransportationGoalDescription { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditTransportationGoalViewModel()
        {
        }

        public EditTransportationGoalViewModel(TransportationGoal transportationGoal)
        {
            TransportationGoalDescription = transportationGoal.TransportationGoalDescription;
            TransportationGoalTitle = transportationGoal.TransportationGoalTitle;
        }

        public void UpdateModel(TransportationGoal transportationGoal, Person currentPerson)
        {
            transportationGoal.TransportationGoalDescription = TransportationGoalDescription;
            transportationGoal.TransportationGoalTitle = TransportationGoalTitle;
        }
    }
}