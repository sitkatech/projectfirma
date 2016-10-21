//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectLocationStaging]
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
        public static ProposedProjectLocationStaging GetProposedProjectLocationStaging(this IQueryable<ProposedProjectLocationStaging> proposedProjectLocationStagings, int proposedProjectLocationStagingID)
        {
            var proposedProjectLocationStaging = proposedProjectLocationStagings.SingleOrDefault(x => x.ProposedProjectLocationStagingID == proposedProjectLocationStagingID);
            Check.RequireNotNullThrowNotFound(proposedProjectLocationStaging, "ProposedProjectLocationStaging", proposedProjectLocationStagingID);
            return proposedProjectLocationStaging;
        }

        public static void DeleteProposedProjectLocationStaging(this IQueryable<ProposedProjectLocationStaging> proposedProjectLocationStagings, List<int> proposedProjectLocationStagingIDList)
        {
            if(proposedProjectLocationStagingIDList.Any())
            {
                proposedProjectLocationStagings.Where(x => proposedProjectLocationStagingIDList.Contains(x.ProposedProjectLocationStagingID)).Delete();
            }
        }

        public static void DeleteProposedProjectLocationStaging(this IQueryable<ProposedProjectLocationStaging> proposedProjectLocationStagings, ICollection<ProposedProjectLocationStaging> proposedProjectLocationStagingsToDelete)
        {
            if(proposedProjectLocationStagingsToDelete.Any())
            {
                var proposedProjectLocationStagingIDList = proposedProjectLocationStagingsToDelete.Select(x => x.ProposedProjectLocationStagingID).ToList();
                proposedProjectLocationStagings.Where(x => proposedProjectLocationStagingIDList.Contains(x.ProposedProjectLocationStagingID)).Delete();
            }
        }

        public static void DeleteProposedProjectLocationStaging(this IQueryable<ProposedProjectLocationStaging> proposedProjectLocationStagings, int proposedProjectLocationStagingID)
        {
            DeleteProposedProjectLocationStaging(proposedProjectLocationStagings, new List<int> { proposedProjectLocationStagingID });
        }

        public static void DeleteProposedProjectLocationStaging(this IQueryable<ProposedProjectLocationStaging> proposedProjectLocationStagings, ProposedProjectLocationStaging proposedProjectLocationStagingToDelete)
        {
            DeleteProposedProjectLocationStaging(proposedProjectLocationStagings, new List<ProposedProjectLocationStaging> { proposedProjectLocationStagingToDelete });
        }
    }
}