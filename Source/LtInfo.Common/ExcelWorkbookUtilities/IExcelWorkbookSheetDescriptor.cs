using ClosedXML.Excel;

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    public interface IExcelWorkbookSheetDescriptor
    {
        void AddWorksheetToWorkbook(XLWorkbook wb);
        string WorksheetName { get; }
    }
}