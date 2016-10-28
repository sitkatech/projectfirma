using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Indicator
{
    public class EditAccomplishmentsMetadataViewModel : FormViewModel
    {
        [Required]
        [StringLength(Models.Indicator.FieldLengths.ChartTitle)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ChartTitle)]
        public string ChartTitle { get; set; }

        [StringLength(Models.Indicator.FieldLengths.ChartCaption)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.ChartCaption)]
        public string ChartCaption { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAccomplishmentsMetadataViewModel()
        {
        }

        public EditAccomplishmentsMetadataViewModel(Models.Indicator indicator)
        {
            ChartTitle = indicator.ChartTitle;
            ChartCaption = indicator.ChartCaption;
        }

        public void UpdateModel(Models.Indicator indicator, Person currentPerson)
        {
            indicator.ChartTitle = ChartTitle;
            indicator.ChartCaption = ChartCaption;
        }
    }
}