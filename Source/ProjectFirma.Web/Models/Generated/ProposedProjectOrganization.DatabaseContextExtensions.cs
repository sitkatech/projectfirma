//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectOrganization]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectOrganization GetProposedProjectOrganization(this IQueryable<ProposedProjectOrganization> proposedProjectOrganizations, int proposedProjectOrganizationID)
        {
            var proposedProjectOrganization = proposedProjectOrganizations.SingleOrDefault(x => x.ProposedProjectOrganizationID == proposedProjectOrganizationID);
            Check.RequireNotNullThrowNotFound(proposedProjectOrganization, "ProposedProjectOrganization", proposedProjectOrganizationID);
            return proposedProjectOrganization;
        }

        public static void DeleteProposedProjectOrganization(this List<int> proposedProjectOrganizationIDList)
        {
            if(proposedProjectOrganizationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectOrganizations.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectOrganizations.Where(x => proposedProjectOrganizationIDList.Contains(x.ProposedProjectOrganizationID)));
            }
        }

        public static void DeleteProposedProjectOrganization(this ICollection<ProposedProjectOrganization> proposedProjectOrganizationsToDelete)
        {
            if(proposedProjectOrganizationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectOrganizations.RemoveRange(proposedProjectOrganizationsToDelete);
            }
        }

        public static void DeleteProposedProjectOrganization(this int proposedProjectOrganizationID)
        {
            DeleteProposedProjectOrganization(new List<int> { proposedProjectOrganizationID });
        }

        public static void DeleteProposedProjectOrganization(this ProposedProjectOrganization proposedProjectOrganizationToDelete)
        {
            DeleteProposedProjectOrganization(new List<ProposedProjectOrganization> { proposedProjectOrganizationToDelete });
        }
    }
}