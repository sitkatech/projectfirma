using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    public class HeadlessChromePDFUtility
    {
        public class HeadlessChromePdfConversionSettings
        {
            public TimeSpan ExecutionTimeout;
            public readonly IEnumerable<HttpCookie> SecurityCookies;

            public HeadlessChromePdfConversionSettings(HttpCookieCollection cookies)
                : this(
                    ((HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime"))
                    .ExecutionTimeout, cookies)
            {
            }

            public HeadlessChromePdfConversionSettings(TimeSpan executionTimeout, HttpCookieCollection cookies)
            {
                ExecutionTimeout = executionTimeout;

                // TODO: Circle back to pass all cookies and update the PageRenderer to escape cookies to be used on the command line. If we ever do this, make sure to exclude SessionState.CookieName to avoid the synchronous nature of session aware actions. http://weblogs.asp.net/imranbaloch/archive/2010/07/10/concurrent-requests-in-asp-net-mvc.aspx

                // DO NOT pass the "ASP.NET_SessionId" cookie. It forces this request to block on obtaining write access to the user session, which our parent request currently holds. 
                SecurityCookies = CookieHelper.GetAllCookiesExceptSessionCookie(cookies);
            }

            public List<string> BuildHeadlessChromeCommandLineArguments(Uri url, FileInfo outputFile)
            {
                var args = new List<string>();

                //string outputFileDirectory = outputFile.DirectoryName;
                string outputFilename = outputFile.Name;

                //         // "C:\Users\stewart.SITKA\AppData\Local\Google\Chrome SxS\Application\chrome.exe" --headless --disable-gpu
                //         // --enable-logging --no-margins --print-to-pdf
                //         // --print-to-pdf-no-header  https://qa-actionagenda.pugetsoundinfo.wa.gov/Project/FactSheet/12819

                args.Add("--headless");
                args.Add("--disable-gpu");
                args.Add("--enable-logging");
                args.Add("--no-margins");
                // As of 6/17/2020, this option is **ONLY** available in Google Canary, a nightly build. It will be ignored on current release builds (but you'll get headers & footers)
                args.Add("--print-to-pdf-no-header");
                args.Add($"--print-to-pdf=\"{outputFile.FullName}\"");
                args.Add(url.ToString());

                return args;

                // Notice no cookies here.. we'll see if we need them. TODO.
            }
        }

        // ReSharper disable once InconsistentNaming
        public static void ConvertURLToPDFWithHeadlessChrome(Uri url, FileInfo outputFile, HeadlessChromePdfConversionSettings settings)
        {
            // Settings should be provided
            Check.RequireNotNull(settings);

            // Output directory must exist
            Check.RequireDirectoryExists(outputFile.DirectoryName);

            var commandLineArguments = settings.BuildHeadlessChromeCommandLineArguments(url, outputFile);

            // TODO: Make configurable. NOTE **CURRENTLY EXPECTS CHROME CANARY** to use the --print-to-pdf-no-header option!!!
            // ALSO we need to have a chrome available that web process can 
            // The Chrome Canary EXE location can have spaces in it, so hopefully ShellAndWaitImpl deals properly with this...
            const string chromeExeLocation = "C:\\Users\\FirmaWebLocal\\AppData\\Local\\Google\\Chrome SxS\\Application\\chrome.exe";

            /*
             // Nice try, but without a cmd.exe to respond to, it exits before any work gets done, since headless chrome does it's
             // work asynch.
             
            var result = ProcessUtility.ShellAndWaitImpl(outputFile.DirectoryName, chromeExeLocation, commandLineArguments,
                true, Convert.ToInt32(settings.ExecutionTimeout.TotalMilliseconds));
            var retCode = result.ReturnCode;
            */

            const int maxTimeoutMs = 40000;
            const string outputThatIndicatesPdfHasBeenWritten = "Written to file";
            ProcessUtility.RunCommandLineLaunchingFromCmdExeWithOptionalTimeout(outputFile.DirectoryName, chromeExeLocation, commandLineArguments, outputThatIndicatesPdfHasBeenWritten, maxTimeoutMs);

            var argumentsAsString = String.Join(" ",
                commandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var fullProcessAndArguments =
                $"{ProcessUtility.EncodeArgumentForCommandLine(chromeExeLocation)} {argumentsAsString}";
            // it does not seem like we get a useful return value from headless chrome.
            //Check.Ensure(retCode == 0,
            //    $"Process {chromeExeLocation} returned with exit code {retCode}, expected exit code 0.\r\nProcess Command Line:\r\n{fullProcessAndArguments}\r\nProcess Working Directory: {outputFile.DirectoryName}\r\nStdErr and StdOut:\r\n{result.StdOutAndStdErr}");

            // BRUTAL HACK -- Headless chrome returns BEFORE it is done writing the file, and I can't for the life of me figure out how to make it behave synchronously. Starting with a
            // hard-coded delay just to start off, but we MUST do better.

            //Thread.Sleep(TimeSpan.FromSeconds(60));
        }
    }
}