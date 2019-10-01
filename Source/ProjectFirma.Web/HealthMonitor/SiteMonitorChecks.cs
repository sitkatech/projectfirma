using LtInfo.Common.HealthMonitor;

namespace ProjectFirma.Web.HealthMonitor
{
    /// <summary>
    /// Hook in point for all site monitoring checks that we have
    /// </summary>
    internal static class SiteMonitorChecks
    {
        public static HealthCheckResults Run()
        {
            var results = new HealthCheckResults();
            // Here's the list of checks to run
            results.Add(WhtmlToPdfIsAvailableAndRunningExpectedVersion.Run());
            return results;
        }
    }
}