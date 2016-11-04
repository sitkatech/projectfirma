using System.Collections.Generic;
using ClosedXML.Excel;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    public class ExcelWorkbookMaker
    {
        private readonly List<IExcelWorkbookSheetDescriptor> _worksheetsSheetDescriptors;

        public ExcelWorkbookMaker(List<IExcelWorkbookSheetDescriptor> worksheetsSheetDescriptors)
        {
            _worksheetsSheetDescriptors = worksheetsSheetDescriptors;
        }

        public ExcelWorkbookMaker(IExcelWorkbookSheetDescriptor worksheetsSheetDescriptor)
            : this(new List<IExcelWorkbookSheetDescriptor> {worksheetsSheetDescriptor})
        {
        }

        // ReSharper disable InconsistentNaming
        public XLWorkbook ToXLWorkbook()
            // ReSharper restore InconsistentNaming
        {
            var wb = new XLWorkbook();
            foreach (var excelWorkbookSheetDescriptor in _worksheetsSheetDescriptors)
            {
                excelWorkbookSheetDescriptor.AddWorksheetToWorkbook(wb);
            }
            return wb;
        }
    }
}