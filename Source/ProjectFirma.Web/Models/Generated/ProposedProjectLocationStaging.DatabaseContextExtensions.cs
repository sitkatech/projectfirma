//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectLocationStaging]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectLocationStaging GetProposedProjectLocationStaging(this IQueryable<ProposedProjectLocationStaging> proposedProjectLocationStagings, int proposedProjectLocationStagingID)
        {
            var proposedProjectLocationStaging = proposedProjectLocationStagings.SingleOrDefault(x => x.ProposedProjectLocationStagingID == proposedProjectLocationStagingID);
            Check.RequireNotNullThrowNotFound(proposedProjectLocationStaging, "ProposedProjectLocationStaging", proposedProjectLocationStagingID);
            return proposedProjectLocationStaging;
        }

        public static void DeleteProposedProjectLocationStaging(this List<int> proposedProjectLocationStagingIDList)
        {
            if(proposedProjectLocationStagingIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectLocationStagings.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectLocationStagings.Where(x => proposedProjectLocationStagingIDList.Contains(x.ProposedProjectLocationStagingID)));
            }
        }

        public static void DeleteProposedProjectLocationStaging(this ICollection<ProposedProjectLocationStaging> proposedProjectLocationStagingsToDelete)
        {
            if(proposedProjectLocationStagingsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectLocationStagings.RemoveRange(proposedProjectLocationStagingsToDelete);
            }
        }

        public static void DeleteProposedProjectLocationStaging(this int proposedProjectLocationStagingID)
        {
            DeleteProposedProjectLocationStaging(new List<int> { proposedProjectLocationStagingID });
        }

        public static void DeleteProposedProjectLocationStaging(this ProposedProjectLocationStaging proposedProjectLocationStagingToDelete)
        {
            DeleteProposedProjectLocationStaging(new List<ProposedProjectLocationStaging> { proposedProjectLocationStagingToDelete });
        }
    }
}