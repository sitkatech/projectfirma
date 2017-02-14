//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SupportRequestLog]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SupportRequestLog GetSupportRequestLog(this IQueryable<SupportRequestLog> supportRequestLogs, int supportRequestLogID)
        {
            var supportRequestLog = supportRequestLogs.SingleOrDefault(x => x.SupportRequestLogID == supportRequestLogID);
            Check.RequireNotNullThrowNotFound(supportRequestLog, "SupportRequestLog", supportRequestLogID);
            return supportRequestLog;
        }

        public static void DeleteSupportRequestLog(this List<int> supportRequestLogIDList)
        {
            if(supportRequestLogIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSupportRequestLogs.RemoveRange(HttpRequestStorage.DatabaseEntities.SupportRequestLogs.Where(x => supportRequestLogIDList.Contains(x.SupportRequestLogID)));
            }
        }

        public static void DeleteSupportRequestLog(this ICollection<SupportRequestLog> supportRequestLogsToDelete)
        {
            if(supportRequestLogsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllSupportRequestLogs.RemoveRange(supportRequestLogsToDelete);
            }
        }

        public static void DeleteSupportRequestLog(this int supportRequestLogID)
        {
            DeleteSupportRequestLog(new List<int> { supportRequestLogID });
        }

        public static void DeleteSupportRequestLog(this SupportRequestLog supportRequestLogToDelete)
        {
            DeleteSupportRequestLog(new List<SupportRequestLog> { supportRequestLogToDelete });
        }
    }
}