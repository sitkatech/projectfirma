using System.IO;
using System.Web;
using LtInfo.Common.HealthMonitor;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.HealthMonitor
{
    internal static class Ogr2OgrIExeIsCorrectVersion
    {
        // Fixed, hard-coded version string to start.
        public const string EXPECTED_OGR_VERSION_NUMBER_STRING = "2.3.1";

        public static HealthCheckResult Run()
        {
            var result = new HealthCheckResult("Ogr2OgrIExeIsCorrectVersion");
            // Assume success until we get failure
            result.HealthCheckStatus = HealthCheckStatus.OK;

            var currentHttpContext = HttpContext.Current;
            if (currentHttpContext == null)
            {
                result.HealthCheckStatus = HealthCheckStatus.Critical;
                result.AddResultMessage("Could not run check because missing HTTP context");
                return result;
            }

            if (!File.Exists(FirmaWebConfiguration.Ogr2OgrExecutable))
            {
                result.HealthCheckStatus = HealthCheckStatus.Critical;
                result.AddResultMessage($"Could not find Ogr2Ogr executable file at \"{FirmaWebConfiguration.Ogr2OgrExecutable}\"");
                return result;
            }

            // This needs to come back 
            /*
            var versionString = LtInfo.Common.GdalOgr.Ogr2OgrCommandLineRunner.RunOgr2OgrAndGetVersionNumber(FirmaWebConfiguration.Ogr2OgrExecutable, FirmaWebConfiguration.HttpRuntimeExecutionTimeout.TotalMilliseconds);

            if (versionString != EXPECTED_OGR_VERSION_NUMBER_STRING)
            {
                result.HealthCheckStatus = HealthCheckStatus.Critical;
                result.AddResultMessage($"Ogr2Ogr ({FirmaWebConfiguration.Ogr2OgrExecutable}) is version {versionString}; expected {EXPECTED_OGR_VERSION_NUMBER_STRING}");
                return result;
            }

            result.AddResultMessage($"Ogr2Ogr ({FirmaWebConfiguration.Ogr2OgrExecutable}) is expected version ({versionString})");
            return result;
            */

            // HACK
            result.AddResultMessage($"Ogr2Ogr ({FirmaWebConfiguration.Ogr2OgrExecutable}) is present, but version number NOT CHECKED!!!!");
            return result;
        }
    }
}