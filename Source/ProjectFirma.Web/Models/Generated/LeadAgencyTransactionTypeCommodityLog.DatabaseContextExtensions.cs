//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[LeadAgencyTransactionTypeCommodityLog]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static LeadAgencyTransactionTypeCommodityLog GetLeadAgencyTransactionTypeCommodityLog(this IQueryable<LeadAgencyTransactionTypeCommodityLog> leadAgencyTransactionTypeCommodityLogs, int leadAgencyTransactionTypeCommodityLogID)
        {
            var leadAgencyTransactionTypeCommodityLog = leadAgencyTransactionTypeCommodityLogs.SingleOrDefault(x => x.LeadAgencyTransactionTypeCommodityLogID == leadAgencyTransactionTypeCommodityLogID);
            Check.RequireNotNullThrowNotFound(leadAgencyTransactionTypeCommodityLog, "LeadAgencyTransactionTypeCommodityLog", leadAgencyTransactionTypeCommodityLogID);
            return leadAgencyTransactionTypeCommodityLog;
        }

        public static void DeleteLeadAgencyTransactionTypeCommodityLog(this IQueryable<LeadAgencyTransactionTypeCommodityLog> leadAgencyTransactionTypeCommodityLogs, List<int> leadAgencyTransactionTypeCommodityLogIDList)
        {
            if(leadAgencyTransactionTypeCommodityLogIDList.Any())
            {
                leadAgencyTransactionTypeCommodityLogs.Where(x => leadAgencyTransactionTypeCommodityLogIDList.Contains(x.LeadAgencyTransactionTypeCommodityLogID)).Delete();
            }
        }

        public static void DeleteLeadAgencyTransactionTypeCommodityLog(this IQueryable<LeadAgencyTransactionTypeCommodityLog> leadAgencyTransactionTypeCommodityLogs, ICollection<LeadAgencyTransactionTypeCommodityLog> leadAgencyTransactionTypeCommodityLogsToDelete)
        {
            if(leadAgencyTransactionTypeCommodityLogsToDelete.Any())
            {
                var leadAgencyTransactionTypeCommodityLogIDList = leadAgencyTransactionTypeCommodityLogsToDelete.Select(x => x.LeadAgencyTransactionTypeCommodityLogID).ToList();
                leadAgencyTransactionTypeCommodityLogs.Where(x => leadAgencyTransactionTypeCommodityLogIDList.Contains(x.LeadAgencyTransactionTypeCommodityLogID)).Delete();
            }
        }

        public static void DeleteLeadAgencyTransactionTypeCommodityLog(this IQueryable<LeadAgencyTransactionTypeCommodityLog> leadAgencyTransactionTypeCommodityLogs, int leadAgencyTransactionTypeCommodityLogID)
        {
            DeleteLeadAgencyTransactionTypeCommodityLog(leadAgencyTransactionTypeCommodityLogs, new List<int> { leadAgencyTransactionTypeCommodityLogID });
        }

        public static void DeleteLeadAgencyTransactionTypeCommodityLog(this IQueryable<LeadAgencyTransactionTypeCommodityLog> leadAgencyTransactionTypeCommodityLogs, LeadAgencyTransactionTypeCommodityLog leadAgencyTransactionTypeCommodityLogToDelete)
        {
            DeleteLeadAgencyTransactionTypeCommodityLog(leadAgencyTransactionTypeCommodityLogs, new List<LeadAgencyTransactionTypeCommodityLog> { leadAgencyTransactionTypeCommodityLogToDelete });
        }
    }
}