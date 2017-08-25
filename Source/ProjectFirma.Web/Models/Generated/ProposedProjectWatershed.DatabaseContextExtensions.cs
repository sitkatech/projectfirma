//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectWatershed]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectWatershed GetProposedProjectWatershed(this IQueryable<ProposedProjectWatershed> proposedProjectWatersheds, int proposedProjectWatershedID)
        {
            var proposedProjectWatershed = proposedProjectWatersheds.SingleOrDefault(x => x.ProposedProjectWatershedID == proposedProjectWatershedID);
            Check.RequireNotNullThrowNotFound(proposedProjectWatershed, "ProposedProjectWatershed", proposedProjectWatershedID);
            return proposedProjectWatershed;
        }

        public static void DeleteProposedProjectWatershed(this List<int> proposedProjectWatershedIDList)
        {
            if(proposedProjectWatershedIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectWatersheds.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectWatersheds.Where(x => proposedProjectWatershedIDList.Contains(x.ProposedProjectWatershedID)));
            }
        }

        public static void DeleteProposedProjectWatershed(this ICollection<ProposedProjectWatershed> proposedProjectWatershedsToDelete)
        {
            if(proposedProjectWatershedsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectWatersheds.RemoveRange(proposedProjectWatershedsToDelete);
            }
        }

        public static void DeleteProposedProjectWatershed(this int proposedProjectWatershedID)
        {
            DeleteProposedProjectWatershed(new List<int> { proposedProjectWatershedID });
        }

        public static void DeleteProposedProjectWatershed(this ProposedProjectWatershed proposedProjectWatershedToDelete)
        {
            DeleteProposedProjectWatershed(new List<ProposedProjectWatershed> { proposedProjectWatershedToDelete });
        }
    }
}