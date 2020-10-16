//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationPerformanceMeasure]
using System.Collections.Generic;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static MatchmakerOrganizationPerformanceMeasure GetMatchmakerOrganizationPerformanceMeasure(this IQueryable<MatchmakerOrganizationPerformanceMeasure> matchmakerOrganizationPerformanceMeasures, int matchmakerOrganizationPerformanceMeasureID)
        {
            var matchmakerOrganizationPerformanceMeasure = matchmakerOrganizationPerformanceMeasures.SingleOrDefault(x => x.MatchmakerOrganizationPerformanceMeasureID == matchmakerOrganizationPerformanceMeasureID);
            Check.RequireNotNullThrowNotFound(matchmakerOrganizationPerformanceMeasure, "MatchmakerOrganizationPerformanceMeasure", matchmakerOrganizationPerformanceMeasureID);
            return matchmakerOrganizationPerformanceMeasure;
        }

    }
}