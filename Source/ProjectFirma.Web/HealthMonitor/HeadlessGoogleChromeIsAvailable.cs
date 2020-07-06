using System.IO;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.HealthMonitor;

namespace ProjectFirma.Web.HealthMonitor
{
    internal static class HeadlessGoogleChromeIsAvailable
    {
        /// <summary>
        /// We may want to do a version check on Google Chrome as well
        /// </summary>
        /// <returns></returns>
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

}