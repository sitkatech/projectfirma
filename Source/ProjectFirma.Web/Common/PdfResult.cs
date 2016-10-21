using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using LtInfo.Common.DesignByContract;

namespace ProjectFirma.Web.Common
{
    public class PdfResult : FileResourceResult
    {
        public PdfResult(FileResource fileResource) : base(fileResource.OriginalCompleteFileName, fileResource.FileResourceData, FileResourceMimeType.PDF)
        {
            Check.Require(fileResource.FileResourceMimeType == FileResourceMimeType.PDF, "Only a real PDF file can be saved off as PDF");
            ConstructorImpl(fileResource.OriginalCompleteFileName);
        }

        private void ConstructorImpl(string fileName)
        {
            Check.Require(fileName.ToLower().EndsWith(".pdf"), "PDF files should end with the file extension .pdf or downloaded file will be tricky to open");
        }

        /// <summary> 
        /// Execute the Result. 
        /// </summary> 
        /// <param name="context">Controller context.</param> 
        public override void ExecuteResult(ControllerContext context)
        {
            WriteStream(MemoryStream, Filename, FileResourceMimeType);
        }

        /// <summary> 
        /// Writes the memory stream to the browser. 
        /// </summary>
        /// <param name="memoryStream">Memory stream.</param>
        /// <param name="fileName"></param>
        /// <param name="fileResourceMimeType"></param>
        private static void WriteStream(MemoryStream memoryStream, string fileName, FileResourceMimeType fileResourceMimeType)
        {
            var context = HttpContext.Current;
            context.Response.Clear();

            context.Response.AddHeader("Content-Type", fileResourceMimeType.FileResourceMimeTypeContentTypeName);

            context.Response.AddHeader("Content-Disposition", String.Format("inline;filename=\"{0}\"", fileName));
            context.Response.AddHeader("Content-Length", memoryStream.Length.ToString());
            memoryStream.WriteTo(context.Response.OutputStream);
            memoryStream.Close();
            context.Response.End();
        }
    }
}