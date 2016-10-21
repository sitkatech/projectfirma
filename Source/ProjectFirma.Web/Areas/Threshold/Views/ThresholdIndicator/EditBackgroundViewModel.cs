using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicator
{
    public class EditBackgroundViewModel : FormViewModel
    {
        [FieldDefinitionDisplay(FieldDefinitionEnum.Relevance)]
        public string Relevance { get; set; }

        [FieldDefinitionDisplay(FieldDefinitionEnum.HumanAndEnvironmentalDrivers)]
        public string HumanAndEnvironmentalDrivers { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditBackgroundViewModel()
        {
        }

        public EditBackgroundViewModel(Models.ThresholdIndicator thresholdIndicator)
        {
            Relevance = thresholdIndicator.Relevance;
            HumanAndEnvironmentalDrivers = thresholdIndicator.HumanAndEnvironmentalDrivers;
        }

        public void UpdateModel(Models.ThresholdIndicator thresholdIndicator)
        {
            thresholdIndicator.Relevance = Relevance;
            thresholdIndicator.HumanAndEnvironmentalDrivers = HumanAndEnvironmentalDrivers;
        }
    }
}