using System;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public partial class MonitoringProgramDocument : IAuditableEntity
    {
        public MonitoringProgramDocument(MonitoringProgram monitoringProgram)
            : this(ModelObjectHelpers.NotYetAssignedID, monitoringProgram.MonitoringProgramID, string.Empty, DateTime.Now)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            MonitoringProgram = monitoringProgram;   
            // ReSharper restore DoNotCallOverridableMethodsInConstructor

        }

        public string AuditDescriptionString { get; private set; }

        public string DeleteMonitoringProgramDocumentUrl
        {
            get { return SitkaRoute<MonitoringProgramController>.BuildUrlFromExpression(t => t.DeleteMonitoringProgramDocument(MonitoringProgramDocumentID)); }
        }

    }
}