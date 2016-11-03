using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.CostParameterSet
{
    public class NewViewModel : FormViewModel
    {
        [Required]
        public int CostParameterSetID { get; set; }

        [StringLength(Models.CostParameterSet.FieldLengths.Comment)]
        [DisplayName("Comment")]
        public string Comment { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.GlobalInflationRate)]
        public Percentage InflationRate { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.CurrentYearForPVCalculations)]
        public int CurrentYearForPVCalculations { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public NewViewModel()
        {
        }

        public NewViewModel(Models.CostParameterSet costParameterSet)
        {
            CostParameterSetID = costParameterSet.CostParameterSetID;
            InflationRate = costParameterSet.InflationRate;
            CurrentYearForPVCalculations = costParameterSet.CurrentYearForPVCalculations;
            Comment = costParameterSet.Comment;
        }
        
        public void UpdateModel(Models.CostParameterSet costParameterSet, Person currentPerson)
        {
            costParameterSet.InflationRate = InflationRate;
            costParameterSet.CurrentYearForPVCalculations = CurrentYearForPVCalculations;
            costParameterSet.Comment = Comment;
        }
    }
}