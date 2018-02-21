using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    // ReSharper disable once InconsistentNaming
    public class PDFUtility
    {
        /// <summary>
        /// Convert Html page at a given URL to a PDF file using open-source tool wkhtml2pdf
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static void ConvertURLToPDF(Uri url, FileInfo outputFile, PdfConversionSettings settings)
        {
            Check.RequireNotNull(settings);

            var exeInfo = new FileInfo(SitkaConfiguration.GetRequiredAppSetting(settings.AppKeyExecPath));
            Check.RequireFileExists(exeInfo);

            Check.RequireDirectoryExists(outputFile.DirectoryName);

            var commandLineArguments = settings.BuildCommandSwitches();
            commandLineArguments.Add(url.ToString());
            commandLineArguments.Add(outputFile.FullName);
            var result = ProcessUtility.ShellAndWaitImpl(exeInfo.DirectoryName, exeInfo.FullName, commandLineArguments,
                true, Convert.ToInt32(settings.ExecutionTimeout.TotalMilliseconds));
            var retCode = result.ReturnCode;

            var argumentsAsString = String.Join(" ",
                commandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var fullProcessAndArguments =
                $"{ProcessUtility.EncodeArgumentForCommandLine(exeInfo.FullName)} {argumentsAsString}";
            Check.Ensure(retCode == 0,
                $"Process {exeInfo.Name} returned with exit code {retCode}, expected exit code 0.\r\nProcess Command Line:\r\n{fullProcessAndArguments}\r\nProcess Working Directory: {exeInfo.DirectoryName}\r\nStdErr and StdOut:\r\n{result.StdOutAndStdErr}");
        }

        /// <summary>
        /// Convert Html page at a given URL to a PDF file using open-source tool wkhtml2pdf
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static byte[] ConvertURLToByteArray(Uri url, PdfConversionSettings settings)
        {
            var tempFolder = new DirectoryInfo(SitkaConfiguration.GetRequiredAppSetting("TempFolder"));
            Check.RequireDirectoryExists(tempFolder);

            var tempFile = new FileInfo($"{tempFolder.FullName}\\{Guid.NewGuid()}.pdf");

            ConvertURLToPDF(url, tempFile, settings);

            using (var fs = new FileStream(tempFile.FullName, FileMode.Open, FileAccess.Read))
            {
                var result = new byte[fs.Length];
                fs.Read(result, 0, result.Length);
                fs.Close();
                tempFile.Delete();
                return result;
            }
        }


        public class PdfConversionSettings
        {
            public enum PageSizeOption
            {
                Letter,
                Legal
            }

            public enum PageOrientationOption
            {
                Portrait,
                Landscape
            }

            public readonly IEnumerable<HttpCookie> SecurityCookies;

            public int? MarginLeft;
            public int? MarginRight;
            public int? MarginTop;
            public int? MarginBottom;

            // ReSharper disable once InconsistentNaming
            public int? DPI;
            public bool? DisableSmartRendering;
            public int? HeaderFooterFontSize;
            public string HeaderLeft;
            public string HeaderRight;
            public string FooterLeft;
            public string FooterRight;
            public int? JavascriptDelay;
            public TimeSpan ExecutionTimeout;
            public PageSizeOption PageSize = PageSizeOption.Letter;
            public int? PageWidth;
            public int? PageHeight;
            public PageOrientationOption PageOrientation = PageOrientationOption.Portrait;
            public double Zoom = 1.0;
            public string PostData;

            public string AppKeyExecPath = "WkhtmltopdfExecutable";

            public PdfConversionSettings(HttpCookieCollection cookies)
                : this(
                    ((HttpRuntimeSection) WebConfigurationManager.GetSection("system.web/httpRuntime"))
                    .ExecutionTimeout, cookies)
            {
            }

            public PdfConversionSettings(TimeSpan executionTimeout, HttpCookieCollection cookies)
            {
                ExecutionTimeout = executionTimeout;

                // TODO: Circle back to pass all cookies and update the PageRenderer to escape cookies to be used on the command line. If we ever do this, make sure to exclude SessionState.CookieName to avoid the synchronous nature of session aware actions. http://weblogs.asp.net/imranbaloch/archive/2010/07/10/concurrent-requests-in-asp-net-mvc.aspx

                // DO NOT pass the "ASP.NET_SessionId" cookie. It forces this request to block on obtaining write access to the user session, which our parent request currently holds. 
                SecurityCookies = CookieHelper.GetAllCookiesExceptSessionCookie(cookies);
            }

            public PdfConversionSettings(HttpCookieCollection cookies, string appKeyExecPath)
                : this(cookies)
            {
                AppKeyExecPath = appKeyExecPath;
            }

            public List<string> BuildCommandSwitches()
            {
                var args = new List<string> {"--print-media-type", "--header-spacing", "1", "--footer-spacing", "1"};
                if (HeaderFooterFontSize.HasValue)
                {
                    args.Add("--header-font-size");
                    args.Add(HeaderFooterFontSize.ToString());
                }

                if (HeaderFooterFontSize.HasValue)
                {
                    args.Add("--footer-font-size");
                    args.Add(HeaderFooterFontSize.ToString());
                }

                if (!String.IsNullOrWhiteSpace(HeaderLeft))
                {
                    args.Add("--header-left");
                    args.Add(HeaderLeft);
                }

                if (!String.IsNullOrWhiteSpace(HeaderRight))
                {
                    args.Add("--header-right");
                    args.Add(HeaderRight);
                }

                if (!String.IsNullOrWhiteSpace(FooterLeft))
                {
                    args.Add("--footer-left");
                    args.Add(FooterLeft);
                }

                if (!String.IsNullOrWhiteSpace(FooterRight))
                {
                    args.Add("--footer-right");
                    args.Add(FooterRight);
                }

                if (JavascriptDelay.HasValue)
                {
                    args.Add("--javascript-delay");
                    args.Add(JavascriptDelay.ToString());
                }

                if (!String.IsNullOrWhiteSpace(PostData))
                {
                    args.Add("--post");
                    args.Add(PostData);
                }

                if (MarginLeft.HasValue)
                {
                    args.Add("--margin-left");
                    args.Add(MarginLeft.ToString());
                }

                if (MarginRight.HasValue)
                {
                    args.Add("--margin-right");
                    args.Add(MarginRight.ToString());
                }

                if (MarginTop.HasValue)
                {
                    args.Add("--margin-top");
                    args.Add(MarginTop.ToString());
                }

                if (MarginBottom.HasValue)
                {
                    args.Add("--margin-bottom");
                    args.Add(MarginBottom.ToString());
                }

                if (DPI.HasValue)
                {
                    args.Add("--dpi");
                    args.Add(DPI.ToString());
                }

                if (DisableSmartRendering.GetValueOrDefault(false))
                {
                    args.Add("--disable-smart-shrinking");
                }

                args.Add("--page-size");
                args.Add(PageSize.ToString());

                if (PageWidth.HasValue)
                {
                    args.Add("--page-width");
                    args.Add(PageWidth.ToString());
                }

                if (PageHeight.HasValue)
                {
                    args.Add("--page-height");
                    args.Add(PageHeight.ToString());
                }

                args.Add("--orientation");
                args.Add(PageOrientation.ToString());

                args.Add("--zoom");
                args.Add(Zoom.ToString(CultureInfo.InvariantCulture));

                args.AddRange(SecurityCookies.SelectMany(cookie => new[] {"--cookie", cookie.Name, cookie.Value}));
                return args;
            }
        }
    }
}