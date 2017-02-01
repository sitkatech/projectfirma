//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectLocation]
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
        public static ProposedProjectLocation GetProposedProjectLocation(this IQueryable<ProposedProjectLocation> proposedProjectLocations, int proposedProjectLocationID)
        {
            var proposedProjectLocation = proposedProjectLocations.SingleOrDefault(x => x.ProposedProjectLocationID == proposedProjectLocationID);
            Check.RequireNotNullThrowNotFound(proposedProjectLocation, "ProposedProjectLocation", proposedProjectLocationID);
            return proposedProjectLocation;
        }

        public static void DeleteProposedProjectLocation(this IQueryable<ProposedProjectLocation> proposedProjectLocations, List<int> proposedProjectLocationIDList)
        {
            if(proposedProjectLocationIDList.Any())
            {
                proposedProjectLocations.Where(x => proposedProjectLocationIDList.Contains(x.ProposedProjectLocationID)).Delete();
            }
        }

        public static void DeleteProposedProjectLocation(this IQueryable<ProposedProjectLocation> proposedProjectLocations, ICollection<ProposedProjectLocation> proposedProjectLocationsToDelete)
        {
            if(proposedProjectLocationsToDelete.Any())
            {
                var proposedProjectLocationIDList = proposedProjectLocationsToDelete.Select(x => x.ProposedProjectLocationID).ToList();
                proposedProjectLocations.Where(x => proposedProjectLocationIDList.Contains(x.ProposedProjectLocationID)).Delete();
            }
        }

        public static void DeleteProposedProjectLocation(this IQueryable<ProposedProjectLocation> proposedProjectLocations, int proposedProjectLocationID)
        {
            DeleteProposedProjectLocation(proposedProjectLocations, new List<int> { proposedProjectLocationID });
        }

        public static void DeleteProposedProjectLocation(this IQueryable<ProposedProjectLocation> proposedProjectLocations, ProposedProjectLocation proposedProjectLocationToDelete)
        {
            DeleteProposedProjectLocation(proposedProjectLocations, new List<ProposedProjectLocation> { proposedProjectLocationToDelete });
        }
    }
}