using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Configuration;
using LtInfo.Common.DesignByContract;

namespace LtInfo.Common
{
    // ReSharper disable once InconsistentNaming
    public class HeadlessChromePDFUtility
    {
        public class HeadlessChromePdfConversionSettings
        {
            public TimeSpan ExecutionTimeout;

            public HeadlessChromePdfConversionSettings()
                // Default to giving the PDF conversion as long as a request can go before being timed out. In other words, the maximum timeout possible.
                : this(((HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime"))
                    .ExecutionTimeout)
            {
            }

            public HeadlessChromePdfConversionSettings(TimeSpan executionTimeout)
            {
                ExecutionTimeout = executionTimeout;
            }

            public List<string> BuildHeadlessChromeCommandLineArguments(Uri url, FileInfo outputFile)
            {
                var args = new List<string>();

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
            }
        }

        // ReSharper disable once InconsistentNaming
        public static void ConvertURLToPDFWithHeadlessChrome(Uri url, FileInfo outputFile, HeadlessChromePdfConversionSettings headlessChromePdfConversionSettings)
        {
            // Settings should be provided
            Check.RequireNotNull(headlessChromePdfConversionSettings);

            // Output directory must exist
            Check.RequireDirectoryExists(outputFile.DirectoryName);

            var commandLineArguments = headlessChromePdfConversionSettings.BuildHeadlessChromeCommandLineArguments(url, outputFile);

            // TODO: Make configurable. NOTE **CURRENTLY EXPECTS CHROME CANARY** to use the --print-to-pdf-no-header option!!!
            // ALSO we need to have a chrome available that web process can 
            // The Chrome Canary EXE location can have spaces in it
            const string chromeExeLocation = "C:\\Users\\FirmaWebLocal\\AppData\\Local\\Google\\Chrome SxS\\Application\\chrome.exe";
            int maxTimeoutMs = (int)headlessChromePdfConversionSettings.ExecutionTimeout.TotalMilliseconds;
            const string outputThatIndicatesPdfHasBeenWritten = "Written to file";

            ProcessUtility.RunCommandLineLaunchingFromCmdExeWithOptionalTimeout(outputFile.DirectoryName, chromeExeLocation, commandLineArguments, outputThatIndicatesPdfHasBeenWritten, maxTimeoutMs);
        }
    }
}