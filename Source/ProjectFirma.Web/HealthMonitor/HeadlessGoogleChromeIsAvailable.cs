﻿using System.IO;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.HealthMonitor;

namespace ProjectFirma.Web.HealthMonitor
{
    internal static class HeadlessGoogleChromeIsAvailable
    {
        //// Fixed, hard-coded version string to start.
        //public const string ExpectedWhtmlToPdfVersionString = "0.12.5";

        public static HealthCheckResult Run()
        {
            var result = new HealthCheckResult("HeadlessGoogleChromeIsAvailable");
            // Assume success until we get failure
            result.HealthCheckStatus = HealthCheckStatus.OK;

            // Make sure we have HTTP context
            var currentHttpContext = HttpContext.Current;
            if (currentHttpContext == null)
            {
                result.HealthCheckStatus = HealthCheckStatus.Critical;
                result.AddResultMessage("Could not run check because missing HTTP context");
                return result;
            }

            // Make sure Google Chrome .EXE exists where we expect it for this environment
            FileInfo googleChromeExecutablePathFileInfo = new FileInfo(SitkaConfiguration.GetRequiredAppSetting("HeadlessGoogleChromeExecutable"));
            if (!File.Exists(googleChromeExecutablePathFileInfo.FullName))
            {
                result.HealthCheckStatus = HealthCheckStatus.Critical;
                result.AddResultMessage($"Could not find Google Chrome .EXE at \"{googleChromeExecutablePathFileInfo.FullName}\"");
                return result;
            }

            // We may want to do something like this for Google Chrome eventually; here for reference.

            //// If .EXE does exist, make sure it has the right version number
            //var versionString = WkhtmlToPdfCommandLineRunner.RunWkhtmlToPdfAndGetVersionNumber();

            //if (versionString != ExpectedWhtmlToPdfVersionString)
            //{
            //    result.HealthCheckStatus = HealthCheckStatus.Critical;
            //    string wkhtmlPdfExecutablePath = SitkaConfiguration.GetRequiredAppSetting("WkhtmltopdfExecutable");
            //    result.AddResultMessage($"Wkhtmltopdf found at {wkhtmlPdfExecutablePath} is version {versionString}; expected {ExpectedWhtmlToPdfVersionString}");

            //    return result;
            //}

            //result.AddResultMessage($"Wkhtmltopdf is expected version ({versionString})");

            result.AddResultMessage($"Google Chrome appears to be installed where expected at {googleChromeExecutablePathFileInfo.FullName}");
            return result;
        }
    }

    /*
    public class WkhtmlToPdfCommandLineRunner
    {
        private static string RunWkhtmlToPdfCommand(List<string> commandLineArguments)
        {
            FileInfo wkhtmlPdfExecutablePathFileInfo = new FileInfo(SitkaConfiguration.GetRequiredAppSetting("WkhtmltopdfExecutable"));
            Check.RequireFileExists(wkhtmlPdfExecutablePathFileInfo, "Can't find WkhtmlToPdf program in expected path. Is it installed?");
            var retCode = ProcessUtility.ShellAndWaitImpl(wkhtmlPdfExecutablePathFileInfo.DirectoryName, wkhtmlPdfExecutablePathFileInfo.FullName, commandLineArguments, true, Convert.ToInt32(FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds));
            if (retCode.ReturnCode == 0)
            {
                //return stdErrorAndStdOutAsString;
                return retCode.StdOutAndStdErr;
            }

            // Error situation - gather details
            var argumentsAsString = String.Join(" ", commandLineArguments.Select(ProcessUtility.EncodeArgumentForCommandLine).ToList());
            var fullProcessAndArguments = $"{ProcessUtility.EncodeArgumentForCommandLine(wkhtmlPdfExecutablePathFileInfo.FullName)} {argumentsAsString}";
            var errorMessage = $"Process \"{wkhtmlPdfExecutablePathFileInfo.Name}\" returned with exit code {retCode}, expected exit code 0.\r\n\r\nStdErr and StdOut:\r\n{retCode.StdOutAndStdErr}\r\n\r\nProcess Command Line:\r\n{fullProcessAndArguments}\r\n\r\nProcess Working Directory: {wkhtmlPdfExecutablePathFileInfo.DirectoryName}";
            throw new WkhtmlToPdfCommandLineException(errorMessage);
        }

        public static string RunWkhtmlToPdfAndGetVersionNumber()
        {
            var ogr2OgrCommandLineArguments = new List<string> { "--version" };
            var stdErrorAndStdOutAsString = RunWkhtmlToPdfCommand(ogr2OgrCommandLineArguments);
            // Parse out the version number such as "wkhtmltopdf 0.12.2.2 (with patched qt)" version number string.
            const string wkhtmltopdfVersionNumberRegex = "wkhtmltopdf ([0-9]+.[0-9]+.[0-9]+)";
            var result = Regex.Match(stdErrorAndStdOutAsString, wkhtmltopdfVersionNumberRegex);
            return result.Success ? result.Groups[1].Value : $"Could not find WkhtmlToPDF version number from stdout output: {stdErrorAndStdOutAsString}";
        }

        /// <summary>
        /// Anything that comes out of <see cref="WkhtmlToPdfCommandLineRunner"/>
        /// </summary>
        public class WkhtmlToPdfCommandLineException : ApplicationException
        {
            public WkhtmlToPdfCommandLineException(string errorMessage) : base(errorMessage) { }
        }

    }
    */

}