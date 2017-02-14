//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgramDocument]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static MonitoringProgramDocument GetMonitoringProgramDocument(this IQueryable<MonitoringProgramDocument> monitoringProgramDocuments, int monitoringProgramDocumentID)
        {
            var monitoringProgramDocument = monitoringProgramDocuments.SingleOrDefault(x => x.MonitoringProgramDocumentID == monitoringProgramDocumentID);
            Check.RequireNotNullThrowNotFound(monitoringProgramDocument, "MonitoringProgramDocument", monitoringProgramDocumentID);
            return monitoringProgramDocument;
        }

        public static void DeleteMonitoringProgramDocument(this List<int> monitoringProgramDocumentIDList)
        {
            if(monitoringProgramDocumentIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMonitoringProgramDocuments.RemoveRange(HttpRequestStorage.DatabaseEntities.MonitoringProgramDocuments.Where(x => monitoringProgramDocumentIDList.Contains(x.MonitoringProgramDocumentID)));
            }
        }

        public static void DeleteMonitoringProgramDocument(this ICollection<MonitoringProgramDocument> monitoringProgramDocumentsToDelete)
        {
            if(monitoringProgramDocumentsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllMonitoringProgramDocuments.RemoveRange(monitoringProgramDocumentsToDelete);
            }
        }

        public static void DeleteMonitoringProgramDocument(this int monitoringProgramDocumentID)
        {
            DeleteMonitoringProgramDocument(new List<int> { monitoringProgramDocumentID });
        }

        public static void DeleteMonitoringProgramDocument(this MonitoringProgramDocument monitoringProgramDocumentToDelete)
        {
            DeleteMonitoringProgramDocument(new List<MonitoringProgramDocument> { monitoringProgramDocumentToDelete });
        }
    }
}