using System.IO;
using System.Web.Mvc;
using ClosedXML.Excel;

namespace LtInfo.Common.MvcResults
{
    public class ExcelResult : ActionResult
    {
        private readonly MemoryStream _memoryStream;
        private readonly string _fileName;

        public ExcelResult(XLWorkbook workbook, string fileName)
        {
            _fileName = fileName;
            _memoryStream = new MemoryStream();
            workbook.SaveAs(_memoryStream);
            _memoryStream.Seek(0, SeekOrigin.Begin);
        }

        public ExcelResult(MemoryStream memoryStream, string fileName)
        {
            _memoryStream = memoryStream;
            _fileName = fileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            response.AddHeader("content-disposition", string.Format("attachment;filename=\"{0}.xlsx\"", _fileName));
            using (_memoryStream)
            {
                _memoryStream.WriteTo(response.OutputStream);
            }
            response.End();
        }
    }
}