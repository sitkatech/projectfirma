//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectClassification]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProposedProjectClassification GetProposedProjectClassification(this IQueryable<ProposedProjectClassification> proposedProjectClassifications, int proposedProjectClassificationID)
        {
            var proposedProjectClassification = proposedProjectClassifications.SingleOrDefault(x => x.ProposedProjectClassificationID == proposedProjectClassificationID);
            Check.RequireNotNullThrowNotFound(proposedProjectClassification, "ProposedProjectClassification", proposedProjectClassificationID);
            return proposedProjectClassification;
        }

        public static void DeleteProposedProjectClassification(this List<int> proposedProjectClassificationIDList)
        {
            if(proposedProjectClassificationIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectClassifications.RemoveRange(HttpRequestStorage.DatabaseEntities.ProposedProjectClassifications.Where(x => proposedProjectClassificationIDList.Contains(x.ProposedProjectClassificationID)));
            }
        }

        public static void DeleteProposedProjectClassification(this ICollection<ProposedProjectClassification> proposedProjectClassificationsToDelete)
        {
            if(proposedProjectClassificationsToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProposedProjectClassifications.RemoveRange(proposedProjectClassificationsToDelete);
            }
        }

        public static void DeleteProposedProjectClassification(this int proposedProjectClassificationID)
        {
            DeleteProposedProjectClassification(new List<int> { proposedProjectClassificationID });
        }

        public static void DeleteProposedProjectClassification(this ProposedProjectClassification proposedProjectClassificationToDelete)
        {
            DeleteProposedProjectClassification(new List<ProposedProjectClassification> { proposedProjectClassificationToDelete });
        }
    }
}