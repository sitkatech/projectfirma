using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Areas.Threshold.Views.ThresholdIndicatorImage
{
    public class EditViewModel : FormViewModel
    {
        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCaption)]
        [StringLength(ProjectImage.FieldLengths.Caption)]
        public string Caption { get; set; }

        [Required]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PhotoCredit)]
        [StringLength(ProjectImage.FieldLengths.Credit)]
        public string Credit { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditViewModel()
        {
        }

        public EditViewModel(Models.ThresholdIndicatorImage thresholdIndicatorImage)
        {
            Caption = thresholdIndicatorImage.Caption;
            Credit = thresholdIndicatorImage.Credit;
        }

        public virtual void UpdateModel(Models.ThresholdIndicatorImage thresholdIndicatorImage, Person person)
        {
            thresholdIndicatorImage.Caption = Caption;
            thresholdIndicatorImage.Credit = Credit;
        }
    }
}