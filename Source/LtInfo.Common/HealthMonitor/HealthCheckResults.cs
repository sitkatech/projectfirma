/*-----------------------------------------------------------------------
<copyright file="HealthCheckResults.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LtInfo.Common.HealthMonitor
{
    public class HealthCheckResults
    {
        /// <summary>
        /// Nagios is OK with CR-LF for line endings even though LF is more unix like, but since we output via web page content CR-LF is easier
        /// </summary>
        private const string NagiosPluginOutputLineEnding = "\r\n";

        /// <summary>
        /// Separator between text output and performance data output
        /// </summary>
        private const string NagiosOutputSectionSeparator = "|";

        public List<HealthCheckResult> Results { get; } = new List<HealthCheckResult>();

        public HealthCheckStatus Status => CalculateOverallStatus();

        /// <summary>
        /// See https://assets.nagios.com/downloads/nagioscore/docs/nagioscore/3/en/pluginapi.html
        /// for Nagios return codes.
        /// </summary>
        /// <returns></returns>
        public int GetNagiosReturnCode()
        {
            switch (Status)
            {
                case HealthCheckStatus.OK:
                    return 0;
                case HealthCheckStatus.Warning:
                    return 1;
                case HealthCheckStatus.Critical:
                    return 2;
                case HealthCheckStatus.Unknown:
                    return 3;
                default:
                    throw new SitkaDisplayErrorException($"Unknown Status: {Status}");
            }
        }

        /// <summary>
        /// Get HealthCheckStatus
        /// </summary>
        private HealthCheckStatus CalculateOverallStatus()
        {
            return GetAggregateHealthCheckStatus(Results.Select(r => r.HealthCheckStatus).ToList());
        }

        /// <summary>
        /// Get the aggregate (net? Winning?) HealthCheckStatus for a group of HealthCheckStatues
        /// </summary>
        public static HealthCheckStatus GetAggregateHealthCheckStatus(List<HealthCheckStatus> healthCheckStatuses)
        {
            // If all successful
            if (healthCheckStatuses.All(x => x == HealthCheckStatus.OK))
            {
                return HealthCheckStatus.OK;
            }

            // If any were errors, fail this check
            if (healthCheckStatuses.Any(x => x == HealthCheckStatus.Critical))
            {
                return HealthCheckStatus.Critical;
            }

            // If no errors, and any were warning, return warning
            if (healthCheckStatuses.Any(x => x == HealthCheckStatus.Warning))
            {
                return HealthCheckStatus.Warning;
            }

            // If no errors, and no warnings, and any were unknown, return Unknown
            if (healthCheckStatuses.Any(x => x == HealthCheckStatus.Unknown))
            {
                return HealthCheckStatus.Unknown;
            }

            // We should never get here, but if we do, tell us why
            var badCheckStatuesString = String.Join(", ", healthCheckStatuses.Select(r => $"{r.ToString()}"));
            throw new SitkaDisplayErrorException($"Unanticipated combination of HealthCheckStatuses: {badCheckStatuesString}");
        }

        /// <summary>
        /// Nagios Plugin Output Spec 
        /// At a minimum, plugins should return at least one of text output.Beginning with Nagios 3, plugins can optionally return multiple lines of output.
        /// Plugins may also return optional performance data that can be processed by external applications. The basic format for plugin output is shown below: 
        ///
        /// TEXT OUTPUT | OPTIONAL PERFDATA
        /// LONG TEXT LINE 1
        ///
        /// LONG TEXT LINE 2
        /// ...
        ///
        /// LONG TEXT LINE N | PERFDATA LINE 2
        /// PERFDATA LINE 3
        /// ...
        ///
        /// PERFDATA LINE N
        /// 
        /// 
        /// More about this format, see: https://assets.nagios.com/downloads/nagioscore/docs/nagioscore/3/en/pluginapi.html
        /// </summary>
        public string GetHealthCheckResultsAsCompleteNagiosOutputText()
        {
            var serviceOutput = EscapeOutputTextForNagios(GetHealthCheckResultsAsBriefNagiosServiceOutputText());
            var shortPerfData = GetHealthCheckResultsAsPerformanceDataShort();
            var longServiceOutput = GetHealthCheckResultsAsLongNagiosServiceOutputText();
            var longPerfOutput = GetHealthCheckResultsAsPerformanceDataLong();
            var fullNagiosOutput = $"{serviceOutput}{NagiosOutputSectionSeparator}{shortPerfData}{NagiosPluginOutputLineEnding}{longServiceOutput}{NagiosOutputSectionSeparator}{longPerfOutput}";
            return fullNagiosOutput;
        }

        public void Add(HealthCheckResult result)
        {
            Results.Add(result);
        }

        private string GetHealthCheckResultsAsBriefNagiosServiceOutputText()
        {
            var allHealthCheckStatuses = GeneralUtility.EnumGetValues<HealthCheckStatus>();

            // Text count of statuses e.g. "(9 OK, 0 Warning, 0 Critical, 0 Unknown)"
            var statusCountList = $"({string.Join(", ", allHealthCheckStatuses.Select(x => $"{Results.Count(r => r.HealthCheckStatus == x)} {x}"))})";

            var currentStatus = CalculateOverallStatus();
            switch (currentStatus)
            {
                case HealthCheckStatus.OK:
                    return $"OK - all OK {statusCountList}";
                case HealthCheckStatus.Warning:
                    return $"WARNING - at least one warning {statusCountList}";
                case HealthCheckStatus.Critical:
                    return $"CRITICAL - at least one critical {statusCountList}";
                case HealthCheckStatus.Unknown:
                    return $"UNKNOWN - at least one unknown {statusCountList}";
                default:
                    throw new SitkaDisplayErrorException($"Unhandled Health Check Status: {currentStatus}");
            }
        }

        private string GetHealthCheckResultsAsLongNagiosServiceOutputText()
        {
            return string.Join(NagiosPluginOutputLineEnding, Results.Select(x => $"{x.CheckName} - {x.HealthCheckStatus}"));
        }

        /// <summary>
        /// Main performance data
        /// </summary>
        private string GetHealthCheckResultsAsPerformanceDataShort()
        {
            var max = Results.Count;
            var problemCount = Results.Count(r => r.HealthCheckStatus != HealthCheckStatus.OK);
            const int warn = 1;
            const int crit = warn;
            const int min = 0;
            return FormatNagiosPerfCounterLine("ProblemCount", problemCount, warn, crit, min, max);
        }

        private string GetHealthCheckResultsAsPerformanceDataLong()
        {
            var allHealtCheckStatuses = GeneralUtility.EnumGetValues<HealthCheckStatus>();
            return string.Join(" ", allHealtCheckStatuses.Select(GetHealthCheckResultsAsPerformanceDataLongPerStatus));
        }

        /// <summary>
        /// Comports with Nagios performance format of 'label'=value[UOM];[warn];[crit];[min];[max]
        /// See:        https://nagios-plugins.org/doc/guidelines.html#THRESHOLDFORMAT 
        /// </summary>
        /// <summary>
        /// Gets more detailed secondary counters
        /// </summary>
        private string GetHealthCheckResultsAsPerformanceDataLongPerStatus(HealthCheckStatus healthCheckStatus)
        {
            var max = Results.Count;
            var countInThisStatus = Results.Count(r => r.HealthCheckStatus == healthCheckStatus);
            var warn = healthCheckStatus == HealthCheckStatus.OK ? Results.Count : 1;
            var crit = warn;
            const int min = 0;
            return FormatNagiosPerfCounterLine($"{healthCheckStatus}Count", countInThisStatus, warn, crit, min, max);
        }

        /// <summary>
        /// Comports with Nagios performance format of 'label'=value[UOM];[warn];[crit];[min];[max]
        /// See:        https://nagios-plugins.org/doc/guidelines.html#THRESHOLDFORMAT 
        /// </summary>
        private static string FormatNagiosPerfCounterLine(string nagiosPerfCounterLabel, int problemCount, int warn, int crit, int min, int max)
        {
            return $"{nagiosPerfCounterLabel}={problemCount};{warn};{crit};{min};{max}";
        }

        /// <summary>
        /// The one character to what out for in Nagios text output is the performance data separator, escape for that by replacing with space
        /// </summary>
        private static string EscapeOutputTextForNagios(string output)
        {
            return output.Replace(NagiosOutputSectionSeparator, " ");
        }
    }
}
