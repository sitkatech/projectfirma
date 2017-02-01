//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MonitoringProgramDocument]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteMonitoringProgramDocument(this IQueryable<MonitoringProgramDocument> monitoringProgramDocuments, List<int> monitoringProgramDocumentIDList)
        {
            if(monitoringProgramDocumentIDList.Any())
            {
                monitoringProgramDocuments.Where(x => monitoringProgramDocumentIDList.Contains(x.MonitoringProgramDocumentID)).Delete();
            }
        }

        public static void DeleteMonitoringProgramDocument(this IQueryable<MonitoringProgramDocument> monitoringProgramDocuments, ICollection<MonitoringProgramDocument> monitoringProgramDocumentsToDelete)
        {
            if(monitoringProgramDocumentsToDelete.Any())
            {
                var monitoringProgramDocumentIDList = monitoringProgramDocumentsToDelete.Select(x => x.MonitoringProgramDocumentID).ToList();
                monitoringProgramDocuments.Where(x => monitoringProgramDocumentIDList.Contains(x.MonitoringProgramDocumentID)).Delete();
            }
        }

        public static void DeleteMonitoringProgramDocument(this IQueryable<MonitoringProgramDocument> monitoringProgramDocuments, int monitoringProgramDocumentID)
        {
            DeleteMonitoringProgramDocument(monitoringProgramDocuments, new List<int> { monitoringProgramDocumentID });
        }

        public static void DeleteMonitoringProgramDocument(this IQueryable<MonitoringProgramDocument> monitoringProgramDocuments, MonitoringProgramDocument monitoringProgramDocumentToDelete)
        {
            DeleteMonitoringProgramDocument(monitoringProgramDocuments, new List<MonitoringProgramDocument> { monitoringProgramDocumentToDelete });
        }
    }
}