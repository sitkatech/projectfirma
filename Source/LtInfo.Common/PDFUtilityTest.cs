//using System;
//using System.Activities.Statements;
//using System.Diagnostics;
//using System.IO;
//using System.Net;
//using System.Web;
using NUnit.Framework;

namespace LtInfo.Common // todo maybe finish porting these, you know... so we have some confidence that they work
{
    [TestFixture]
    // ReSharper disable once InconsistentNaming
    public class PDFUtilityTest
    {
        [Test, Ignore]
        public void GivenGoodWebPageGeneratePdfFile()
        {
            //using (var outputFile = new DisposableTempFile())
            //{
            //    var url = Throw.BuildUrl(HttpStatusCode.OK);
            //    var settings = new PDFUtility.PdfConversionSettings(new HttpCookieCollection());
            //    PDFUtility.ConvertURLToPDF(url, outputFile.FileInfo, settings);
            //    Assert.That(File.Exists(outputFile.FileInfo.FullName), "Should have gotten an output PDF file");
            //    var fileContents = FileUtility.FileToString(outputFile.FileInfo);
            //    Assert.That(fileContents, Is.StringStarting("%PDF-"), "Should be a PDF file and have the starting bytes for PDF");
            //    Assert.That(fileContents, Is.StringContaining("wkhtmltopdf").Or.StringContaining("\0w\0k\0h\0t\0m\0l\0t\0o\0p\0d\0f"), "Should be a PDF file produced by wkhtmltopdf.");
            //}
        }

        [Test, Ignore]
        public void GivenUrlHttp404ThrowException()
        {
            //using (var outputFile = new DisposableTempFile())
            //{
            //    var url = Throw.BuildUrl(HttpStatusCode.NotFound);
            //    var settings = new PDFUtility.PdfConversionSettings(new HttpCookieCollection());
            //    var ex = Assert.Catch(() => PDFUtility.ConvertURLToPDF(url, outputFile.FileInfo, settings), "File not found should raise exception");
            //    Assert.That(ex.ToString(), Is.StringContaining("Loading pages").And.Contains("Resolving links").And.Contains("Done"), "The exception should contain the details from stderr and stdout.");
            //}
        }
    }
}
