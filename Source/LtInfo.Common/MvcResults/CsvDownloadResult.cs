using System.Text;
using System.Web.Mvc;
using LtInfo.Common.Views;

namespace LtInfo.Common.MvcResults
{
    public class CsvDownloadResult : ActionResult
    {
        public CsvDownloadResult(DownloadFileDescriptor fileDescriptor, string csv)
        {
            CsvContents = csv;
            FileDescriptor = fileDescriptor;
        }

        public string CsvContents { get; set; }
        public DownloadFileDescriptor FileDescriptor { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var encoding = Encoding.UTF8;
            ViewUtilities.SetupHttpHeadersForDownload(context.HttpContext.Response, FileDescriptor, encoding);
            //var preamble = encoding.GetPreamble();
            var csvBytes = encoding.GetBytes(CsvContents);
            //context.HttpContext.Response.BinaryWrite(preamble);
            context.HttpContext.Response.BinaryWrite(csvBytes);
        }
    }
}