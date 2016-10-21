using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class MonitoringProgram : IAuditableEntity
    {
        public string DeleteUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.DeleteMonitoringProgram(MonitoringProgramID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.Edit(MonitoringProgramID)); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string DisplayName
        {
            get { return MonitoringProgramName; }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(x => x.Summary(MonitoringProgramID)); }
        }

        public static bool IsMonitoringProgramNameUnique(IEnumerable<MonitoringProgram> monitoringPrograms, string monitoringProgramName, int currentMonitoringProgramID)
        {
            var monitoringProgram =
                monitoringPrograms.SingleOrDefault(
                    x => x.MonitoringProgramID != currentMonitoringProgramID && String.Equals(x.MonitoringProgramName, monitoringProgramName, StringComparison.InvariantCultureIgnoreCase));
            return monitoringProgram == null;
        }

        public string AuditDescriptionString
        {
            get { return MonitoringProgramName; }
        }
        public string NewMonitoringProgramDocumentUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.NewMonitoringProgramDocument(MonitoringProgramID)); }
        }
    }
}