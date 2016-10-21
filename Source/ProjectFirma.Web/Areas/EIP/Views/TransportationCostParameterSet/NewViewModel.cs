using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.TransportationCostParameterSet
{
    public class NewViewModel : FormViewModel
    {
        [Required]
        public int TransportationCostParameterSetID { get; set; }

        [StringLength(Models.TransportationCostParameterSet.FieldLengths.Comment)]
        [DisplayName("Comment")]
        public string Comment { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.TransportationGlobalInflationRate)]
        public Percentage InflationRate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.CurrentRTPYearForPVCalculations)]
        public int CurrentRTPYearForPVCalculations { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewViewModel()
        {
        }

        public NewViewModel(Models.TransportationCostParameterSet transportationCostParameterSet)
        {
            TransportationCostParameterSetID = transportationCostParameterSet.TransportationCostParameterSetID;
            InflationRate = transportationCostParameterSet.InflationRate;
            CurrentRTPYearForPVCalculations = transportationCostParameterSet.CurrentRTPYearForPVCalculations;
            Comment = transportationCostParameterSet.Comment;
        }
        
        public void UpdateModel(Models.TransportationCostParameterSet transportationCostParameterSet, Person currentPerson)
        {
            transportationCostParameterSet.InflationRate = InflationRate;
            transportationCostParameterSet.CurrentRTPYearForPVCalculations = CurrentRTPYearForPVCalculations;
            transportationCostParameterSet.Comment = Comment;
        }
    }
}