//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[MatchmakerOrganizationClassification]
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
        public static MatchmakerOrganizationClassification GetMatchmakerOrganizationClassification(this IQueryable<MatchmakerOrganizationClassification> matchmakerOrganizationClassifications, int matchmakerOrganizationClassificationID)
        {
            var matchmakerOrganizationClassification = matchmakerOrganizationClassifications.SingleOrDefault(x => x.MatchmakerOrganizationClassificationID == matchmakerOrganizationClassificationID);
            Check.RequireNotNullThrowNotFound(matchmakerOrganizationClassification, "MatchmakerOrganizationClassification", matchmakerOrganizationClassificationID);
            return matchmakerOrganizationClassification;
        }

    }
}