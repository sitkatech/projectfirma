//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectLocation]
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteProposedProjectLocation(this List<int> proposedProjectLocationIDList)
        {
            if(proposedProjectLocationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectLocations.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectLocations.Where(x => proposedProjectLocationIDList.Contains(x.ProposedProjectLocationID)));
            }
        }

        public static void DeleteProposedProjectLocation(this ICollection<ProposedProjectLocation> proposedProjectLocationsToDelete)
        {
            if(proposedProjectLocationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectLocations.RemoveRange(proposedProjectLocationsToDelete);
            }
        }

        public static void DeleteProposedProjectLocation(this int proposedProjectLocationID)
        {
            DeleteProposedProjectLocation(new List<int> { proposedProjectLocationID });
        }

        public static void DeleteProposedProjectLocation(this ProposedProjectLocation proposedProjectLocationToDelete)
        {
            DeleteProposedProjectLocation(new List<ProposedProjectLocation> { proposedProjectLocationToDelete });
        }
    }
}