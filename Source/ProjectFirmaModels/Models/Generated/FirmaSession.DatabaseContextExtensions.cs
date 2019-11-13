//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[FirmaSession]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static FirmaSession GetFirmaSession(this IQueryable<FirmaSession> firmaSessions, int firmaSessionID)
        {
            var firmaSession = firmaSessions.SingleOrDefault(x => x.FirmaSessionID == firmaSessionID);
            Check.RequireNotNullThrowNotFound(firmaSession, "FirmaSession", firmaSessionID);
            return firmaSession;
        }

    }
}