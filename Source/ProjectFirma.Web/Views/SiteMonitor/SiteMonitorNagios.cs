using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using LtInfo.Common.HealthMonitor;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectFundingSourceBudget;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.SiteMonitor
{
    /*
     *
     * namespace ProjectFirma.Web.Views.Shared
{
    public abstract class DisplayPageContent : LtInfo.Common.Mvc.TypedWebViewPage<DisplayPageContentViewData>
    {
    }
}
     */


    public abstract class SiteMonitorNagios : LtInfo.Common.Mvc.TypedWebViewPage<SiteMonitorNagiosViewData>
    {
        protected string GetStatusAsColorStyle(HealthCheckStatus status)
        {
            string color;
            switch (status)
            {
                case HealthCheckStatus.OK:
                    color = "green";
                    break;
                case HealthCheckStatus.Warning:
                    color = "orange";
                    break;
                case HealthCheckStatus.Critical:
                    color = "red";
                    break;
                case HealthCheckStatus.Unknown:
                    color = "orange";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
            return $"color:{color}";
        }
    }
}

namespace ProjectFirma.Web.Views.SiteMonitor
{
    public class SiteMonitorNagiosViewData : FirmaViewData
    {
        public readonly HealthCheckResults HealthCheckResults;
        public readonly string CompleteNagiosOutput;
        public readonly int NagiosReturnCode;

        public SiteMonitorNagiosViewData(Person currentPerson, HealthCheckResults healthCheckResults) : base(currentPerson)
        {
            HealthCheckResults = healthCheckResults;
            CompleteNagiosOutput = HealthCheckResults.GetHealthCheckResultsAsCompleteNagiosOutputText();
            NagiosReturnCode = HealthCheckResults.GetNagiosReturnCode();
        }
    }
}



