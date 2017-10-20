using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ClosedXML.Excel;
using LtInfo.Common.ExcelWorkbookUtilities;
using LtInfo.Common.Models;
using Newtonsoft.Json;
using ProjectFirma.Web.Views.Shared;

namespace ProjectFirma.Web.Views.PerformanceMeasure
{
    public class DownloadChartDataViewModel : FormViewModel
    {
        [DisplayName("Google Chart Jsons"), Required]
        public List<string> GoogleChartJsons { get; set; }

        [DisplayName("Chart Name"), Required]
        public string ExcelFilename { get; set; }

        [DisplayName("Main Column Label"), Required]
        public string MainColumnLabel { get; set; }

        public delegate IExcelWorkbookSheetDescriptor GoogleChartJsonToExcelWorkbookSheetDescriptor(GoogleChartJson googleChartJson);

        public XLWorkbook GetExcelWorkbook(GoogleChartJsonToExcelWorkbookSheetDescriptor googleChartJsonToExcelWorkbookSheetDescriptor)
        {
            return new ExcelWorkbookMaker(GoogleChartJsons.Select(JsonConvert.DeserializeObject<GoogleChartJson>)
                .ToList()
                .Select(x => googleChartJsonToExcelWorkbookSheetDescriptor(x))
                .OrderBy(x => x.WorksheetName)
                .ToList()).ToXLWorkbook();
        }
    }
}