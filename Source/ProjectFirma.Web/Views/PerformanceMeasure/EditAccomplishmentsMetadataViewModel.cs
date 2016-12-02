using System.ComponentModel.DataAnnotations;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class EditAccomplishmentsMetadataViewModel : FormViewModel
    {
        [Required]
        [StringLength(Models.PerformanceMeasure.FieldLengths.ChartTitle)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PerformanceMeasureChartTitle)]
        public string ChartTitle { get; set; }

        [StringLength(Models.PerformanceMeasure.FieldLengths.ChartCaption)]
        [FieldDefinitionDisplay(FieldDefinitionEnum.PerformanceMeasureChartCaption)]
        public string ChartCaption { get; set; }

        /// <summary>
        /// Needed by the ModelBinder
        /// </summary>
        public EditAccomplishmentsMetadataViewModel()
        {
        }

        public EditAccomplishmentsMetadataViewModel(Models.PerformanceMeasure performanceMeasure)
        {
            ChartTitle = performanceMeasure.ChartTitle;
            ChartCaption = performanceMeasure.ChartCaption;
        }

        public void UpdateModel(Models.PerformanceMeasure performanceMeasure, Person currentPerson)
        {
            performanceMeasure.ChartTitle = ChartTitle;
            performanceMeasure.ChartCaption = ChartCaption;
        }
    }
}