using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicator
{
    public class EditStandardsMetadataViewModel : FormViewModel
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ApplicableStandard)]
        public string ApplicableStandard { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.StandardNarrative)]
        public string StandardNarrative { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ThresholdStandardType)]
        public ThresholdStandardTypeEnum ThresholdStandardTypeEnum { get; set; }


        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditStandardsMetadataViewModel()
        {
        }

        public EditStandardsMetadataViewModel(Models.ThresholdIndicator thresholdIndicator)
        {
            ApplicableStandard = thresholdIndicator.ApplicableStandard;
            StandardNarrative = thresholdIndicator.StandardNarrative;
            ThresholdStandardTypeEnum = thresholdIndicator.ThresholdStandardType.ToEnum;
        }

        public void UpdateModel(Models.ThresholdIndicator thresholdIndicator)
        {
            thresholdIndicator.ApplicableStandard = ApplicableStandard;
            thresholdIndicator.StandardNarrative = StandardNarrative;
            thresholdIndicator.ThresholdStandardTypeID = (int) ThresholdStandardTypeEnum;
        }
    }
}