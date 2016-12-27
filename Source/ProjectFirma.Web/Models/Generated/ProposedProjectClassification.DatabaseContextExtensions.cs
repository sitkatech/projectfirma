//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProposedProjectClassification]
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Extensions;
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

        public static void DeleteProposedProjectClassification(this IQueryable<ProposedProjectClassification> proposedProjectClassifications, List<int> proposedProjectClassificationIDList)
        {
            if(proposedProjectClassificationIDList.Any())
            {
                proposedProjectClassifications.Where(x => proposedProjectClassificationIDList.Contains(x.ProposedProjectClassificationID)).Delete();
            }
        }

        public static void DeleteProposedProjectClassification(this IQueryable<ProposedProjectClassification> proposedProjectClassifications, ICollection<ProposedProjectClassification> proposedProjectClassificationsToDelete)
        {
            if(proposedProjectClassificationsToDelete.Any())
            {
                var proposedProjectClassificationIDList = proposedProjectClassificationsToDelete.Select(x => x.ProposedProjectClassificationID).ToList();
                proposedProjectClassifications.Where(x => proposedProjectClassificationIDList.Contains(x.ProposedProjectClassificationID)).Delete();
            }
        }

        public static void DeleteProposedProjectClassification(this IQueryable<ProposedProjectClassification> proposedProjectClassifications, int proposedProjectClassificationID)
        {
            DeleteProposedProjectClassification(proposedProjectClassifications, new List<int> { proposedProjectClassificationID });
        }

        public static void DeleteProposedProjectClassification(this IQueryable<ProposedProjectClassification> proposedProjectClassifications, ProposedProjectClassification proposedProjectClassificationToDelete)
        {
            DeleteProposedProjectClassification(proposedProjectClassifications, new List<ProposedProjectClassification> { proposedProjectClassificationToDelete });
        }
    }
}