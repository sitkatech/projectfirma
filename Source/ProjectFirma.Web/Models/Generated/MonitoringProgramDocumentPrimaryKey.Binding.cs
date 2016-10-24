//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.MonitoringProgramDocument
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class MonitoringProgramDocumentPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<MonitoringProgramDocument>
    {
        public MonitoringProgramDocumentPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public MonitoringProgramDocumentPrimaryKey(MonitoringProgramDocument monitoringProgramDocument) : base(monitoringProgramDocument){}

        public static implicit operator MonitoringProgramDocumentPrimaryKey(int primaryKeyValue)
        {
            return new MonitoringProgramDocumentPrimaryKey(primaryKeyValue);
        }

        public static implicit operator MonitoringProgramDocumentPrimaryKey(MonitoringProgramDocument monitoringProgramDocument)
        {
            return new MonitoringProgramDocumentPrimaryKey(monitoringProgramDocument);
        }
    }
}