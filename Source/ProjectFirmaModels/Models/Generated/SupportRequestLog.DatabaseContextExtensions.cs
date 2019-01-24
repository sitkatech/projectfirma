//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SupportRequestLog]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static SupportRequestLog GetSupportRequestLog(this IQueryable<SupportRequestLog> supportRequestLogs, int supportRequestLogID)
        {
            var supportRequestLog = supportRequestLogs.SingleOrDefault(x => x.SupportRequestLogID == supportRequestLogID);
            Check.RequireNotNullThrowNotFound(supportRequestLog, "SupportRequestLog", supportRequestLogID);
            return supportRequestLog;
        }

    }
}