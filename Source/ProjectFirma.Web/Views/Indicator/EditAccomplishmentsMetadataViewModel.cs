using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public string DataSourceText { get; set; }
        
        [Url]
        public string DataSourceUrl { get; set; }

        public bool SwapChartAxes { get; set; }

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
            DataSourceText = indicator.DataSourceText;
            DataSourceUrl = indicator.DataSourceUrl;

            // We do not support swapping chart axes in EIP PMs; also non EIP Indicators only have one subcategory
            SwapChartAxes = !indicator.ReportedInEIP && indicator.IndicatorSubcategories.Single().SwapChartAxes.Value;
        }

        public void UpdateModel(Models.Indicator indicator, Person currentPerson)
        {
            indicator.ChartTitle = ChartTitle;
            indicator.ChartCaption = ChartCaption;
            indicator.DataSourceText = DataSourceText;
            indicator.ExternalDataSourceUrl = !indicator.ReportedInEIP ? DataSourceUrl : null;

            // We do not support swapping chart axes in EIP PMs; also non EIP Indicators only have one subcategory
            if (!indicator.ReportedInEIP)
            {
                indicator.IndicatorSubcategories.Single().SwapChartAxes = SwapChartAxes;
            }
        }
    }
}